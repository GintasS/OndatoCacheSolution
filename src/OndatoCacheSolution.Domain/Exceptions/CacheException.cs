using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OndatoCacheSolution.Domain.Exceptions
{
    public class CacheException : Exception
    {
        public CacheException(string message) : base(message)
        {

        }
    }
}
