using System.Threading.Tasks;
using AntFood.Contracts;
using HotChocolate;

namespace AntFood.GraphQLServer.Schema.Mutations
{
    public class MutationResolvers
    {
        public async Task<RestaurantType> AddRestaurant([Parent]Mutation mutation, string name)
        {
            return await mutation.AddRestaurant(name);
        }

        public async Task<TableType> AddTable([Parent]Mutation mutation, AddTableInput input)
        {
            return await mutation.AddTable(input);
        }
    }
}
