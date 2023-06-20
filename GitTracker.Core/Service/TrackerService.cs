using GitTracker.Core.Models;
using LibGit2Sharp;
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

        public string BranchName { get; set; }

        

        public TrackerService()
        {

        }

        public ITrackerService AddDestinationPath(string destinationPath)
        {
            this.DestinationPath = DestinationPath;
            return this;
        }

        public ITrackerService AddSourcePath(string sourcePath)
        {
            GitSourcePath = sourcePath;
            return this;
        }

        public ITrackerService AddBranchName(string branchName)
        {
            BranchName = branchName;
            return this;
        }

        public void run()
        {
            var trackers = new List<TrackerInfo>();
            using (var repository = new Repository(GitSourcePath))
            {
                var commits = repository.Commits.QueryBy(new CommitFilter
                {
                    SortBy = CommitSortStrategies.Time
                });
                foreach(var commit in commits)
                {
                    var sha = commit.Sha;
                    var committer = commit.Author.Name;
                    var commitDate = commit.Author.When.Date.ToShortDateString();

                    var changes = repository.Diff.Compare<TreeChanges>(commit.Parents.FirstOrDefault()?.Tree ?? commit.Tree, commit.Tree);

                    foreach(var change in changes)
                    {
                        var tracker = new TrackerInfo
                        {
                            Id = sha,
                            Author = committer,
                            Date = commitDate,
                            Path = change.Path,
                            Status = change.Status
                        };
                        trackers.Add(tracker);
                    }
                }
            }
        }
    }
}
