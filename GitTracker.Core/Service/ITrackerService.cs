using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitTracker.Core.Service
{
    public interface ITrackerService
    {
        public ITrackerService AddGitPaht(string gitpath);
        public ITrackerService AddDestinationPath(string destinationPath);
        public void run();
    }
}
