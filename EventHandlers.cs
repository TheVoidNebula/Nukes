using MEC;
using Synapse;
using Synapse.Api;
using Synapse.Api.Events.SynapseEventArguments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        }

        public void OnRoundEnd(RoundCheckEventArgs ev)
        {
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
                Map.Get.SendBroadcast(5, Plugin.Config.OmegaWarheadDeathMessage, true);
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
            Map.Get.SendBroadcast(5, Plugin.Config.AutoWarheadRoundBeginningAnnouncement);
            yield return Timing.WaitForSeconds(Plugin.Config.AutoWarheadTime);
            Map.Get.SendBroadcast(5, Plugin.Config.AutoWarheadAnnouncement);
            if (Plugin.Config.EnableAutoWarheadLock)
                Nuke.Get.InsidePanel.Locked = true;
            Nuke.Get.StartDetonation();
        }

        public IEnumerator<float> OmegaWarhead()
        {
            Map.Get.SendBroadcast(5, Plugin.Config.OmegaWarheadRoundBeginningAnnouncement);
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
                            Map.Get.SendBroadcast(5, Plugin.Config.DoorLockdownMessage, true);

                        foreach (Synapse.Api.Door doors in Map.Get.Doors)
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
                    foreach (Synapse.Api.Door doors in Map.Get.Doors)
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
                Map.Get.SendBroadcast(5, Plugin.Config.SurfaceTensionMessage, true);
            while (true)
            {
                foreach (Player players in Server.Get.Players)
                    players.Hurt(Plugin.Config.SurfaceTensionDamage, DamageTypes.Nuke);
                yield return Timing.WaitForSeconds(Plugin.Config.SurfaceTensionIntervall);
            }
        }

    }
}
