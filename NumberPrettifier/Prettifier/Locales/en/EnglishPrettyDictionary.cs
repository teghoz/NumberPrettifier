﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prettifier.Interfaces;

namespace Prettifier.Locales.en
{
    public class EnglishPrettyDictionary : IPrettifierDictionary
    {       
        public IDictionary<long, string> GetWordDictionary()
        {
            return new Dictionary<long, string>()
            {
                { 0, "zero" }, { 1, "one" },{ 2, "two" }, { 3, "three" },
                { 4, "four" }, { 5, "five" },{ 6, "six" }, { 7, "seven" },
                { 8, "eight" }, { 9, "nine" },{ 10, "ten" }, { 11, "eleven" },
                { 12, "twelve"}, { 13, "thirteen" }, { 14, "fourteen" }, { 15, "fifteen" },
                { 16, "sixteen"}, { 17, "seventeen" }, { 18, "eighteen" },{ 19, "nineteen"},
                { 20, "twenty" }, { 30, "thirty" }, { 40, "fourty" }, { 50, "fifty" },
                { 60, "sixty" }, { 70, "seventy" }, { 80, "eighty" }, { 90, "ninety" },
                { 100, "hundred" }, { 1_000, "thousand" }, { 1_000_000, "million" }, { 1_000_000_000, "billion" },
                { 1_000_000_000_000, "trillion" }
            };
        }
    }
}
