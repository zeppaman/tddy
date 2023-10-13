using Spectre.Console;
using Spectre.Console.Cli;
using System.Diagnostics.CodeAnalysis;
using Tddy.Core.Model;
using Xunit;

namespace Tddy.Console.Commands
{
    public class ExecuteSettings : CommandSettings
    {
        [CommandArgument(0, "[PROJECT]")]
        public string Project { get; set; }
    }

    public class ExecuteInteractive : Command<ExecuteSettings>
    {
        private ITestDiscoverService service;

        public ExecuteInteractive(ITestDiscoverService service)
        {
            this.service = service;
        }

        public override int Execute([NotNull] CommandContext context, [NotNull] ExecuteSettings settings)
        {
            var testCases = service.GetTestCases();

            var str = "x";

            do
            {
                var selector = AnsiConsole.Prompt(
                    new SelectionPrompt<TestCase>()
                        .Title("What's your [green]favorite fruit[/]?")
                        .PageSize(10)
                        .MoreChoicesText("[grey](Move up and down to reveal more fruits)[/]")
                        .AddChoices(testCases));

                AnsiConsole.WriteLine(selector.MethodName);

                do
                {
                    service.Execute(selector);

                    var favorites = AnsiConsole.Ask<char>("What next [green]R for repeat[/], [blue]N for new[/], [red]X for exit[/]?");

                    str = new String(new char[] { favorites }).ToUpper();
                }
                while (str == "R");
            } while (str != "X");

            return 0;
        }
    }
}