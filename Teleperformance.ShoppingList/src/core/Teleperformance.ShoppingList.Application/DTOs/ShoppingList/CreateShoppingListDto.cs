using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teleperformance.Bootcamp.Application.DTOs.ShoppingList
{
    public class CreateShoppingListDto
    {
        public string Title { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public string Description { get; set; }
        public int CategoryId { get; set; }
        //public Guid AppUserId { get; set; }
    }
}
