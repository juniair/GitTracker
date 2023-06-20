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
        internal string? Id { get; set; }
        internal string? Author { get; set; }
        internal string? Date { get; set; }
        internal string? Path { get; set; }
        internal ChangeKind Status { get; set; }

        public override string ToString()
        {
            return $@"{Path}, {Id}, {Date}, {Author}, {Enum.GetName<ChangeKind>(Status)}";
        }

    }
}
