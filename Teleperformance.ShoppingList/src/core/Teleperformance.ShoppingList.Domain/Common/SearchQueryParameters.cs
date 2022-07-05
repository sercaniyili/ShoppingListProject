using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teleperformance.Bootcamp.Domain.Common
{
    public class SearchQueryParameters
    {
        public string? Keyword { get; set; }
        public DateTime? Date { get; set; }
    }
}
