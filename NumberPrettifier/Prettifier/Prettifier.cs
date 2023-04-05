using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prettifier.Interfaces;

namespace Prettifier
{
    public abstract class Prettifier : IPrettifier
    {
        internal IPrettifierDictionary? _prettifierDictionary;
        public virtual string? Pretty(double number)
        {
            if (_prettifierDictionary == null)
            {
                throw new Exception($"Prettifier Dictionary must be available");
            }

            var stringbuilder = new StringBuilder();
            var numberIsGreaterThanZero = number > 0;
            var numberIsLessThanTwenty = number < 20;
            var numberIsDivisibleByAMillionAtLeastOnce = (number / 1_000_000) > 0;
            var numberIsDivisibleByAThousandAtLeastOnce = (number / 1_000) > 0;
            var numberIsDivisibleByAHundredAtLeastOnce = (number / 100) > 0;

            if (number.Equals(0))
            {
                return _prettifierDictionary.GetWord(0);
            }

            if (number < 0)
            {
                return $"minus {Pretty(Math.Abs(number))}";
            }

            if (numberIsDivisibleByAMillionAtLeastOnce)
            {
                stringbuilder.Append($"{Pretty(number / 1_000_000)} {_prettifierDictionary.GetWord(1_000_000)} ");
                number %= 1000000;
            }

            if (numberIsDivisibleByAThousandAtLeastOnce)
            {
                stringbuilder.Append($"{Pretty(number / 1_000)} {_prettifierDictionary.GetWord(1_000)} ");
                number %= 1000;
            }

            if (numberIsDivisibleByAHundredAtLeastOnce)
            {
                stringbuilder.Append($"{Pretty(number / 100)} {_prettifierDictionary.GetWord(100)} ");
                number %= 100;
            }

            if (numberIsGreaterThanZero)
            {
                if (!string.IsNullOrEmpty(stringbuilder.ToString()))
                {
                    stringbuilder.Append("and ");
                }

                if (numberIsLessThanTwenty)
                {
                    stringbuilder.Append(_prettifierDictionary.GetWord((int)number));
                }
                else
                {
                    stringbuilder.Append(_prettifierDictionary.GetWord((int)number / 10));
                    if ((number % 10) > 0)
                    {
                        stringbuilder.Append($"- {_prettifierDictionary.GetWord((int)number % 10)}");
                    }
                }
            }

            return stringbuilder.ToString();
        }
    }
}
