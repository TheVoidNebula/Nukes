using MEC;
using Synapse;
using Synapse.Api;
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
        public EventHandlers()
        {
            Server.Get.Events.Round.RoundStartEvent += OnRoundStart;
            Server.Get.Events.Round.RoundEndEvent += onRoundEnd;
            Server.Get.Events.Map.WarheadDetonationEvent += OnNuke;
        }

        public void OnRoundStart()
        {
            if (Plugin.Config.IsEnabled && Plugin.Config.EnableAutoWarhead)
                Coroutines.Add(Timing.RunCoroutine(AutoWarhead()));

            if (Plugin.Config.IsEnabled && Plugin.Config.EnableOmegaWarhead)
                Coroutines.Add(Timing.RunCoroutine(OmegaWarhead()));
        }

        public void onRoundEnd()
        {
            Coroutines.Clear();
            omegaWarhead = false;
        }

        public void OnNuke()
        {
            if (omegaWarhead)
                Map.Get.SendBroadcast(5, Plugin.Config.OmegaWarheadDeathMessage, true);
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
    }
}
