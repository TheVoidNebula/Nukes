using Synapse.Api.Plugin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nukes
{
    [PluginInformation(
        Author = "TheVoidNebula",
        Description = "Adds the Omega Warhead and a Auto Warhead!",
        LoadPriority = 0,
        Name = "Nukes",
        SynapseMajor = 2,
        SynapseMinor = 6,
        SynapsePatch = 0,
        Version = "1.1"
        )]
    public class Plugin : AbstractPlugin
    {
        [Synapse.Api.Plugin.Config(section = "Nukes")]
        public static Config Config;
        public override void Load()
        {
            SynapseController.Server.Logger.Info("Nukes loaded!");
        }

        public override void ReloadConfigs()
        {

        }
    }
}
