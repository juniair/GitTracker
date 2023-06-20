// See https://aka.ms/new-console-template for more information
using CommandLine;
using CommandLine.Text;
using GitTracker.Core.Commands;
using GitTracker.Core.Commands.Builder;
using GitTracker.Core.Service;
using GitTracker.Core.Utils;
using System.Reflection;

Console.WriteLine("Hello, World!");

SentenceBuilder.Factory = () => new LocalizableSentenceBuilder();

using (var parser = new Parser(with => with.HelpWriter = null))
{
    var parserResult = parser.ParseArguments<TrackerCommandOption>(args);
    parserResult
        .WithParsed((option) =>
        {
            var service = new TrackerService();
            service.AddSourcePath(@"D:\workspace\00_git\murph_project\murph");
            service.AddDestinationPath(option.DestinationPath);
            service.run();
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

