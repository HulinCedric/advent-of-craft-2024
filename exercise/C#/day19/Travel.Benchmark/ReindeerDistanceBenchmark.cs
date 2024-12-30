using BenchmarkDotNet.Attributes;

namespace Travel.Benchmark;

[MemoryDiagnoser]
public class ReindeerDistanceBenchmark
{
    [Params(1, 10, 30, 50)] public int NumberOfReindeers;

    [Benchmark]
    public ulong Recursively() => SantaTravelCalculator.CalculateTotalDistanceRecursively(NumberOfReindeers);

    [Benchmark]
    public ulong Iteratively() => SantaTravelCalculator.CalculateTotalDistanceIteratively(NumberOfReindeers);

    [Benchmark]
    public ulong Math() => SantaTravelCalculator.CalculateTotalDistanceMath(NumberOfReindeers);

    [Benchmark]
    public ulong Bitwise() => SantaTravelCalculator.CalculateTotalDistanceBitwise(NumberOfReindeers);
}