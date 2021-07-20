using Synapse.Config;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        [Description("What should the Announcement be when the Alpha Warhead starts?")]
        public string AutoWarheadAnnouncement { get; set; } = "[Nukes] The Automatic Alpha Warhead has started!";

        [Description("What should the Announcement be at the beginning of a round?")]
        public string AutoWarheadRoundBeginningAnnouncement { get; set; } = "[Nukes] The Automatic Alpha Warhead starts in 25 Minutes!";

        [Description("Should the Omega Warhead be enabled?")]
        public bool EnableOmegaWarhead { get; set; } = true;

        [Description("Should the Omega Warhead be locked so it cannot be disabled while it starts?")]
        public bool EnableOmegaWarheadLock { get; set; } = true;

        [Description("The time in seconds in which the Omega Warhead starts")]
        public int OmegaWarheadTime { get; set; } = 30;

        [Description("What should the Announcement be when the Omega Warhead starts?")]
        public string OmegaWarheadAnnouncement { get; set; } = "[Nukes] The Omega Alpha Warhead has started!\nWe are all doomed!";

        [Description("What should the Announcement be at the beginning of a round?")]
        public string OmegaWarheadRoundBeginningAnnouncement { get; set; } = "[Nukes] The Omega Alpha Warhead starts in 30 Minutes!";

        [Description("What should the Announcement be when you die by the Omega Warhead?")]
        public string OmegaWarheadDeathMessage { get; set; } = "[Nukes] The Omega Warhead destroyed everybody and everything!";
    }
}
