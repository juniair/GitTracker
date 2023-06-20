// See https://aka.ms/new-console-template for more information
using CommandLine;
using CommandLine.Text;
using GitTracker.Core.Commands;
using GitTracker.Core.Commands.Builder;
using GitTracker.Core.Service;
using GitTracker.Core.Utils;

SentenceBuilder.Factory = () => new LocalizableSentenceBuilder();

using (var parser = new Parser(with => with.HelpWriter = null))
{
    var parserResult = parser.ParseArguments<TrackerCommandOption>(args);
    parserResult
        .WithParsed((option) =>
        {
            var service = new TrackerService();
            service.AddSourcePath(option.GitPath)
                        .AddDestinationPath(option.DestinationPath)
                        .AddBranchName(option.BranchName)
                        .AddSinceDateTime(option.Since)
                        .AddDuplicateMode(option.CanDuplicate)
                        .run();
            Console.WriteLine("종료하시려면 아무키나 입력하세요.");
            Console.Read();
        })
        .WithNotParsed(errors => DisplayHelp(parserResult, errors));
}


void DisplayHelp(ParserResult<TrackerCommandOption>? result, IEnumerable<Error> errors)
{
    var helpText = HelpText.AutoBuild(result, h =>
    {
        h.OptionComparison = OptionOrder.OrderProcess;
        h.MaximumDisplayWidth = 512;
        //h.OptionComparison = orderOnShortName;
        return HelpText.DefaultParsingErrorsHandler(result, h);
    },
    example => example);
    Console.WriteLine(helpText);
}

