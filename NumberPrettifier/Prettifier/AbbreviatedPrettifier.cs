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

        public override string Pretty(double number, string? type = null)
        {
            var abbreviations = new List<string>() { "", "K", "M", "B", "T" };
            var abbreviationIndex = 0;
            var floatingNumber = (float)number;
            const float thousand = 1000f;

            while (floatingNumber >= thousand && abbreviationIndex < abbreviations.Count - 1)
            {
                floatingNumber /= thousand;
                abbreviationIndex++;
            }

            floatingNumber = (float)Math.Round(floatingNumber, 1);
            return $"{floatingNumber}{abbreviations[abbreviationIndex]}";
        }
    }
}
