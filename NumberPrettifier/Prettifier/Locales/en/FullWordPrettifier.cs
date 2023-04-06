using Prettifier.Interfaces;

namespace Prettifier.Locales.en;

public class FullWordPrettifier : Prettifier
{
    public FullWordPrettifier(IPrettifierDictionaryServiceFactory prettifierDictionaryServiceFactory)
    {
        _prettifierDictionaryServiceFactory = prettifierDictionaryServiceFactory;
    }
}