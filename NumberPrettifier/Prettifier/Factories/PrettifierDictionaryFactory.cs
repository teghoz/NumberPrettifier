using Prettifier.Interfaces;
using Prettifier.Locales.en;
using Prettifier.Locales.fr;

namespace Prettifier.Factories;

public class PrettifierDictionaryFactory : IPrettifierDictionaryServiceFactory
{
    private readonly IEnumerable<IPrettifierDictionary>? _prettifierServices;

    public PrettifierDictionaryFactory(IEnumerable<IPrettifierDictionary>? prettifierServices)
    {
        _prettifierServices = prettifierServices;
    }

    public IPrettifierDictionary? GetPrettifierDictionary(string? token)
    {
        return token switch
        {
            "en" => GetService(typeof(EnglishPrettyDictionary)),
            "fr" => GetService(typeof(FrenchPrettyDictionary)),
            _ => GetService(typeof(EnglishPrettyDictionary))
        };
    }

    private IPrettifierDictionary GetService(Type type)
    {
        return _prettifierServices?.FirstOrDefault(p => p.GetType() == type)!;
    }
}