using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitTracker.Core.Service
{
    public class TrackerService : ITrackerService
    {
        public string GitSourcePath { private get; set; }

        public string DestinationPath { private get; set; }

        

        public TrackerService()
        {

        }

        public ITrackerService AddDestinationPath(string destinationPath)
        {
            this.DestinationPath = DestinationPath;
            return this;
        }

        public ITrackerService AddGitPaht(string gitpath)
        {
            throw new NotImplementedException();
        }

        public void run()
        {
            throw new NotImplementedException();
        }
    }
}
