namespace DevHorizons.Ark.Dev.Benchmark
{
    using BenchmarkDotNet.Attributes;
    using TurboCode;

    [MemoryDiagnoser]
    // [ThreadingDiagnoser]
    // [SimpleJob(BenchmarkDotNet.Engines.RunStrategy.Throughput, 10, 10, 10)]
    public class SplitLeftBenchmark
    {
        private string source = "HelloWorldJanHelloWorldFebHelloWorldMarHelloWorldAprilHelloWorldMayHelloWorldJuneHelloWorldJulyHelloWorldAugustHelloWorldSeptemberHelloWorldOctoberHelloWorldNovemberHelloWorldDecemberHelloWorld";

        //[Benchmark]
        public ICollection<string> TestOOTBSplit()
        {
            return this.source.Split(new string[] { "HelloWorld" }, StringSplitOptions.None);
            /*
|                                    Method |     Mean |   Error |   StdDev |   Median |   Gen0 | Completed Work Items | Lock Contentions | Allocated |
|------------------------------------------ |---------:|--------:|---------:|---------:|-------:|---------------------:|-----------------:|----------:|
|                             TestOOTBSplit | 325.8 ns | 4.44 ns | 12.82 ns | 321.3 ns | 0.0706 |                    - |                - |     592 B |
| TestSplitLeftOrdinalComparisonSpanOrdinal | 698.0 ns | 5.79 ns | 16.78 ns | 693.0 ns | 0.0734 |                    - |                - |     616 B |             
             */
        }

        //[Benchmark]
        public ReadOnlySpan<string> TestSplitLeftOrdinalComparisonSpanOrdinal()
        {
            return this.source.SplitLeftOrdinalComparisonSpan("HelloWorld");
            /*
|                                    Method |     Mean |   Error |   StdDev |   Median | Completed Work Items | Lock Contentions |   Gen0 | Allocated |
|------------------------------------------ |---------:|--------:|---------:|---------:|---------------------:|-----------------:|-------:|----------:|
| TestSplitLeftOrdinalComparisonList        | 821.5 ns | 4.56 ns | 12.92 ns | 817.4 ns |                    - |                - | 0.1059 |     888 B |
| TestSplitLeftOrdinalComparisonSpan        | 715.0 ns | 2.71 ns | 7.81 ns  |          |                    - |                - | 0.0734 |     616 B |
             
             
             
             */
        }


        [Benchmark]
        [Arguments("HelloWorldJanHelloWorldFebHelloWorldMarHelloWorldAprilHelloWorldMayHelloWorldJuneHelloWorldJulyHelloWorldAugustHelloWorldSeptemberHelloWorldOctoberHelloWorldNovemberHelloWorldDecemberHelloWorld", 3, 20)]
        public string SubStringSpan(string source, int index, int length)
        {
            return source.AsSpan().Slice(index, length).ToString();
        }


        [Benchmark]
        [Arguments("HelloWorldJanHelloWorldFebHelloWorldMarHelloWorldAprilHelloWorldMayHelloWorldJuneHelloWorldJulyHelloWorldAugustHelloWorldSeptemberHelloWorldOctoberHelloWorldNovemberHelloWorldDecemberHelloWorld", 3, 20)]
        public unsafe string SubStringPointer(string source, int index, int length)
        {
            Span<char> resultSpan = stackalloc char[length];

            fixed (char* ptr = source)
            {
                for (int i = index; i < index + length; i++)
                {
                    resultSpan[i - index] = ptr[i];
                }

            }

            return resultSpan.ToString();
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
