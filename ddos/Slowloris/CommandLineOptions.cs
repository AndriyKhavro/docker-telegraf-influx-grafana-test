using CommandLine;

namespace Slowloris;

internal class CommandLineOptions
{
    [Option('i', "ipaddress", Required = true, HelpText = "IP or Domain of the target.")]
    public string IpAddress { get; set; }

    [Option('p', "port", Required = true, HelpText = "Port Number of the target.")]
    public string Port { get; set; }

    [Option('s', "sleep", Required = true, HelpText = "How often to attack the target.")]
    public string Sleep { get; set; }
}