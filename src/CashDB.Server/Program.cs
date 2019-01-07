// Copyright Lokad 2018 under MIT BCH.
using System;
using System.Diagnostics;
using System.Threading;
using CommandLine;
using CashDB.Lib;

namespace CashDB.Server
{
    internal class Program
    {
        private static ILog _log;

        public static void Main(string[] args)
        {
            Parser.Default.ParseArguments<InitOptions, RunOptions>(args)
                .WithParsed<InitOptions>(Init)
                .WithParsed<RunOptions>(Run);
        }

        public static void Init(InitOptions options)
        {
            const long gb = 1_000_000_000;
            _log = new ConsoleLog();
            _log.Log(LogSeverity.Info, " ### Initialize CashDB using config file ### ");
            var config = CashDBConfigReader.Read(options.ConfigFullPath);
            CashDBInstance.InitializeFiles(config, options.Layer1SizeInGB * gb, options.Layer2SizeInGB * gb, _log);
            var instance = new CashDBInstance(_log);
            instance.SetupStores(config);
            _log.Log(LogSeverity.Info, " ### Initialization done. ### ");
        }

        public static void Run(RunOptions options)
        {
            _log = new ConsoleLog();
            _log.Log(LogSeverity.Info, " ### Running the server ### ");
            _log.Log(LogSeverity.Info, $"   ProcessID: {Process.GetCurrentProcess().Id}");

            var config = CashDBConfigReader.Read(options.ConfigFullPath);

            var CashDB = new CashDBInstance(_log);
            CashDB.SetupNetwork(config);
            CashDB.SetupStores(config);
            CashDB.SetupControllers();

            _log.Log(LogSeverity.Info, $"Starting the server listening to {config.IpAddress} on port {config.Port}");
            CashDB.Start();

            _log.Log(LogSeverity.Info, $"Server started - press Ctrl-C to exit");

            AppDomain.CurrentDomain.ProcessExit += (sender, args) => _log.Log(LogSeverity.Info, "App domain exit");

            var readLoop = new CancellationTokenSource();
            Console.CancelKeyPress += (o, args) =>
            {
                CashDB.Stop();
                readLoop.Cancel();
            };
            try
            {
                while (!readLoop.IsCancellationRequested)
                {
                    Console.ReadKey();
                }
            }
            catch (Exception e)
            {
                _log.Log(LogSeverity.Error, "an error occurred");
                _log.Log(LogSeverity.Error, e.Message);
            }
            finally
            {
                _log.Log(LogSeverity.Info, "bye bye");
            }
        }
    }
}