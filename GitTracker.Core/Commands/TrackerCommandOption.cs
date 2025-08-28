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

        public static DateTime Today => DateTime.Today;

        [Option('s', "source", Default = "./", HelpText = "GitPath", ResourceType = typeof(Properties.Resources))]
        public string? GitPath { get; set; }

        [Option('d', "dest", Default = "./output", HelpText = "DestinationPath", ResourceType = typeof(Properties.Resources))]
        public string? DestinationPath { get; set; }

        [Option('b', "branch", Default = "master", HelpText = "BranchName", ResourceType = typeof(Properties.Resources))]
        public string? BranchName { get; set; }

        [Option("since", HelpText = "SinceTracker", ResourceType = typeof(Properties.Resources))]
        public DateTime Since { get; set; }

        [Option("duplicateMode", Default = false, HelpText = "Duplicate", ResourceType = typeof(Properties.Resources))]
        public bool CanDuplicate { get; set; }
    }
}
