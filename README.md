# ![Logo](media/NerdyDuck.Logging.svg) NerdyDuck.Logging

This project provides a library with a set of base classes that can be used to create a highly specialized and integrated logging solution for your application.
This project is not intended as a replacement for well-known libraries like [log4net](https://logging.apache.org/log4net/) or [NLog](http://nlog-project.org/), that are used to implement logging fast and flexible.
Instead, you can use it if you want to have precise control over the data that is logged, and the log formats and targets.
One logbook can send the log output to multiple targets (called listeners). Base classes for various listeners are provided, that can direct the log output to text files (plain text, XML or JSON), Windows&reg; event log, SQL databases and syslog servers.
But you can also create completely new listeners to suit your needs. Which log entries to write is decided using filters, that are tailored to the data you want to log. A single filter can filter the log output for all listeners, or you can add separate filters for individual listeners.
A configuration of a logbook with listeners and filters can easily by persisted via XML (e.g. in an app.config file), or JSON, but also adapted to any other medium like databases.

#### Platforms
- .NET Standard 2.0 (netstandard2.0), to support .NET Framework (4.6.1 and up), .NET Core (2.0 and up), Mono (5.4 and up), and the Xamarin and UWP platforms.
- .NET 5 (net5.0)
- .NET 6 (net6.0)

#### Dependencies
The project uses the following NuGet packages not issued by Microsoft as part of the BCL:
- [NerdyDuck.CodedExceptions](https://www.nuget.org/packages/NerdyDuck.CodedExceptions)

#### Languages
The neutral resource language for all texts is English (en-US). Currently, the only localization available is German (de-DE). If you like to add other languages, feel free to send a pull request with the translated resources!

#### How to get
- Use the NuGet package (include debug symbol files and supports [SourceLink](https://github.com/dotnet/sourcelink): https://www.nuget.org/packages/NerdyDuck.Logging
- Download the binaries from the [Releases](../../releases/) page.

#### More information
For examples and a complete class reference, please see the [Wiki](../../wiki/). :exclamation: **Work in progress**.

#### License
The project is licensed under the [MIT License](LICENSE).

#### History
##### TBD / 2.0.0-rc.1 / DAK
- Upgraded platform to .NET Standard 2.0, .NET 5 and .NET 6
- Removed separate binaries for UWP (use .NET Standard 2.0 instead)
- Changed German resources from de-DE to just de.
- Restructured repository, using Directory.Build.props/.targets for common configuration
- Switched license from Apache 2.0 to MIT
- Complete unit tests added
- Some bug fixes

