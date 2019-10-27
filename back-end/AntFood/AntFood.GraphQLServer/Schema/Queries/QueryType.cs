using HotChocolate.Types;

namespace AntFood.GraphQLServer.Schema.Queries
{
    public class QueryType : ObjectType<Query>
    {
        protected override void Configure(IObjectTypeDescriptor<Query> descriptor)
        {
            descriptor.Field(x => x.GetRestaurant(default));
            descriptor.Field(x => x.GetRestaurants());
            descriptor.Field(x => x.GetTablesOfRestaurant(default));
        }
    }
}
