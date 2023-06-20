using GitTracker.Core.Models;
using LibGit2Sharp;

namespace GitTracker.Core.Service
{
    public class TrackerService : ITrackerService<TrackerService>
    {
        public string GitSourcePath { private get; set; }

        public string DestinationPath { private get; set; }

        public string BranchName { private get; set; }

        public DateTime? SinceDateTime { private get; set; }

        public bool CanDuplicate { private get; set; }




        public TrackerService()
        {

        }

        public TrackerService AddDestinationPath(string destinationPath)
        {
            this.DestinationPath = destinationPath;
            return this;
        }

        public TrackerService AddSourcePath(string sourcePath)
        {
            GitSourcePath = sourcePath;
            return this;
        }

        public TrackerService AddBranchName(string branchName)
        {
            BranchName = branchName;
            return this;
        }

        public TrackerService AddSinceDateTime(DateTime? sinceDateTime)
        {
            SinceDateTime = sinceDateTime;
            return this;
        }

        public TrackerService AddDuplicateMode(bool canDuplicate)
        {
            CanDuplicate = canDuplicate;
            return this;
        }

        public void run()
        {
            var trackers = new List<TrackerInfo>();
            using (var repository = new Repository(GitSourcePath))
            {
                if(!string.IsNullOrEmpty(BranchName))
                {
                    var branch = repository.Branches[this.BranchName];
                    LibGit2Sharp.Commands.Checkout(repository, branch);
                }
                
                var commits = repository.Commits.QueryBy(new CommitFilter
                {
                    SortBy = CommitSortStrategies.Time
                });
                foreach(var commit in commits)
                {
                    var sha = commit.Sha;
                    var committer = commit.Author.Name;
                    var commitDate = commit.Author.When.Date;

                    if (SinceDateTime != null
                        && 0 < SinceDateTime?.Date.CompareTo(commitDate.Date))
                    {
                        break;
                    }

                    var changes = repository.Diff.Compare<TreeChanges>(commit.Parents.FirstOrDefault()?.Tree ?? commit.Tree, commit.Tree);

                    foreach(var change in changes)
                    {
                        if (CanDuplicate && trackers.Any(tracker => tracker.Path.Equals(change.Path, StringComparison.Ordinal)))
                        {
                            continue;
                        }
                        var tracker = new TrackerInfo
                        {
                            Id = sha,
                            Author = committer,
                            Date = commitDate.ToShortDateString(),
                            Path = change.Path,
                            Status = change.Status
                        };
                        trackers.Add(tracker);
                    }
                }
            }

            if(!string.IsNullOrEmpty(DestinationPath))
            {
                using(var writer = new StreamWriter(DestinationPath))
                {
                    writer.WriteLine($"형상항목명, 버전, 최종수정일, 관련개발자, 파일 상태");
                    trackers.ForEach(writer.WriteLine);
                    Console.WriteLine($@"{DestinationPath} 경로에 파일을 생성했습니다.");
                }
            } 
            else
            {
                trackers.ForEach(Console.WriteLine);
            }
        }
    }
}
