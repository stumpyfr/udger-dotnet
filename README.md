# Udger client for .NET(core) (data ver. 3)
Local parser is very fast and accurate useragent string detection solution. Enables developers to locally install and integrate a highly-scalable product.
We provide the detection of the devices (personal computer, tablet, Smart TV, Game console etc.), operating system, client SW type (browser, e-mail client etc.)
and devices market name (example: Sony Xperia Tablet S, Nokia Lumia 820 etc.).
It also provides information about IP addresses (Public proxies, VPN services, Tor exit nodes, Fake crawlers, Web scrapers, Datacenter name .. etc.)

## Requirements
- .NET Framework 4 or later. (or netstandard1.6)
- datafile v3 (udgerdb_v3.dat) from https://data.udger.com/ 

## Automatic updates download
- for autoupdate data use Udger data updater (https://udger.com/support/documentation/?doc=62)

## Installation

You can retrieve the nuget package:

`Install-Package Udger.Core -Pre`

## Features
- Fast
- Written in C#
- LRU cache
- Released under the GNU (LGPL v.3)


## Usage
You should review the included example (`ConsoleTest\Program.cs`)
Here's a quick example:

```csharp
UdgerParser parser = new UdgerParser();
// Set data dir (in this directory is stored data file: udgerdb_v3.dat)
// Data file can be downloaded manually from https://data.udger.com/, but we recommend use udger-updater (https://udger.com/support/documentation/?doc=62)
parser.SetDataDir(@"C:\udger");
// set user agent and/or IP address
parser.ua = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/48.0.2564.116 Safari/537.36";
parser.ip = "2600:3c01::f03c:91ff:fe70:9208";
// parse
parser.parse();
Udger.Parser.UserAgent a = parser.userAgent;
Udger.Parser.IPAddress i = parser.ipAddress;
```


## Documentation for programmers
- https://udger.com/pub/documentation/parser/NET/html/


## Author
The Udger.com Team (info@udger.com)

## old v2 format
If you still use the previous format of the db (v2), please see the branch old_format_v2