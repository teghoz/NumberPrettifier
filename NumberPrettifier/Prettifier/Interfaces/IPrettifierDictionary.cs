namespace Prettifier.Interfaces;

public interface IPrettifierDictionary
{
    IDictionary<long, string> GetWordDictionary();
    string? GetWord(long key)
    {
        GetWordDictionary().TryGetValue(key, out var word);
        return word;
    }
}