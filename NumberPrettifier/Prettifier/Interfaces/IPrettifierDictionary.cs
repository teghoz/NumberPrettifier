using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prettifier.Interfaces
{
    public interface IPrettifierDictionary
    {
        IDictionary<long, string> GetWordDictionary();
        string? GetWord(long key)
        {
            GetWordDictionary().TryGetValue(key, out var word);
            return word;
        }
    }
}