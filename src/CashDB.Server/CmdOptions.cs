// Copyright Lokad 2018 under MIT BCH.
using CommandLine;

namespace CashDB.Server
{
    [Verb("init", HelpText = "Initialize storage files.")]
    public class InitOptions
    {
        [Option("config", Required = false, Default= "./CashDB.config",
            HelpText = "path included fullname of config file.")]
        public string ConfigFullPath { get; set; }

        [Option("layer1", Required = true, HelpText = "First layer storage capacity in GB.")]
        public int Layer1SizeInGB { get; set; }

        [Option("layer2", Required = true, HelpText = "Second layer storage capacity in GB.")]
        public int Layer2SizeInGB { get; set; }
    }

    [Verb("run", HelpText = "Run an instance of the CashDB server.")]
    public class RunOptions
    {
        [Option("config", Required = false, Default = "./CashDB.config",
            HelpText = "Fullname path of  the CashDB config file.")]
        public string ConfigFullPath { get; set; }
    }
}
