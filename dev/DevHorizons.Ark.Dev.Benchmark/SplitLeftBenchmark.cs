namespace DevHorizons.Ark.Dev.Benchmark
{
    using BenchmarkDotNet.Attributes;
    using TurboCode;

    [MemoryDiagnoser]
    [ThreadingDiagnoser]
    [SimpleJob(BenchmarkDotNet.Engines.RunStrategy.Throughput, 10, 10, 10)]
    public class SplitLeftBenchmark
    {
        private string source = "HelloWorldJanHelloWorldFebHelloWorldMarHelloWorldAprilHelloWorldMayHelloWorldJuneHelloWorldJulyHelloWorldAugustHelloWorldSeptemberHelloWorldOctoberHelloWorldNovemberHelloWorldDecemberHelloWorld";

        [Benchmark]
        public ICollection<string> TestOOTBSplit()
        {
            return this.source.Split(new string[] { "HelloWorld" }, StringSplitOptions.None);
        }

        [Benchmark]
        public ReadOnlySpan<string> TestSplitLeftOrdinalComparisonSpanOrdinal()
        {
            return this.source.SplitLeftOrdinalComparisonSpan("HelloWorld");
        }

        [Benchmark]
        public ReadOnlyMemory<string> TestSplitLeftOrdinalComparisonMemory()
        {
            return this.source.SplitLeftOrdinalComparisonMemory("HelloWorld".AsMemory());
        }

        //[Benchmark]
        public ReadOnlySpan<string> TestSplitLeftOrdinalComparisonSpanInvariantCulture()
        {
            return this.source.SplitLeftOrdinalComparisonSpan("HelloWorld", StringComparison.InvariantCulture);
        }

       

        // [Benchmark]
        public ICollection<string>? TestSplitLeft()
        {
            return this.source.SplitLeft("HelloWorld");
        }

        //[Benchmark]
        public ICollection<string>? TestSplitLeftOrdinalComparison()
        {
           return this.source.SplitLeftOrdinalComparison("HelloWorld");
        }

        //[Benchmark]
        public ICollection<string>? TestSplitLeftOrdinalComparisonInternal()
        {
            return this.source.SplitLeftOrdinalComparisonInternal("HelloWorld");
        }



      
    }
}
