namespace Prettifier.Interfaces;

public interface IPrettifierDictionaryServiceFactory
{
    IPrettifierDictionary? GetPrettifierDictionary(string? token);
}