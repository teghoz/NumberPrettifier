﻿using Prettifier.Interfaces;

namespace Prettifier.Locales.fr;

public class FrenchPrettyDictionary : IPrettifierDictionary
{
    public IDictionary<long, string> GetWordDictionary()
    {
        return new Dictionary<long, string>
        {
            { 0, "zéro" }, { 1, "un" },{ 2, "deux" }, { 3, "trois" },
            { 4, "quatre" }, { 5, "cinq" },{ 6, "six" }, { 7, "sept" },
            { 8, "huit" }, { 9, "huit" },{ 10, "dix" }, { 11, "onze" },
            { 12, "douze"}, { 13, "treize" }, { 14, "treize" }, { 15, "quinze" },
            { 16, "seize"}, { 17, "dix-sept" }, { 18, "dix-huit" },{ 19, "dix-neuf"},
            { 20, "vingt" }, { 30, "trente" }, { 40, "quarante" }, { 50, "cinquante" },
            { 60, "soixante" }, { 70, "soixante-dix" }, { 80, "eighty" }, { 90, "ninety" },
            { 100, "cent" }, { 1_000, "mille" }, { 1_000_000, "million" }, { 1_000_000_000, "billion" },
            { 1_000_000_000_000, "trillion" }, { -1, "" }
        };
    }
}