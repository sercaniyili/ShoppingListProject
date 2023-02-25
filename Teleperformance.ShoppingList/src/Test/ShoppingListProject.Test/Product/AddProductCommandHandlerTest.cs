using AutoMapper;
using FluentValidation.TestHelper;
using Moq;
using Teleperformance.Bootcamp.Application.DTOs.Products;
using Teleperformance.Bootcamp.Application.Features.Commands.Products.AddProduct;
using Teleperformance.Bootcamp.Application.Interfaces.Repositories;
using Teleperformance.Bootcamp.Application.Mappings;
using Teleperformance.Bootcamp.Application.Validations.Product;
using Teleperformance.Bootcamp.Domain.Common.Response;

namespace ShoppingListProject.Test.Product
{
    public class AddProductCommandHandlerTest
    {

        private readonly IMapper _mapper;
        private readonly Mock<IProductRepository> _mockProductRepository;
        private readonly Mock<IShoppingListRepository> _mockShoppingListRepository;

        public AddProductCommandHandlerTest()
        {
            var mapperConfig = new MapperConfiguration(c => { c.AddProfile<MappingProfile>(); });
            //mapperConfig.AssertConfigurationIsValid();
            _mapper = mapperConfig.CreateMapper();

            _mockProductRepository = new();
            _mockShoppingListRepository = new();
        }

        [Fact]
        public void Handle_Validations_ReturnsFails()
        {
            //Arrange
            AddProductDto addProductDto = new AddProductDto
            {
                Name = "",
                Quantity = 0,
                ShoppingListId = "",
            };

            //Act
            AddProductDtoValidation validator = new AddProductDtoValidation();
            var result = validator.TestValidate(addProductDto);

            //Assert
            result.ShouldHaveValidationErrorFor(x => x.ShoppingListId);
            result.ShouldHaveValidationErrorFor(x => x.Name);
            result.ShouldHaveValidationErrorFor(x => x.Quantity);
        }

        [Fact]
        public async Task Handle_ShoppingListIdDoesNotEqual_ReturnsFail()
        {
            //Arrange
            Teleperformance.Bootcamp.Domain.Entities.Product product = new Teleperformance.Bootcamp.Domain.Entities.Product
            {
                Id = "1",
                Name = "Lorem",
                ShoppingListId = "1",
                CreateDate = DateTime.Now
            };

            var handler = new AddProductCommandHandler
                (
                _mockProductRepository.Object,
                _mapper,
                _mockShoppingListRepository.Object
                );

            AddProductCommandRequest request = new AddProductCommandRequest
            {
                AddProductDto = new AddProductDto
                {
                    ShoppingListId = "2",
                    Name = "Loremİpsum",
                    Quantity = 1,
                    IsBuy = true,
                    CreateDate = DateTime.Now
                }
            };

            var shoppingListId = _mockProductRepository.Setup(x => x.GetByIdAsync(request.AddProductDto.ShoppingListId));

            //Act
            var result = await handler.Handle(request, default);

            //Asset
            Assert.NotSame(product.ShoppingListId, shoppingListId);

        }

        [Fact]
        public async Task Handle_AddProductExecuted_ReturnsBaseResponseSucces()
        {
            //Arrange

            var handler = new AddProductCommandHandler
         (
         _mockProductRepository.Object,
         _mapper,
         _mockShoppingListRepository.Object
         );

            Teleperformance.Bootcamp.Domain.Entities.Product product = new Teleperformance.Bootcamp.Domain.Entities.Product
            {
                Id = "1",
                Name = "Lorem",
                ShoppingListId = "1",
                CreateDate = DateTime.Now
            };

            AddProductCommandRequest request = new AddProductCommandRequest
            {
                AddProductDto = new AddProductDto
                {
                    ShoppingListId = "1",
                    Name = "LoremIpsum",
                    Quantity = 1,
                    IsBuy = true,
                    CreateDate = DateTime.Now
                }
            };

            _mockProductRepository.Setup
                (x => x.AddAsync(It.IsAny<Teleperformance.Bootcamp.Domain.Entities.Product>()));

            //Act

            BaseResponse response = await handler.Handle(request, default);

            //Assert

            _mockProductRepository.Verify
                (x => x.AddAsync(It.IsAny<Teleperformance.Bootcamp.Domain.Entities.Product>()), Times.Once);

            Assert.True(response.IsSuccess);
            Assert.NotNull(response.Message);

        }


    }
}
