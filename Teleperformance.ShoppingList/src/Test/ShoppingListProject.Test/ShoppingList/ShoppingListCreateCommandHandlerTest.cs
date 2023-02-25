using AutoMapper;
using FluentValidation.TestHelper;
using Moq;
using Teleperformance.Bootcamp.Application.DTOs.ShoppingList;
using Teleperformance.Bootcamp.Application.Features.Commands.ShoppingList.ShoppingListCreate;
using Teleperformance.Bootcamp.Application.Interfaces.Repositories;
using Teleperformance.Bootcamp.Application.Mappings;
using Teleperformance.Bootcamp.Application.Validations.ShoppingList;

namespace ShoppingListProject.Test.ShoppingList
{
    public class ShoppingListCreateCommandHandlerTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<IShoppingListRepository> _mockShoppingListRepository;
        private readonly Mock<ICategoryRepository> _mockCategoryRepository;
        private readonly Mock<IAppUserRepository> _mockAppUserRepository;

        public ShoppingListCreateCommandHandlerTest()
        {
            var mapperConfig = new MapperConfiguration(c => { c.AddProfile<MappingProfile>(); });
            //mapperConfig.AssertConfigurationIsValid();
            _mapper = mapperConfig.CreateMapper();

            _mockShoppingListRepository = new();
            _mockCategoryRepository = new();
            _mockAppUserRepository = new();

        }


        //[Fact]
        //public async void Handle_Mapping_ReturnsTrue()
        //{
        //    var mapperMock = new Mock<IMapper>();
        //    await mapperMock.Setup
        //         (m => m.Map<Teleperformance.Bootcamp.Domain.Entities.ShoppingList, GetAllShoppingListDto>(It.IsAny<GetAllShoppingListDto>()))
        //}

        [Fact]
        public void Handle_Validations_ReturnsFails()
        {
            //Arrange
            CreateShoppingListDto createShoppingListDto = new CreateShoppingListDto
            {
                Title = "a",
                AppUserId = " ",
                CategoryId = " ",
                Description = "xpArXfqKOeShlNQVOwEcRrELRirIjrQpkwZfXEUjOXPwxdAJoBUjNMvarTNOKXtZMErmLiUjzBgBMJzlrvQRUZtELGEINwEQktLikj\r\n"
            };

            //Act
            CreateShoppingListDtoValidation validator = new CreateShoppingListDtoValidation();
            var result = validator.TestValidate(createShoppingListDto);

            //Assert
            result.ShouldHaveValidationErrorFor(x => x.Title);
            result.ShouldHaveValidationErrorFor(x => x.AppUserId);
            result.ShouldHaveValidationErrorFor(x => x.CategoryId);
            result.ShouldHaveValidationErrorFor(x => x.Description);

        }

        [Fact]
        public async Task Handle_CategoryIdDoesNotEqual_ReturnFails()
        {
            //Arrange
            Teleperformance.Bootcamp.Domain.Entities.ShoppingList shoppingList =
                new Teleperformance.Bootcamp.Domain.Entities.ShoppingList
                {
                    CategoryId = "1"
                };

            var handler = new ShoppingListCreateCommandHandler(
               _mockShoppingListRepository.Object,
               _mapper,
               _mockCategoryRepository.Object,
               _mockAppUserRepository.Object
                );

            ShoppingListCreateCommandRequest request = new ShoppingListCreateCommandRequest
            {
                 CreateShoppingListDto = new CreateShoppingListDto
                 {
                     CategoryId = "1",
                     AppUserId = "1",
                     Description = "Loremİpsum",
                     CreateDate = DateTime.Now,
                     Title = "Lorem"
                 }
            };

            var categoryId = _mockCategoryRepository.Setup(x => x.GetByIdAsync(request.CreateShoppingListDto.CategoryId));

            //Act
            var result = await handler.Handle(request, default);

            //Assert
            Assert.NotSame(shoppingList.CategoryId, categoryId);

        }

        [Fact]
        public async Task Handle_AppUseIdDoesNotEqual_ReturnFails()
        {
            //Arrange
            Teleperformance.Bootcamp.Domain.Entities.ShoppingList shoppingList =
                new Teleperformance.Bootcamp.Domain.Entities.ShoppingList
                {
                    AppUserId = "1"
                };

            var handler = new ShoppingListCreateCommandHandler(
               _mockShoppingListRepository.Object,
               _mapper,
               _mockCategoryRepository.Object,
               _mockAppUserRepository.Object
                );

            ShoppingListCreateCommandRequest request = new ShoppingListCreateCommandRequest
            {
                CreateShoppingListDto = new CreateShoppingListDto
                {
                    CategoryId = "1",
                    AppUserId = "1",
                    Description = "Loremİpsum",
                    CreateDate = DateTime.Now,
                    Title = "Lorem"
                }
            };

            var appUserId = _mockCategoryRepository.Setup(x => x.GetByIdAsync(request.CreateShoppingListDto.AppUserId));

            //Act
            var result = await handler.Handle(request, default);

            //Assert
            Assert.NotSame(shoppingList.AppUserId, appUserId);

        }





    }
}
