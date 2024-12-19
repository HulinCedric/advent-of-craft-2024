using BenchmarkDotNet.Attributes;

namespace Travel.Benchmark;

[MemoryDiagnoser]
public class ReindeerDistanceBenchmark
{
    [Params(1, 10, 30, 50)] public int NumberOfReindeers;

    [Benchmark]
    public ulong Recursively()
    {
        return SantaTravelCalculator.CalculateTotalDistanceRecursively(NumberOfReindeers);
    }
    
    [Benchmark]
    public ulong Iterative()
    {
        return SantaTravelCalculator.CalculateTotalDistanceIterative(NumberOfReindeers);
    }

    [Benchmark]
    public ulong Bitwise()
    {
        return SantaTravelCalculator.CalculateTotalDistanceBitwise(NumberOfReindeers);
    }
}