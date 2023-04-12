using Prettifier.Interfaces;
using System.Text;

namespace Prettifier.Locales.fr;

public class FrenchFullWordPrettifier : Prettifier
{
    public FrenchFullWordPrettifier(IPrettifierDictionaryServiceFactory prettifierDictionaryServiceFactory)
    {
        _prettifierDictionaryServiceFactory = prettifierDictionaryServiceFactory;
    }

    public override string? Pretty(decimal number, string? type = null)
    {
        _prettifierDictionary = _prettifierDictionaryServiceFactory?.GetPrettifierDictionary(type);

        if (_prettifierDictionary == null)
        {
            throw new Exception("Prettifier Dictionary must be available");
        }

        var stringBuilder = new StringBuilder();

        if (number.Equals(0))
        {
            return _prettifierDictionary.GetWord(0);
        }

        if (Math.Floor(number / 1_000_000_000_000) > 0)
        {
            stringBuilder.Append($"{Pretty(Math.Floor(number / 1_000_000_000_000), type)} {_prettifierDictionary.GetWord(1_000_000_000_000)} ");
            number %= 1_000_000_000_000;
        }

        if (Math.Floor(number / 1_000_000_000) > 0)
        {
            stringBuilder.Append($"{Pretty(Math.Floor(number / 1_000_000_000), type)} {_prettifierDictionary.GetWord(1_000_000_000)} ");
            number %= 1_000_000_000;
        }

        if (Math.Floor(number / 1_000_000) > 0)
        {
            stringBuilder.Append($"{Pretty(Math.Floor(number / 1_000_000), type)} {_prettifierDictionary.GetWord(1_000_000)} ");
            number %= 1_000_000;
        }

        if (Math.Floor(number / 1_000) > 0)
        {
            stringBuilder.Append($"{Pretty(Math.Floor(number / 1_000), type)} {_prettifierDictionary.GetWord(1_000)} ");
            number %= 1_000;
        }

        if (Math.Floor(number / 100) > 0)
        {
            stringBuilder.Append($"{Pretty(Math.Floor(number / 100), type)} {_prettifierDictionary.GetWord(100)}");
            number %= 100;
        }

        if (number > 0)
        {
            if (!string.IsNullOrEmpty(stringBuilder.ToString()))
            {
                stringBuilder.Append($" {_prettifierDictionary.GetWord(-1)} ");
            }

            if (number < 20)
            {
                stringBuilder.Append(_prettifierDictionary.GetWord((int)number));
            }
            else
            {
                stringBuilder.Append(_prettifierDictionary.GetWord((int)number / 10));
                if (number % 10 > 0)
                {
                    stringBuilder.Append($"-{_prettifierDictionary.GetWord((int)number % 10)}");
                }
            }
        }

        return stringBuilder.ToString();
    }
}