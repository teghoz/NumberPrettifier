# NumberPrettifier


## Problem Statement
Write a number prettifier -
Write tested code (in any language) that accepts a numeric type and returns a truncated, "prettified" string version. The prettified version should include one number after the decimal when the truncated number is not an integer. It should prettify numbers greater than 6 digits and support millions, billions and trillions. 
 
Examples:  

input: 1000000\
output: 1M

input: 2500000.34 \
output: 2.5M

input: 532\
output: 532

input: 1123456789\
output: 1.1B 

### Approach
Core logic can be found in this [folder](https://github.com/teghoz/NumberPrettifier/tree/main/NumberPrettifier/Prettifier).

The design choice was influenced by the SOLID principles. The goal was to build it in such a way that it allowed for extensibility. The abstract class contains the base implementation and other implementations overrides it. As you might have seen from the folder, I have 3 implementations: en, fr and abbrev - which is the original problem statement.

### How To Run

```
 dotnet run -c release
```
With Performance Benchmark before execution
```
 dotnet run -c release -- PerformanceMode=true
```

### Presentation
I created a react-based frontend to visualize the functionality.

<img width="960" alt="image" src="https://user-images.githubusercontent.com/10187133/230438212-48589fa8-727a-4361-bbd2-31d720269c16.png">
<img width="960" alt="image" src="https://user-images.githubusercontent.com/10187133/230437861-ecf5c900-c619-467b-9f4c-d988524ee3b2.png">
<img width="960" alt="image" src="https://user-images.githubusercontent.com/10187133/230437950-fb9ac845-62c1-4cce-800e-c2e84437db0f.png">

### Performance Benchmarks
Demo Project to Pretifier Numbers

```
// * Summary *

BenchmarkDotNet=v0.13.5, OS=Windows 11 (10.0.22621.1413/22H2/2022Update/SunValley2)
12th Gen Intel Core i7-12700H, 1 CPU, 20 logical and 14 physical cores
.NET SDK=7.0.102
  [Host]     : .NET 7.0.2 (7.0.222.60605), X64 RyuJIT AVX2
  DefaultJob : .NET 7.0.2 (7.0.222.60605), X64 RyuJIT AVX2


| Method |        number |   type |     Mean |   Error |  StdDev | Ratio |   Gen0 | Allocated | Alloc Ratio |
|------- |-------------- |------- |---------:|--------:|--------:|------:|-------:|----------:|------------:|
| Pretty | 1000000000000 | abbrev | 130.2 ns | 0.79 ns | 0.70 ns |  1.00 | 0.0007 |     208 B |        1.00 |
|        |               |        |          |         |         |       |        |           |             |
| Pretty | 1000000000000 |     en | 128.9 ns | 1.12 ns | 0.99 ns |  1.00 | 0.0007 |     208 B |        1.00 |
|        |               |        |          |         |         |       |        |           |             |
| Pretty | 1000000000000 |     fr | 128.4 ns | 1.52 ns | 1.35 ns |  1.00 | 0.0007 |     208 B |        1.00 |

// * Hints *
Outliers
  AbbreviatedPrettifier.Pretty: Default -> 1 outlier  was  removed (138.66 ns)
  AbbreviatedPrettifier.Pretty: Default -> 1 outlier  was  removed (135.06 ns)
  AbbreviatedPrettifier.Pretty: Default -> 1 outlier  was  removed (138.87 ns)

// * Legends *
  number      : Value of the 'number' parameter
  type        : Value of the 'type' parameter
  Mean        : Arithmetic mean of all measurements
  Error       : Half of 99.9% confidence interval
  StdDev      : Standard deviation of all measurements
  Ratio       : Mean of the ratio distribution ([Current]/[Baseline])
  Gen0        : GC Generation 0 collects per 1000 operations
  Allocated   : Allocated memory per single operation (managed only, inclusive, 1KB = 1024B)
  Alloc Ratio : Allocated memory ratio distribution ([Current]/[Baseline])
  1 ns        : 1 Nanosecond (0.000000001 sec)
  

// * Diagnostic Output - MemoryDiagnoser *


// ***** BenchmarkRunner: End *****
Run time: 00:00:47 (47.77 sec), executed benchmarks: 3

Global total time: 00:00:51 (51.13 sec), executed benchmarks: 3
// * Artifacts cleanup *

```
