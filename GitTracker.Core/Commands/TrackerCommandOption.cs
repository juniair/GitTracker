using CommandLine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitTracker.Core.Commands
{
    public class TrackerCommandOption
    {
        [Option('s', "gitpath", HelpText = "GitPath", ResourceType = typeof(Properties.Resources))]
        public string? GitPath { get; set; }

        [Option('d', "dest", Default = "./output", HelpText = "Destination Path", ResourceType = typeof(Properties.Resources))]
        public string? DestinationPath { get; set; }


    }
}
