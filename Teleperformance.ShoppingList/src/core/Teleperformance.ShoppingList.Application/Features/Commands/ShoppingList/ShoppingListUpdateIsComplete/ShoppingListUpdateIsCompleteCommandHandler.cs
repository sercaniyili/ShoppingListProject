using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Teleperformance.Bootcamp.Application.Interfaces.MessageBrokers;
using Teleperformance.Bootcamp.Application.Interfaces.Repositories;
using Teleperformance.Bootcamp.Application.Validations.ShoppingList;
using Teleperformance.Bootcamp.Domain.Common.Response;

namespace Teleperformance.Bootcamp.Application.Features.Commands.ShoppingList.ShoppingListUpdateIsComplete
{
    public class ShoppingListUpdateIsCompleteCommandHandler : IRequestHandler<ShoppingListUpdateIsCompleteCommandRequest, BaseResponse>
    {
        private readonly IMapper _mapper;
        private readonly IShoppingListRepository _shoppingListRepsitory;
        private readonly IRabbitmqService _rabbitmqService;
        public ShoppingListUpdateIsCompleteCommandHandler(IShoppingListRepository shoppingListRepsitory, IMapper mapper, IRabbitmqService rabbitmqService)
        {
            _mapper = mapper;
            _shoppingListRepsitory = shoppingListRepsitory;
            _rabbitmqService = rabbitmqService;
        }

        public async Task<BaseResponse> Handle(ShoppingListUpdateIsCompleteCommandRequest request, CancellationToken cancellationToken)
        {
            var entity = _shoppingListRepsitory.GetAll()
             .Where(x => x.Id == request.UpdateIsCompleteDto.Id)
             .Include(x => x.Products)
             .Include(y => y.AppUser)
             .Include(z => z.Category)
             .FirstOrDefault();

            var result = _mapper.Map(request.UpdateIsCompleteDto, entity);


            UpdateIsCompleteDtoValidation validation = new UpdateIsCompleteDtoValidation();
            validation.ValidateAndThrow(request.UpdateIsCompleteDto);

            if (result != null)
            {
                _shoppingListRepsitory.Update(result);

                _rabbitmqService.Publish(new
                {
                    Title = entity.Title,
                    Description = entity.Description,
                    CreateDate = entity.CreateDate,
                    IsComlete = entity.IsComplete,
                    CompleteDate = entity.CompleteDate,
                    CategoryId = entity.CategoryId,
                    AppUserId = entity.AppUserId,
                    Products = entity.Products,

                }, "direct", "direct.test", "direct.queuName", "direct.test.key");

                return new BaseResponse("liste başarıyla tamalandı", true);
            }
            else
                return new BaseResponse("Liste tamamlama başarısız", false);
        }
    }
}
