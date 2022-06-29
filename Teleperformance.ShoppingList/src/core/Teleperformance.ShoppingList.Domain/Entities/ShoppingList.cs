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
        public DateTime CreateDate { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsComplete { get; set; }
        public DateTime CompleteDate { get; set; }
        public List<Product> Products { get; set; }

        //nav prop
        public string CategoryId { get; set; }
        public Category Category { get; set; }

        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }
      
    }
}
