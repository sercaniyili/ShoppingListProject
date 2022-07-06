using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teleperformance.Bootcamp.Domain.Entities;

namespace Teleperformance.Bootcamp.Application.DTOs.ShoppingList
{
      
    public class ShoppingListToBsonDto
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public bool IsComplete { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public DateTime? CompleteDate { get; set; }
        public List<Product> Products { get; set; }
        public string CategoryId { get; set; }
        public string AppUserId { get; set; }

    }
}
