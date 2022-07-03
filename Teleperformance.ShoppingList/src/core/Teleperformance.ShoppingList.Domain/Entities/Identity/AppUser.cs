using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teleperformance.Bootcamp.Domain.Common;

namespace Teleperformance.Bootcamp.Domain.Entities.Identity
{
    public class AppUser : IdentityUser, IBaseEntity
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public ICollection<ShoppingList> ShoppingLists { get; set; }
    }
}
