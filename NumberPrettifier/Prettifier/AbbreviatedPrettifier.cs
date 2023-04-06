using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prettifier
{
    public class AbbreviatedPrettifier : Prettifier
    {
        public override string Pretty(double number, string? type = null)
        {
            var abbreviations = new List<string>() { "", "K", "M", "B", "T" };
            var abbreviationIndex = 0;
            var floatingNumber = (float)number;
            var thousand = 1000f;

            while(floatingNumber >= thousand && abbreviationIndex < abbreviations.Count - 1)
            {
                floatingNumber /= thousand;
                abbreviationIndex++;
            }

            floatingNumber = (float)Math.Round(floatingNumber, 1);
            return $"{floatingNumber}{abbreviations[abbreviationIndex]}";
        }
    }
}
