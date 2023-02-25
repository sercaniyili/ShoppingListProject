using FluentValidation.TestHelper;
using Moq;
using Teleperformance.Bootcamp.Application.Features.Commands.ShoppingList.ShoppingListCreate;
using Teleperformance.Bootcamp.Application.Features.Commands.ShoppingList.ShoppingListDelete;
using Teleperformance.Bootcamp.Application.Interfaces.Repositories;
using Teleperformance.Bootcamp.Application.Validations.ShoppingList;
using Teleperformance.Bootcamp.Domain.Common.Response;

namespace ShoppingListProject.Test.ShoppingList
{
    public class ShoppingListDeleteCommandHandlerTest
    {
        private readonly Mock<IShoppingListRepository> _mockShoppingListRepository;
        public ShoppingListDeleteCommandHandlerTest()
        {
            _mockShoppingListRepository = new();
        }

        [Fact]
        public void Handle_Validations_ReturnsFails()
        {
            //Arrange
            ShoppingListDeleteCommandRequest request = new ShoppingListDeleteCommandRequest
            {
                Id = ""
            };

            //Act
            ShoppingListDeleteCommandRequestValidation validator = new ShoppingListDeleteCommandRequestValidation();
            var result = validator.TestValidate(request);

            //Assert
            result.ShouldHaveValidationErrorFor(x => x.Id);
        }

        [Fact]
        public async Task Handle_DeleteListExecuted_ReturnBaseResponseSucces()
        {
            //Arrange
            var handler = new ShoppingListDeleteCommandHandler(
             _mockShoppingListRepository.Object
              );

            ShoppingListDeleteCommandRequest request = new ShoppingListDeleteCommandRequest
            {
                Id = "1"
            };

            _mockShoppingListRepository.Setup(x => x.DeleteAsync(request.Id));

            //Act

            BaseResponse response = await handler.Handle(request, default);

            //Assert

            _mockShoppingListRepository.Verify
                (x => x.DeleteAsync(request.Id), Times.Once);

            Assert.True(response.IsSuccess);
            Assert.NotNull(response.Message);

        }

    }
}
