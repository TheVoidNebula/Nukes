using Synapse.Translation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nukes
{
    public class PluginTranslation : IPluginTranslation
    {
        public string SurfaceTensionMessage = "<i><b><color=red>The radiation from the Detonation is starting to damage you...</color></b></i>";

        public string OmegaWarheadAnnouncement = "<i><b><color=red>The Omega Alpha Warhead has started!</color></b></i>";

        public string OmegaWarheadRoundBeginningAnnouncement  = "<i><b><color=red>The Omega Alpha Warhead starts in <color=yellow>%time% Minutes</color></color>!</b></i>";

        public string AutoWarheadRoundBeginningAnnouncement = "<i><b><color=red>The Automatic Alpha Warhead starts in <color=yellow>%time% Minutes</color>!</color></b></i>";

        public string AutoWarheadAnnouncement = "<i><b><color=red>The Automatic Alpha Warhead has started!</color></b></i>";

        public string DoorLockdownMessage = "<i><b><color=red>Several Doors will be locked down during the Warhead Detonation...</color></b></i>";
    }
}
