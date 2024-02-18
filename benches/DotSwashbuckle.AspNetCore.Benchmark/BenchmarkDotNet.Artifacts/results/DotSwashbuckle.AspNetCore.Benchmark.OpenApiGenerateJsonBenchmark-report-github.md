```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.22631.3007/23H2/2023Update/SunValley3)
11th Gen Intel Core i7-11800H 2.30GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 8.0.200-preview.23624.5
  [Host] : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX-512F+CD+BW+DQ+VL+VBMI

WarmupCount=2  

```
| Method                  | Mean | Error |
|------------------------ |-----:|------:|
| DotSwashbuckleOpenApiV2 |   NA |    NA |

Benchmarks with issues:
  OpenApiGenerateJsonBenchmark.DotSwashbuckleOpenApiV2: Job-CSDBES(WarmupCount=2)
