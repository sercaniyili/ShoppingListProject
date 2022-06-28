using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teleperformance.Bootcamp.Domain.Common;

namespace Teleperformance.Bootcamp.Domain.Entities
{
    public class Category : IBaseEntity
    {
        public string Name { get; set; }
        public int Id { get ; set ; }
        public DateTime CreateDate { get; set ; }
    }
}
