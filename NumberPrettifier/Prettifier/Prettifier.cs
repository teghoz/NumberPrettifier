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
        internal IPrettifierDictionaryServiceFactory _prettifierDictionaryServiceFactory;
        public virtual string? Pretty(double number, string? type)
        {
            _prettifierDictionary = _prettifierDictionaryServiceFactory.GetPrettifierDictionary(type);

            if (_prettifierDictionary == null)
            {
                throw new Exception($"Prettifier Dictionary must be available");
            }           

            var stringbuilder = new StringBuilder();

            if (number.Equals(0))
            {
                return _prettifierDictionary.GetWord(0);
            }

            if (number < 0)
            {
                return $"minus {Pretty(Math.Abs(number), type)}";
            }

            if (Math.Floor(number / 1_000_000_000_000) > 0)
            {
                stringbuilder.Append($"{Pretty(Math.Floor(number / 1_000_000_000_000), type)} {_prettifierDictionary.GetWord(1_000_000_000_000)}, ");
                number %= 1_000_000_000_000;
            }

            if ((int)(number / 1_000_000_000) > 0)
            {
                stringbuilder.Append($"{Pretty(Math.Floor(number / 1_000_000_000), type)} {_prettifierDictionary.GetWord(1_000_000_000)}, ");
                number %= 1_000_000_000;
            }

            if ((int)(number / 1_000_000) > 0)
            {
                stringbuilder.Append($"{Pretty(Math.Floor(number / 1_000_000), type)} {_prettifierDictionary.GetWord(1_000_000)}, ");
                number %= 1_000_000;
            }

            if ((int)(number / 1_000) > 0)
            {
                stringbuilder.Append($"{Pretty(Math.Floor(number / 1_000), type)} {_prettifierDictionary.GetWord(1_000)} ");
                number %= 1_000;
            }

            if ((int)(number / 100) > 0)
            {
                stringbuilder.Append($"{Pretty(Math.Floor(number / 100), type)} {_prettifierDictionary.GetWord(100)}");
                number %= 100;
            }

            if (number > 0)
            {
                if (!string.IsNullOrEmpty(stringbuilder.ToString()))
                {
                    stringbuilder.Append($" {_prettifierDictionary.GetWord(-1)} ");
                }

                if (number < 20)
                {
                    stringbuilder.Append(_prettifierDictionary.GetWord((int)number));
                }
                else
                {
                    stringbuilder.Append(_prettifierDictionary.GetWord((int)number / 10));
                    if ((number % 10) > 0)
                    {
                        stringbuilder.Append($"-{_prettifierDictionary.GetWord((int)number % 10)}");
                    }
                }
            }

            return stringbuilder.ToString();
        }
    }
}
