using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teleperformance.Bootcamp.Domain.Enums;

namespace Teleperformance.Bootcamp.Application.DTOs.Products
{
    public class AddProductDto
    {
        public int ShoppingListId { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public Unit Unit { get; set; }
        public bool IsBuy { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;

    }
}
