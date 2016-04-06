# NerdyDuck.Logging

This project provides a library with a set of base classes that can be used to create a highly specialized and integrated logging solution for your application.
This project is not intended as a replacement for well-known libraries like [log4net](https://logging.apache.org/log4net/) or [NLog](http://nlog-project.org/), that are used to implement logging fast and flexible.
Instead, you can use it if you want to have precise control over the data that is logged, and the log formats and targets.
One logbook can send the log output to multiple targets (called listeners). Base classes for various listeners are provided, that can direct the log output to text files, XML files, Windows&reg; event log, SQL databases and syslog servers.
But you can also create completely new listeners to suit your needs. Which log entries to write is decided using filters, that are tailored to the data you want to log. A single filter can filter the log output for all listeners, or you can add separate filters for individual listeners.
A configuration of a logbook with listeners and filters can easily by persisted via XML (e.g. in an app.config file), but also adapted to any other medium like databases.

#### Platforms
- .NET Framework 4.6 or newer for desktop applications
- Universal Windows Platform (UWP) 10.0 (Windows 10) or newer for Windows Store Apps and [Windows 10 IoT](https://dev.windows.com/en-us/iot).

#### Dependencies
The project uses the following NuGet packages that are either found on NuGet.org or my own feed (see below):
- NerdyDuck.CodedExceptions

#### Languages
The neutral resource language for all texts is English (en-US). Currently, the only localization available is German (de-DE). If you like to add other languages, feel free to send a pull request with the translated resources!

#### How to get
- Use the NuGet package from my [MyGet](https://www.myget.org) feed: [https://www.myget.org/F/nerdyduck-release/api/v3/index.json](https://www.myget.org/F/nerdyduck-release/api/v3/index.json). If you need to debug the library, get the debug symbols from the same feed: [https://www.myget.org/F/nerdyduck-release/symbols/](https://www.myget.org/F/nerdyduck-release/symbols/).
- Download the binaries from the [Releases](../../releases/) page.
- You can clone the repository and compile the libraries yourself (see the [Wiki](../../wiki/) for requirements).

#### More information
For examples and a complete class reference, please see the [Wiki](../../wiki/). :exclamation: **Work in progress**.

#### Licence
The project is licensed under the [Apache License, Version 2.0](LICENSE).

#### History

