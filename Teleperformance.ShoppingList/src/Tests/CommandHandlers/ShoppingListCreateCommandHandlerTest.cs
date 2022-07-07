using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teleperformance.Bootcamp.Application.Features.Commands.ShoppingList.ShoppingListCreate;
using Teleperformance.Bootcamp.Application.Interfaces.Repositories;
using Teleperformance.Bootcamp.Domain.Entities;

namespace Tests.CommandHandlers
{
    
    public class ShoppingListCreateCommandHandlerTest
    {
        [Fact]
        public void CreateShoppingList_IsSucces()
        {
            //arrange

            //var mockShoppingListRepository = new Mock<IShoppingListRepository>();
            //mockShoppingListRepository.Setup(x => x.AddAsync(It.IsAny<result>)).ReturnASync(new ShoppingList
            //{
            //    Title = null,
            //    CreateDate = DateTime.Now,
            //    Id = Guid.NewGuid().ToString()
            //});


            //var MockCache=new Mock<>

            //var command = new ShoppingListCreateCommandHandler(mockShoppingListRepository.Object);

        }

    }
}
