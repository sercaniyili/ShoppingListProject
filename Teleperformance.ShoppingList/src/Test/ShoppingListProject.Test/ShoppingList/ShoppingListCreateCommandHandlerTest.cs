using AutoMapper;
using FluentValidation.TestHelper;
using Moq;
using Teleperformance.Bootcamp.Application.DTOs.ShoppingList;
using Teleperformance.Bootcamp.Application.Features.Commands.ShoppingList.ShoppingListCreate;
using Teleperformance.Bootcamp.Application.Interfaces.Repositories;
using Teleperformance.Bootcamp.Application.Mappings;
using Teleperformance.Bootcamp.Application.Validations.ShoppingList;
using Teleperformance.Bootcamp.Domain.Common.Response;
using Teleperformance.Bootcamp.Domain.Entities;
using Teleperformance.Bootcamp.Domain.Entities.Identity;

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
            _mapper = mapperConfig.CreateMapper();

            _mockShoppingListRepository = new();
            _mockCategoryRepository = new();
            _mockAppUserRepository = new();
        }




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
        public async Task Handle_CategoryDoesNotExist_ReturnFails()
        {
            //Arrange
            Teleperformance.Bootcamp.Domain.Entities.ShoppingList shoppingList =
                new Teleperformance.Bootcamp.Domain.Entities.ShoppingList
                {
                    CategoryId = "0"
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

            _mockCategoryRepository
               .Setup(x => x.GetByIdAsync(shoppingList.CategoryId))
               .ReturnsAsync(new Category { Id = shoppingList.CategoryId, Name = "Lorem" });

            _mockCategoryRepository
                .Setup(x => x.GetByIdAsync(It.IsNotIn<string>(new string[] { shoppingList.CategoryId })))
                .Returns(Task.FromResult((Category)null));

            //Act
            var result = await handler.Handle(request, default);

            //Assert
            Assert.False(result.IsSuccess);
            Assert.Equal("Kategori bulunamadı", result.Message);

        }
        [Fact]
        public async Task Handle_AppUserDoesNotExist_ReturnFails()
        {
            //Arrange
            Teleperformance.Bootcamp.Domain.Entities.ShoppingList shoppingList =
                new Teleperformance.Bootcamp.Domain.Entities.ShoppingList
                {
                    AppUserId = "0"
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

            _mockCategoryRepository.Setup(x => x.GetByIdAsync(It.IsAny<string>()))
                                .ReturnsAsync(new Category { Id = "1", Name = "Lorem" });

            _mockAppUserRepository.Setup(x => x.GetByIdAsync(shoppingList.AppUserId))
                                 .ReturnsAsync(new AppUser { Id = shoppingList.AppUserId, Name = "Lorem" });

            _mockAppUserRepository
                .Setup(x => x.GetByIdAsync(It.IsNotIn<string>(new string[] { shoppingList.AppUserId })))
                .Returns(Task.FromResult((AppUser)null));

            //Act
            var result = await handler.Handle(request, default);

            //Assert
            Assert.False(result.IsSuccess);
            Assert.Equal("Kullanıcı bulunamadı", result.Message);

        }
        [Fact]
        public async Task Handle_AddListExecuted_ReturnsBaseResponseSuccess()
        {
            //Arrange

            var handler = new ShoppingListCreateCommandHandler(
              _mockShoppingListRepository.Object,
              _mapper,
              _mockCategoryRepository.Object,
              _mockAppUserRepository.Object
               );

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

            ShoppingListCreateCommandRequest request = new ShoppingListCreateCommandRequest
            {
                CreateShoppingListDto = new CreateShoppingListDto
                {
                    CategoryId = "1",
                    AppUserId = "1",
                    Description = "LoremIpsum",
                    CreateDate = DateTime.Now,
                    Title = "Lorem"
                }
            };

            _mockCategoryRepository
                         .Setup(x => x.GetByIdAsync(It.IsAny<string>()))
                        .ReturnsAsync(new Category { Id = shoppingList.CategoryId, Name = "Lorem" });

            _mockAppUserRepository
                                 .Setup(x => x.GetByIdAsync(shoppingList.AppUserId))
                                 .ReturnsAsync(new AppUser { Id = shoppingList.AppUserId, Name = "Lorem" });

            //Act

            BaseResponse response = await handler.Handle(request, default);

            //Assert

            _mockShoppingListRepository.Verify
                (x => x.AddAsync(It.Is<Teleperformance.Bootcamp.Domain.Entities.ShoppingList>(s=>s.CategoryId == shoppingList.CategoryId && s.AppUserId == shoppingList.AppUserId)), Times.Once);
            

            Assert.True(response.IsSuccess);
            Assert.Equal("Liste başarıyla eklendi", response.Message);

        }
    }
}
