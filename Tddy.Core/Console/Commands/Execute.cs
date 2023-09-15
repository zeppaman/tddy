﻿using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spectre.Console;
using Spectre.Console.Cli;

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
            var fruits = AnsiConsole.Prompt(
    new MultiSelectionPrompt<string>()
        .Title("What are your [green]favorite fruits[/]?")
        .NotRequired() // Not required to have a favorite fruit
        .PageSize(10)
        .MoreChoicesText("[grey](Move up and down to reveal more fruits)[/]")
        .InstructionsText(
            "[grey](Press [blue]<space>[/] to toggle a fruit, " +
            "[green]<enter>[/] to accept)[/]")
        .AddChoices(new[] {
            "Apple", "Apricot", "Avocado",
            "Banana", "Blackcurrant", "Blueberry",
            "Cherry", "Cloudberry", "Coconut",
        }));

            // Write the selected fruits to the terminal
            foreach (string fruit in fruits)
            {
                AnsiConsole.WriteLine(fruit);
            }

            return 0;
        }
    }
}
