using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Prettifier.Interfaces;

namespace Prettifier.Locales.en
{
    public class FullWordPrettifier : Prettifier
    {
        public FullWordPrettifier(IPrettifierDictionaryServiceFactory prettifierDictionaryServiceFactory)
        {
            _prettifierDictionaryServiceFactory = prettifierDictionaryServiceFactory;
        }
    }
}
