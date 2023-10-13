using Microsoft.Extensions.DependencyInjection;
using Spectre.Console.Cli;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tddy.Console.Commands;
using Tddy.Core.Engine.DI;
using Xunit;

namespace Tddy.Console
{
    public class TddyApp
    {
        public static void Run<T>(string[] args) where T: ITestDiscoverService
        {
            var registrations = new ServiceCollection();
            registrations.AddSingleton<ITestDiscoverService,T>();

            // Create a type registrar and register any dependencies.
            // A type registrar is an adapter for a DI framework.
            var registrar = new TypeRegistrar(registrations);


            var app = new CommandApp<ExecuteInteractive>();

            //app.Configure(x =>
            //{
            //    x.
            //});
             app.Run(args);

        }
    }
}
