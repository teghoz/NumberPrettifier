using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prettifier.Interfaces
{
    public interface IPrettifierDictionaryServiceFactory
    {
        IPrettifierDictionary GetPrettifierDictionary(string? token);
    }
}
