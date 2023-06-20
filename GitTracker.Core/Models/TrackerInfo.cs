using LibGit2Sharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitTracker.Core.Models
{
    internal class TrackerInfo
    {
        internal string? Id { private get; set; }
        internal string? Author { private get; set; }
        internal string? Date { private get; set; }
        internal string Path { private get; set; }
        internal ChangeKind Status { private get; set; }

        public override string ToString()
        {
            return $@"{Path}, {Id}, {Date}, {Author}, {Enum.GetName<ChangeKind>(Status)}";
        }

    }
}
