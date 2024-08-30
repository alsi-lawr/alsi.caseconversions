using System.Buffers;
using System.Globalization;
using ALSI.CaseConversions;
using ALSI.CaseConversions.IntegrationTests;
using BenchmarkDotNet.Running;

BenchmarkRunner.Run<SnakeCaseFormatterTests>();

//ALSI.CaseConversions.SnakeCase.Converter.ToSnakeCase("Test String");
