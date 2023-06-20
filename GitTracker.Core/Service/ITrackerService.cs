using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitTracker.Core.Service
{
    public interface ITrackerService<T>
    {
        public T AddSourcePath(string gitpath);
        public T AddDestinationPath(string destinationPath);
        public void run();
    }
}
