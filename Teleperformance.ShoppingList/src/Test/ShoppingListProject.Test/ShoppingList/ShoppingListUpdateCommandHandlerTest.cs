using AutoMapper;
using FluentValidation.TestHelper;
using Moq;
using Teleperformance.Bootcamp.Application.DTOs.ShoppingList;
using Teleperformance.Bootcamp.Application.Features.Commands.ShoppingList.ShoppinListUpdate;
using Teleperformance.Bootcamp.Application.Interfaces.Repositories;
using Teleperformance.Bootcamp.Application.Mappings;
using Teleperformance.Bootcamp.Application.Validations.ShoppingList;
using Teleperformance.Bootcamp.Domain.Common.Response;

namespace ShoppingListProject.Test.ShoppingList
{
    public class ShoppingListUpdateCommandHandlerTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<IShoppingListRepository> _mockShoppingListRepository;
        private readonly Mock<ICategoryRepository> _mockCategoryRepository;

        public ShoppingListUpdateCommandHandlerTest()
        {
            var mapperConfig = new MapperConfiguration(c => { c.AddProfile<MappingProfile>(); });
            //mapperConfig.AssertConfigurationIsValid();
            _mapper = mapperConfig.CreateMapper();

            _mockShoppingListRepository = new();
            _mockCategoryRepository = new();
        }

        [Fact]
        public async Task Handle_Validations_ReturnsFails()
        {
            //Arrange
            ShoppingListUpdateCommandRequest request = new ShoppingListUpdateCommandRequest
            {
                UpdateShoppingListDto = new UpdateShoppingListDto
                {
                    Id = "1"
                }
            };

            UpdateShoppingListDto updateShoppingListDto = new UpdateShoppingListDto
            {
                Id = "",
                CategoryId = "",
                Title = "",
                Description = "\"xpArXfasdqKOeShlNQVOwEcRrELRirIjrQpkwZfXEUjOXPwxdAJoBUjNMvarTNOKXtZMErmLiUjzBgBMJzlrvQRUZtELGEINwEQktLikj\\r\\n\""
            };

            var handler = new ShoppingListUpdateCommandHandler(
         _mockShoppingListRepository.Object,
         _mapper,
         _mockCategoryRepository.Object
          );

            var shoppingListId = _mockShoppingListRepository.Setup(x => x.GetByIdAsync(request.UpdateShoppingListDto.Id));

            //Act

            // var result = await handler.Handle(request, default);

            UpdateShoppingListDtoValidation validator = new UpdateShoppingListDtoValidation();
            var validate = validator.TestValidate(updateShoppingListDto);

            //Assert
            Assert.NotSame(request.UpdateShoppingListDto.Id, shoppingListId);
            validate.ShouldHaveValidationErrorFor(x => x.Id);
            validate.ShouldHaveValidationErrorFor(x => x.CategoryId);
            validate.ShouldHaveValidationErrorFor(x => x.Title);
            validate.ShouldHaveValidationErrorFor(x => x.Description);

        }

        [Fact]
        public async Task Handle_CategoryIdDoesNotEqual_ReturnFails()
        {
            //Arrange
            Teleperformance.Bootcamp.Domain.Entities.ShoppingList shoppingList =
                  new Teleperformance.Bootcamp.Domain.Entities.ShoppingList
                  {
                      CategoryId = "0"
                  };

            var handler = new ShoppingListUpdateCommandHandler(
          _mockShoppingListRepository.Object,
          _mapper,
          _mockCategoryRepository.Object
           );

            ShoppingListUpdateCommandRequest request = new ShoppingListUpdateCommandRequest
            {
                UpdateShoppingListDto = new UpdateShoppingListDto
                {
                    Id = "1",
                    CategoryId = "1",
                    Title = "Lorem",
                    Description = "LoremIpsum"
                }
            };

            var categoryId = _mockCategoryRepository.Setup(x => x.GetByIdAsync(request.UpdateShoppingListDto.CategoryId));

            //Act
            var result = await handler.Handle(request, default);

            //Assert
            Assert.NotSame(shoppingList.CategoryId, categoryId);

        }

        [Fact]
        public async Task Handle_EntityIsNull_ReturnBaseResponseFalse()
        {
            //Arrange

            Teleperformance.Bootcamp.Domain.Entities.ShoppingList shoppingList = null;

            var handler = new ShoppingListUpdateCommandHandler(
                _mockShoppingListRepository.Object,
                _mapper,
                _mockCategoryRepository.Object
                );

            ShoppingListUpdateCommandRequest request = new ShoppingListUpdateCommandRequest
            {
                UpdateShoppingListDto = null
            };


            //Act

            BaseResponse response = await handler.Handle(request, default);

            //Assert

            Assert.Equal("Liste güncelleme başarısız", response.Message);
            Assert.False(response.IsSuccess);
        }

        [Fact]
        public async Task Handle_UpdateListExecuted_ReturnsBaseResponseSucces()
        {
            //Arrange

            Teleperformance.Bootcamp.Domain.Entities.ShoppingList shoppingList =
                 new Teleperformance.Bootcamp.Domain.Entities.ShoppingList
                 {
                     Title = "LoremIpsum",
                     Id = "1",
                     Description = "LoremIpsum",
                     IsComplete = true,
                     CompleteDate = DateTime.Now,
                     CategoryId = "1",
                     AppUserId = "1"
                 };

            ShoppingListUpdateCommandRequest request = new ShoppingListUpdateCommandRequest
            {
                UpdateShoppingListDto = new UpdateShoppingListDto
                {
                    Id = "1",
                    CategoryId = "1",
                    Title = "Lorem",
                    Description = "LoremeIpsum"
                }
            };

            var handler = new ShoppingListUpdateCommandHandler(
                _mockShoppingListRepository.Object,
                _mapper,
                _mockCategoryRepository.Object
                );

            _mockShoppingListRepository.Setup
            (x => x.Update(It.IsAny<Teleperformance.Bootcamp.Domain.Entities.ShoppingList>()));

            //Act

            BaseResponse response = await handler.Handle(request, default);

            //Assert

            _mockShoppingListRepository.Verify
                (x => x.Update(It.IsAny<Teleperformance.Bootcamp.Domain.Entities.ShoppingList>()), Times.Once);

            Assert.True(response.IsSuccess);
            Assert.NotNull(response.Message);

        }

    }
}
