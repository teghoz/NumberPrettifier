using BenchmarkDotNet.Attributes;

namespace Prettifier
{
    [MemoryDiagnoser]
    public class AbbreviatedPrettifier : Prettifier
    {
        [Benchmark(Baseline = true)]
        [Arguments(1_000_000_000_000, "en")]
        [Arguments(1_000_000_000_000, "fr")]
        [Arguments(1_000_000_000_000, "abbrev")]

        public override string Pretty(decimal number, string? type = null)
        {
            var abbreviations = new List<string> { "", "", "M", "B", "T" };
            var abbreviationIndex = 0;
            const decimal thousand = 1_000;
            const decimal million = 1_000_000m;
            
            if (number < million)
            {
                return $"{Math.Truncate(number * 10) / 10}{abbreviations[abbreviationIndex]}";
            }

            while (number >= thousand && abbreviationIndex < abbreviations.Count - 1)
            {
                number /= thousand;
                abbreviationIndex++;
            }
            
            return $"{Math.Truncate(number * 10) / 10}{abbreviations[abbreviationIndex]}";
        }
    }
}
