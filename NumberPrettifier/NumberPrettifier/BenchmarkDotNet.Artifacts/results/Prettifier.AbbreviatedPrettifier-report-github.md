``` ini

BenchmarkDotNet=v0.13.5, OS=Windows 11 (10.0.22621.1413/22H2/2022Update/SunValley2)
12th Gen Intel Core i7-12700H, 1 CPU, 20 logical and 14 physical cores
.NET SDK=7.0.102
  [Host]     : .NET 7.0.2 (7.0.222.60605), X64 RyuJIT AVX2
  DefaultJob : .NET 7.0.2 (7.0.222.60605), X64 RyuJIT AVX2


```
| Method |        number |   type |     Mean |   Error |  StdDev | Ratio |   Gen0 | Allocated | Alloc Ratio |
|------- |-------------- |------- |---------:|--------:|--------:|------:|-------:|----------:|------------:|
| **Pretty** | **1000000000000** | **abbrev** | **130.2 ns** | **0.79 ns** | **0.70 ns** |  **1.00** | **0.0007** |     **208 B** |        **1.00** |
|        |               |        |          |         |         |       |        |           |             |
| **Pretty** | **1000000000000** |     **en** | **128.9 ns** | **1.12 ns** | **0.99 ns** |  **1.00** | **0.0007** |     **208 B** |        **1.00** |
|        |               |        |          |         |         |       |        |           |             |
| **Pretty** | **1000000000000** |     **fr** | **128.4 ns** | **1.52 ns** | **1.35 ns** |  **1.00** | **0.0007** |     **208 B** |        **1.00** |
