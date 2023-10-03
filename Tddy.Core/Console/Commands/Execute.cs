using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spectre.Console;
using Spectre.Console.Cli;
using Tddy.Core.Engine.Xunit;
using Tddy.Core.Model;

namespace Tddy.Console.Commands
{
    public class ExecuteSettings : CommandSettings
    {
        [CommandArgument(0, "[PROJECT]")]
        public string Project { get; set; }
    }


    public class ExecuteInteractive : Command<ExecuteSettings>
    {

        
        public override int Execute([NotNull] CommandContext context, [NotNull] ExecuteSettings settings)
        {
            var service = new TestDiscoverService();
            var testCases=service.GetTestCases();

            var str = "x";

            do
            {
                var choices = testCases.Select((x, Index) => Index + " - " + x.MethodName).ToArray();


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
