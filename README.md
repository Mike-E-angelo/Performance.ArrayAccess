# Performance.ArrayAccess

Checking out this nifty nugget here:
https://twitter.com/SergioPedri/status/1228752877604265985


```
// * Summary *

BenchmarkDotNet=v0.12.0, OS=Windows 10.0.18363
AMD Ryzen 7 2700X, 1 CPU, 8 logical and 8 physical cores
.NET Core SDK=3.1.101
  [Host]     : .NET Core 3.1.1 (CoreCLR 4.700.19.60701, CoreFX 4.700.19.60801), X64 RyuJIT
  DefaultJob : .NET Core 3.1.1 (CoreCLR 4.700.19.60701, CoreFX 4.700.19.60801), X64 RyuJIT


| Method |     Mean |   Error |  StdDev | Ratio | RatioSD |
|------- |---------:|--------:|--------:|------:|--------:|
| Access | 462.4 ns | 7.14 ns | 6.68 ns |  1.28 |    0.03 |
|  Magic | 361.5 ns | 6.20 ns | 5.80 ns |  1.00 |    0.00 |
```