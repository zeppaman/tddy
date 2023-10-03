using Spectre.Console.Cli;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tddy.Console.Commands;

namespace Tddy.Console
{
    public class TddyApp
    {
        public static void Run(string[] args)
        {
            var app = new CommandApp<ExecuteInteractive>();
             app.Run(args);

        }
    }
}
