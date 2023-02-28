using AutoMapper;
using Moq;
using Teleperformance.Bootcamp.Application.DTOs.ShoppingList;
using Teleperformance.Bootcamp.Application.Features.Commands.ShoppingList.ShoppingListUpdateIsComplete;
using Teleperformance.Bootcamp.Application.Interfaces.MessageBrokers;
using Teleperformance.Bootcamp.Application.Interfaces.Repositories;
using Teleperformance.Bootcamp.Application.Mappings;
using Teleperformance.Bootcamp.Domain.Common.Response;

namespace ShoppingListProject.Test.ShoppingList
{
    public class ShoppingListUpdateIsCompleteCommandHandlerTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<IShoppingListRepository> _mockShoppingListRepository;
        private readonly Mock<IRabbitmqService> _mockRabbitmqService;

        public ShoppingListUpdateIsCompleteCommandHandlerTest()
        {
            var mapperConfig = new MapperConfiguration(c => { c.AddProfile<MappingProfile>(); });
            _mapper = mapperConfig.CreateMapper();
            _mockShoppingListRepository = new();
            _mockRabbitmqService = new();
        }

        [Fact]
        public async Task Handle_ShoppingListDoesNotExist_ReturnsBaseResponseFail()
        {
            //Arrange

            var products = new List<Teleperformance.Bootcamp.Domain.Entities.Product>();
            products.Add(new Teleperformance.Bootcamp.Domain.Entities.Product
            {
                Id = "1",
                Name = "Lorem",
                ShoppingListId = "0",
                CreateDate = DateTime.Now
            }); 
           

            Teleperformance.Bootcamp.Domain.Entities.ShoppingList shoppingList =
              new Teleperformance.Bootcamp.Domain.Entities.ShoppingList
              {
                  Title = "LoremIpsum",
                  Id = "1",
                  Description = "LoremIpsum",
                  IsComplete = true,
                  CompleteDate = DateTime.Now,
                  CategoryId = "1",
                  AppUserId = "1",
                  AppUser = new Teleperformance.Bootcamp.Domain.Entities.Identity.AppUser{ },
                  Category = new Teleperformance.Bootcamp.Domain.Entities.Category { Id ="1", Name = "Lorem"},
                  CreateDate = DateTime.Now,
                  Products = products
              };


            var handler = new ShoppingListUpdateIsCompleteCommandHandler(
                    _mockShoppingListRepository.Object,
                    _mapper,
                    _mockRabbitmqService.Object);
                                                         

            ShoppingListUpdateIsCompleteCommandRequest request = new ShoppingListUpdateIsCompleteCommandRequest
            {
                UpdateIsCompleteDto = new UpdateIsCompleteDto
                {
                    Id = "0",
                    CompleteDate = DateTime.Now,
                    IsComplete = true,
                }
            };

            _mockShoppingListRepository.Setup(x => x.GetShoppingListById(shoppingList.Id))
                .ReturnsAsync(shoppingList);

            //Act

            BaseResponse response = await handler.Handle(request, default);

            //Assert

            Assert.False(response.IsSuccess);
            Assert.Equal("Liste bulunamadı",response.Message);

        }

        [Fact]
        public async Task Handle_ShoppingListExist_BaseReseResponseSuccess()
        {
            //Arrange

            var products = new List<Teleperformance.Bootcamp.Domain.Entities.Product>();
            products.Add(new Teleperformance.Bootcamp.Domain.Entities.Product
            {
                Id = "1",
                Name = "Lorem",
                ShoppingListId = "0",
                CreateDate = DateTime.Now
            });


            Teleperformance.Bootcamp.Domain.Entities.ShoppingList shoppingList =
              new Teleperformance.Bootcamp.Domain.Entities.ShoppingList
              {
                  Title = "LoremIpsum",
                  Id = "1",
                  Description = "LoremIpsum",
                  IsComplete = true,
                  CompleteDate = DateTime.Now,
                  CategoryId = "1",
                  AppUserId = "1",
                  AppUser = new Teleperformance.Bootcamp.Domain.Entities.Identity.AppUser { },
                  Category = new Teleperformance.Bootcamp.Domain.Entities.Category { Id = "1", Name = "Lorem" },
                  CreateDate = DateTime.Now,
                  Products = products
              };


            var handler = new ShoppingListUpdateIsCompleteCommandHandler(
                    _mockShoppingListRepository.Object,
                    _mapper,
                    _mockRabbitmqService.Object);


            ShoppingListUpdateIsCompleteCommandRequest request = new ShoppingListUpdateIsCompleteCommandRequest
            {
                UpdateIsCompleteDto = new UpdateIsCompleteDto
                {
                    Id = "1",
                    CompleteDate = DateTime.Now,
                    IsComplete = true,
                }
            };

            _mockShoppingListRepository.Setup(x => x.GetShoppingListById(shoppingList.Id))
                .ReturnsAsync(shoppingList);

            //Act

            BaseResponse response = await handler.Handle(request, default);

            //Assert

            _mockShoppingListRepository.Verify
                (x=> x.Update(It.Is<Teleperformance.Bootcamp.Domain.Entities.ShoppingList>(s=> s.Id == shoppingList.Id)), Times.Once);

            _mockRabbitmqService
                .Verify(x=> x.Publish(It.IsAny<object>(),It.IsAny<string>(),It.IsAny<string>(),It.IsAny<string>(),
                It.IsAny<string?>()),Times.Once);


            Assert.True(response.IsSuccess);
            Assert.Equal("Liste başarıyla tamamlandı", response.Message);

        }

    }
}
