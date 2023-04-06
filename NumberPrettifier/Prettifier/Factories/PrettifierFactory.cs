using Prettifier.Interfaces;
using Prettifier.Locales.en;
using Prettifier.Locales.fr;

namespace Prettifier.Factories;

public class PrettifierFactory : IPrettifierServiceFactory
{
    private readonly IEnumerable<IPrettifier> _prettifierServices;

    public PrettifierFactory(IEnumerable<IPrettifier> prettifierServices)
    {
        _prettifierServices = prettifierServices;
    }

    public IPrettifier GetPrettifier(string? token)
    {
        return token switch
        {
            "en" => GetService(typeof(FullWordPrettifier)),
            "fr" => GetService(typeof(FrenchFullWordPrettifier)),
            "abbrev" => GetService(typeof(AbbreviatedPrettifier)),
            _ => GetService(typeof(FullWordPrettifier))
        };
    }

    private IPrettifier GetService(Type type)
    {
        return _prettifierServices.FirstOrDefault(p => p.GetType() == type)!;
    }
}