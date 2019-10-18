using AntFood.Contracts;
using HotChocolate.Types;

namespace AntFood.GraphQLServer.Schema.Types
{
    public class RestaurantType : ObjectType<RestaurantContract>
    {
        protected override void Configure(IObjectTypeDescriptor<RestaurantContract> descriptor)
        {
            descriptor.Field(x => x.Id);
        }
    }
}
