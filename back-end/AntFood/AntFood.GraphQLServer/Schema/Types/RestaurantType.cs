using AntFood.Contracts;
using AntFood.Domain.Services;
using HotChocolate.Types;

namespace AntFood.GraphQLServer.Schema.Types
{
    public class RestaurantType : ObjectType<RestaurantContract>
    {
        protected override void Configure(IObjectTypeDescriptor<RestaurantContract> descriptor)
        {
            descriptor.Field(x => x.Id);
            descriptor.Field(x => x.Name);
            descriptor.Field(x => x.Status);
            descriptor.Field(x => x.Tables)
                .Resolver(ctx =>
                {
                    var tableService = ctx.Service<ITableService>();
                    var restId = ctx.Parent<RestaurantContract>().Id;
                    return tableService.GetTablesAsync(restId).Result;
                });
        }
    }
}
