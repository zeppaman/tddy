# tddy
.net test driven development framework for accelerating test development 
 
# how to install

1. add nuget packages to your project by `dotnet add package Tddy`
2. add a Program.cs file into your existing unit test project or create a new console application
3. enable Tddy by adding

   ```cs
	using Tddy.Console;

	TddyApp.Run(args);
   ```
