using Synapse.Api.Plugin;
using Synapse.Translation;
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
        Version = "1.3"
        )]
    public class Plugin : AbstractPlugin
    {
        [Synapse.Api.Plugin.Config(section = "Nukes")]
        public static Config Config;

        [SynapseTranslation]
        public static SynapseTranslation<PluginTranslation> PluginTranslation;
        public override void Load()
        {
            SynapseController.Server.Logger.Info("Nukes loaded!");
            PluginTranslation.AddTranslation(new PluginTranslation());

            PluginTranslation.AddTranslation(new PluginTranslation
            {
                AutoWarheadAnnouncement = "<i><b><color=red>Der Automatische Alpha Warhead ist gestartet!</color></b></i>",
                AutoWarheadRoundBeginningAnnouncement = "<i><b><color=red>Der Automatische Alpha Warhead startet in <color=yellow>%time% Minuten</color>!</color></b></i>",
                DoorLockdownMessage = "<i><b><color=red>Einige Türen werden während der Detonation gesperrt!</color></b></i>",
                OmegaWarheadAnnouncement = "<i><b><color=red>Der Omega Warhead ist gestartet!</color></b></i>",
                OmegaWarheadRoundBeginningAnnouncement = "<i><b><color=red>Der Omega Warhead startet in <color=yellow>%time% Minuten</color>!</color></b></i>",
                SurfaceTensionMessage = "<i><b><color=red>Die Radioaktivität von der Detonation fügt dir langsam Schaden zu...</color></b></i>"
            }, "GERMAN");
            new EventHandlers();

        }
    }
}
