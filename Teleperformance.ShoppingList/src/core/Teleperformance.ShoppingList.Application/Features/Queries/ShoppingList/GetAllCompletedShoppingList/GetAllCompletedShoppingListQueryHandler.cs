using MediatR;
using Teleperformance.Bootcamp.Application.DTOs.ShoppingList;
using Teleperformance.Bootcamp.Application.Interfaces.Contract;

namespace Teleperformance.Bootcamp.Application.Features.Queries.ShoppingList.GetAllCompletedShoppingList
{
    //public class GetAllCompletedShoppingListQueryHandler : IRequestHandler
    //    <GetAllCompletedShoppingListQuery, List<ShoppingListToBsonDto>>
    //{
    //    public const string ShoppingListCollection = "CompletedLists";

    //    private readonly IMongoConnect _mongoDbConnect;
    //    public GetAllCompletedShoppingListQueryHandler(IMongoConnect mongoDbConnect)
    //    {
    //        _mongoDbConnect = mongoDbConnect;
    //    }

        //public async Task<List<ShoppingListToBsonDto>> Handle(GetAllCompletedShoppingListQuery request, CancellationToken cancellationToken)
        //{
        //    var collection = _mongoDbConnect.ConnectToMongo<ShoppingListToBsonDto>(ShoppingListCollection);
        //   // var result = await collection.FindAsync(x => true);
        //   // return result.ToList();
        //}
   // }
}
