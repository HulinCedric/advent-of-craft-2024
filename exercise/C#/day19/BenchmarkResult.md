BenchmarkDotNet v0.14.0, macOS Sequoia 15.1.1 (24B91) [Darwin 24.1.0]
Apple M2 Pro, 1 CPU, 10 logical and 10 physical cores
.NET SDK 9.0.101
[Host]     : .NET 8.0.2 (8.0.224.6711), Arm64 RyuJIT AdvSIMD
DefaultJob : .NET 8.0.2 (8.0.224.6711), Arm64 RyuJIT AdvSIMD


| Method      | NumberOfReindeers | Mean       | Error     | StdDev    | Median     | Allocated |
|------------ |------------------ |-----------:|----------:|----------:|-----------:|----------:|
| Recursively | 1                 |  0.4985 ns | 0.0060 ns | 0.0053 ns |  0.4976 ns |         - |
| Iteratively | 1                 |  0.5067 ns | 0.0081 ns | 0.0072 ns |  0.5050 ns |         - |
| Math        | 1                 |  3.5821 ns | 0.0153 ns | 0.0128 ns |  3.5802 ns |         - |
| Bitwise     | 1                 |  0.0059 ns | 0.0065 ns | 0.0060 ns |  0.0041 ns |         - |
| Recursively | 10                |  7.2116 ns | 0.1542 ns | 0.2260 ns |  7.0904 ns |         - |
| Iteratively | 10                |  3.9573 ns | 0.0865 ns | 0.1646 ns |  3.8876 ns |         - |
| Math        | 10                |  3.5675 ns | 0.0132 ns | 0.0110 ns |  3.5649 ns |         - |
| Bitwise     | 10                |  0.0018 ns | 0.0022 ns | 0.0017 ns |  0.0013 ns |         - |
| Recursively | 30                | 32.5865 ns | 0.2530 ns | 0.2367 ns | 32.5781 ns |         - |
| Iteratively | 30                |  9.5020 ns | 0.0165 ns | 0.0146 ns |  9.4976 ns |         - |
| Math        | 30                |  3.5632 ns | 0.0114 ns | 0.0089 ns |  3.5650 ns |         - |
| Bitwise     | 30                |  0.0004 ns | 0.0005 ns | 0.0005 ns |  0.0000 ns |         - |
| Recursively | 50                | 67.5371 ns | 0.1516 ns | 0.1183 ns | 67.5070 ns |         - |
| Iteratively | 50                | 19.5186 ns | 0.0773 ns | 0.0685 ns | 19.5102 ns |         - |
| Math        | 50                |  3.5441 ns | 0.0091 ns | 0.0085 ns |  3.5434 ns |         - |
| Bitwise     | 50                |  0.0135 ns | 0.0156 ns | 0.0146 ns |  0.0060 ns |         - |
