using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teleperformance.Bootcamp.Domain.Common
{
    public interface IBaseEntity
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }

    }
}
