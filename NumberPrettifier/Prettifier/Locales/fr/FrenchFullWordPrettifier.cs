﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Prettifier.Interfaces;

namespace Prettifier.Locales.fr
{
    public class FrenchFullWordPrettifier : Prettifier
    {
        public FrenchFullWordPrettifier(IPrettifierDictionary prettifierDictionary)
        {
            _prettifierDictionary = prettifierDictionary;
        }

        public override string? Pretty(double number)
        {
            if (_prettifierDictionary == null)
            {
                throw new Exception($"Prettifier Dictionary must be available");
            }

            var stringbuilder = new StringBuilder();

            if (number.Equals(0))
            {
                return _prettifierDictionary.GetWord(0);
            }

            if ((int)(number / 1_000_000_000_000) > 0)
            {
                stringbuilder.Append($"{Pretty(number / 1_000_000_000_000)} {_prettifierDictionary.GetWord(1_000_000_000_000)} ");
                number %= 1_000_000_000_000;
            }

            if ((int)(number / 1_000_000_000) > 0)
            {
                stringbuilder.Append($"{Pretty(number / 1_000_000_000)} {_prettifierDictionary.GetWord(1_000_000_000)} ");
                number %= 1_000_000_000;
            }

            if ((int)(number / 1_000_000) > 0)
            {
                stringbuilder.Append($"{Pretty(number / 1_000_000)} {_prettifierDictionary.GetWord(1_000_000)} ");
                number %= 1_000_000;
            }

            if ((int)(number / 1_000) > 0)
            {
                stringbuilder.Append($"{Pretty(number / 1_000)} {_prettifierDictionary.GetWord(1_000)} ");
                number %= 1_000;
            }

            if ((int)(number / 100) > 0)
            {
                stringbuilder.Append($"{Pretty(number / 100)} {_prettifierDictionary.GetWord(100)}");
                number %= 100;
            }

            if (number > 0)
            {
                if (!string.IsNullOrEmpty(stringbuilder.ToString()))
                {
                    stringbuilder.Append("and ");
                }

                if (number < 20)
                {
                    stringbuilder.Append(_prettifierDictionary.GetWord((int)number));
                }
                else
                {
                    stringbuilder.Append(_prettifierDictionary.GetWord((int)number / 10));
                    if (number % 10 > 0)
                    {
                        stringbuilder.Append($"- {_prettifierDictionary.GetWord((int)number % 10)}");
                    }
                }
            }

            return stringbuilder.ToString();
        }
    }
}
