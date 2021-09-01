using MEC;
using Synapse;
using Synapse.Api;
using Synapse.Api.Events.SynapseEventArguments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Nukes
{
    public class EventHandlers
    {
        public List<CoroutineHandle> Coroutines = new List<CoroutineHandle>();
        public bool omegaWarhead = false;
        public bool IsLocked = false;
        public EventHandlers()
        {
            Server.Get.Events.Round.RoundStartEvent += OnRoundStart;
            Server.Get.Events.Round.RoundCheckEvent += OnRoundEnd;
            Server.Get.Events.Map.WarheadDetonationEvent += OnNuke;
        }

        public void OnRoundStart()
        {
            if (Plugin.Config.IsEnabled && Plugin.Config.EnableAutoWarhead)
                Coroutines.Add(Timing.RunCoroutine(AutoWarhead()));

            if (Plugin.Config.IsEnabled && Plugin.Config.EnableOmegaWarhead)
                Coroutines.Add(Timing.RunCoroutine(OmegaWarhead()));

            if (Plugin.Config.IsEnabled && Plugin.Config.EnableLockdownSystem)
                Coroutines.Add(Timing.RunCoroutine(CloseDoors()));

            if (Plugin.Config.IsEnabled)
                Coroutines.Add(Timing.RunCoroutine(NukeLights()));

        }

        public void OnRoundEnd(RoundCheckEventArgs ev)
        {
            Timing.KillCoroutines();
            Coroutines.Clear();
            omegaWarhead = false;
            IsLocked = false;

            if (Plugin.Config.EnableRoundEndWarhead && Plugin.Config.EnableCustomEndConditions && Plugin.Config.CustomEndConditions.Contains(ev.Team))
                    StartEndWarhead();
            else if(Plugin.Config.EnableRoundEndWarhead && !Plugin.Config.EnableCustomEndConditions)
                    StartEndWarhead();

        }

        public void OnNuke()
        {
            if (omegaWarhead)
            {
                Map.Get.SendBroadcast(5, Plugin.PluginTranslation.ActiveTranslation.OmegaWarheadAnnouncement, true);
                foreach (Player players in Server.Get.Players)
                    players.Kill(DamageTypes.Nuke);
            }

            if (Plugin.Config.EnableSurfaceTension)
                if (Plugin.Config.EnableSurfaceTensionDelay)
                    Timing.CallDelayed(Plugin.Config.SurfaceTensionDelay, () => Coroutines.Add(Timing.RunCoroutine(SurfaceTension())));
                else
                    Timing.RunCoroutine(SurfaceTension());
        }

        public void StartEndWarhead()
        {
            if(Plugin.Config.RoundEndWarheadTimer <= 0)
                    Nuke.Get.Detonate();
            else
                Timing.CallDelayed(Plugin.Config.RoundEndWarheadTimer, () => Nuke.Get.Detonate());
        }



        public IEnumerator<float> AutoWarhead()
        {
            Map.Get.SendBroadcast(5, Plugin.PluginTranslation.ActiveTranslation.AutoWarheadRoundBeginningAnnouncement.Replace("%time%", (Plugin.Config.AutoWarheadTime/60).ToString()));
            yield return Timing.WaitForSeconds(Plugin.Config.AutoWarheadTime);
            Map.Get.SendBroadcast(5, Plugin.PluginTranslation.ActiveTranslation.AutoWarheadAnnouncement);
            if (Plugin.Config.EnableAutoWarheadLock)
                Nuke.Get.InsidePanel.Locked = true;
            Nuke.Get.StartDetonation();
        }

        public IEnumerator<float> OmegaWarhead()
        {
            Map.Get.SendBroadcast(5, Plugin.PluginTranslation.ActiveTranslation.OmegaWarheadRoundBeginningAnnouncement.Replace("%time%", (Plugin.Config.OmegaWarheadTime / 60).ToString()));
            yield return Timing.WaitForSeconds(Plugin.Config.OmegaWarheadTime);
            Map.Get.SendBroadcast(5, Plugin.Config.OmegaWarheadAnnouncement);
            if (Plugin.Config.EnableOmegaWarheadLock)
                Nuke.Get.InsidePanel.Locked = true;
            Nuke.Get.StartDetonation();
            omegaWarhead = true;
        }

        public IEnumerator<float> CloseDoors()
        {
            while (true)
            {
                if (AlphaWarheadController.Host.inProgress)
                {
                    if (!IsLocked)
                    {
                        yield return Timing.WaitForSeconds(12);

                        if (Plugin.Config.EnableLockdownMessage)
                            Map.Get.SendBroadcast(5, Plugin.PluginTranslation.ActiveTranslation.DoorLockdownMessage, true);

                        foreach (Door doors in Map.Get.Doors)
                        {
                            if (Plugin.Config.Doors.Contains(doors.DoorType))
                            {
                                doors.Open = false;
                                doors.Locked = true;
                            }
                        }
                        IsLocked = true;
                    }
                }
                else if (!AlphaWarheadController.Host.inProgress && IsLocked)
                {
                    foreach (Door doors in Map.Get.Doors)
                    {
                        if (Plugin.Config.Doors.Contains(doors.DoorType))
                        {
                            doors.Open = true;
                            doors.Locked = false;
                        }
                    }
                    IsLocked = false;
                }
                yield return Timing.WaitForSeconds(1f);
            }
        }

        public IEnumerator<float> SurfaceTension()
        {
            if (Plugin.Config.EnableSurfaceTensionMessage)
                Map.Get.SendBroadcast(5, Plugin.PluginTranslation.ActiveTranslation.SurfaceTensionMessage, true);
            while (true)
            {
                foreach (Player players in Server.Get.Players)
                    players.Hurt(Plugin.Config.SurfaceTensionDamage, DamageTypes.Nuke);
                yield return Timing.WaitForSeconds(Plugin.Config.SurfaceTensionIntervall);
            }
        }

        public IEnumerator<float> NukeLights()
        {
            while (true)
            {
                if (!Round.Get.RoundEnded && AlphaWarheadController.Host.isActiveAndEnabled && Plugin.Config.EnableNukeLightsCustomColor)
                {
                        foreach (FlickerableLightController lightController in FlickerableLightController.Instances)
                        {
                            lightController.WarheadLightOverride = false;
                            lightController.WarheadLightColor = new Color(Plugin.Config.NukeLightColor.Red / 255f, Plugin.Config.NukeLightColor.Green / 255f, Plugin.Config.NukeLightColor.Blue / 255f);
                        }
                }

                if (!Round.Get.RoundEnded && AlphaWarheadController.Host.detonated && Plugin.Config.EnableNoLightsAfterDetonation)
                {
                    foreach (var rooms in Map.Get.Rooms)
                        rooms.LightsOut(Plugin.Config.NoLightsAfterDetonationDuration);
                }

                if (!Round.Get.RoundEnded && AlphaWarheadController.Host.detonated && Plugin.Config.EnableNukeLightsCustomColorAfterDetonation)
                {
                    foreach (FlickerableLightController lightController in FlickerableLightController.Instances)
                    {
                        lightController.WarheadLightOverride = false;
                        lightController.WarheadLightColor = new Color(Plugin.Config.NukeLightDetonationColor.Red / 255f, Plugin.Config.NukeLightDetonationColor.Green / 255f, Plugin.Config.NukeLightDetonationColor.Blue / 255f);
                    }
                }
                yield return Timing.WaitForSeconds(1f);
            }
        }

    }
}
