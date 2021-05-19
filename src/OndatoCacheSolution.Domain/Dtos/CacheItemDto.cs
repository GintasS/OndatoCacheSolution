using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OndatoCacheSolution.Domain.Dtos
{
    public class CacheItemDto
    {
        public string Key { get; set; }

        public List<object> Values { get; set; }

        public TimeSpan? Offset { get; set; }
    }
}
