using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teleperformance.Bootcamp.Application.DTOs.ShoppingList
{
    public class UpdateIsCompleteDto
    {
        public string Id { get; set; }
        public bool IsComplete { get; set; }
        public DateTime? CompleteDate { get; set; } = DateTime.Now;
    }
}
