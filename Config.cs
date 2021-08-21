using Synapse.Api.Enum;
using Synapse.Config;
using System.Collections.Generic;
using System.ComponentModel;
using static RoundSummary;

namespace Nukes
{
    public class Config : AbstractConfigSection
    {
        [Description("Is this Plugin enabled?")]
        public bool IsEnabled { get; set; } = true;

        [Description("Should the automatic Alpha Warhead be enabled?")]
        public bool EnableAutoWarhead { get; set; } = true;

        [Description("Should the Warhead be locked so it cannot be disabled while it starts?")]
        public bool EnableAutoWarheadLock { get; set; } = true;

        [Description("The time in seconds in which the Warhead starts")]
        public int AutoWarheadTime { get; set; } = 1500;

        [Description("Should the Omega Warhead be enabled?")]
        public bool EnableOmegaWarhead { get; set; } = true;

        [Description("Should the Omega Warhead be locked so it cannot be disabled while it starts?")]
        public bool EnableOmegaWarheadLock { get; set; } = true;

        [Description("The time in seconds in which the Omega Warhead starts")]
        public int OmegaWarheadTime { get; set; } = 1800;

        [Description("What should the Announcement be when the Omega Warhead starts?")]
        public string OmegaWarheadAnnouncement { get; set; } = "[Nukes] The Omega Alpha Warhead has started!\nWe are all doomed!";

        [Description("Should the Warhead explode after the round has ended?")]
        public bool EnableRoundEndWarhead { get; set; } = true;

        [Description("How long after the round end should the warhead detonate?")]
        public int RoundEndWarheadTimer { get; set; } = 5;

        [Description("Should the Warhead which explodes after the round should only explode if a certain End Condition is meet?")]
        public bool EnableCustomEndConditions { get; set; } = true;

        [Description("Which Team needs to win for the Warhead Explosion on the round end?")]
        public List<LeadingTeam> CustomEndConditions { get; set; } = new List<LeadingTeam>()
        {
            LeadingTeam.Anomalies
        };

        [Description("Should several doors be locked when the alpha warhead starts?")]
        public bool EnableLockdownSystem { get; set; } = true;

        [Description("Which doors should be closed and locked during the alpha warhead procedure?")]
        public List<DoorType> Doors { get; set; } = new List<DoorType>()
        {
            DoorType.HCZ_049_Armory,
            DoorType.HCZ_Armory,
            DoorType.LCZ_173_Armory,
            DoorType.LCZ_Armory,
            DoorType.Nuke_Armory,
        };

        [Description("Should a Broadcast be shown when the Alpha Warhead starts?")]
        public bool EnableLockdownMessage { get; set; } = true;

        [Description("Should players receive damage on the surface after the detonation of the Alpha Warhead?")]
        public bool EnableSurfaceTension { get; set; } = true;

        [Description("Should there be a broadcast when the players start getting damaged by the surface tension?")]
        public bool EnableSurfaceTensionMessage { get; set; } = true;

        [Description("The damage players get in the Surface Tension per Intervall?")]
        public int SurfaceTensionDamage { get; set; } = 1;

        [Description("The intervall (in seconds) in which players get damage over time?")]
        public float SurfaceTensionIntervall { get; set; } = 1f;

        [Description("Should there be a delay before players get damaged?")]
        public bool EnableSurfaceTensionDelay { get; set; } = true;

        [Description("Time (in seconds) to wait after the nuke is detonated before damaging players")]
        public float SurfaceTensionDelay { get; set; } = 30f;
    }
}
