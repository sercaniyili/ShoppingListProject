using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teleperformance.Bootcamp.Domain.Common;
using Teleperformance.Bootcamp.Domain.Entities.Identity;

namespace Teleperformance.Bootcamp.Domain.Entities
{
    public class ShoppingList: IBaseEntity
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }=DateTime.Now;
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsComplete { get; set; }
        public DateTime CompleteDate { get; set; }
        public virtual List<Product> Products { get; set; }

        //nav prop
        public string CategoryId { get; set; }
        public virtual Category Category { get; set; }

        public string AppUserId { get; set; }
        public virtual AppUser AppUser { get; set; }
      
    }
}
