using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teleperformance.Bootcamp.Domain.Common
{
    public class SearchQueryParameters
    {
        public string? ListName { get; set; }
        public string? CategoryName { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? CompleteDate { get; set; }
    }
}
