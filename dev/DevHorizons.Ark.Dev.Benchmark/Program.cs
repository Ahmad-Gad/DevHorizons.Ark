// See https://aka.ms/new-console-template for more information
using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Loggers;
using BenchmarkDotNet.Running;
using BenchmarkDotNet.Validators;
using DevHorizons.Ark.Dev.Benchmark;
using DevHorizons.Ark.Dev.TurboCode;
using DevHorizons.Ark.Dev.Validation;

var config = new ManualConfig()
       .WithOptions(ConfigOptions.DisableOptimizationsValidator)
       .AddValidator(JitOptimizationsValidator.DontFailOnError)
       .AddLogger(ConsoleLogger.Default)
       .AddColumnProvider(DefaultColumnProviders.Instance);
//BenchmarkRunner.Run<SplitLeftBenchmark>(config);

var source = "HelloWorldJanHelloWorldFebHelloWorldMarHelloWorldAprilHelloWorldMayHelloWorldJuneHelloWorldJulyHelloWorldAugustHelloWorldSeptemberHelloWorldOctoberHelloWorldNovemberHelloWorldDecemberHelloWorld";
var output = source.SplitLeftOrdinalComparisonMemory("HelloWorld".AsMemory());

Console.WriteLine();
