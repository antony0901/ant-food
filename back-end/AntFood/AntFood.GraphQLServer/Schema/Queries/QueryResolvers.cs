using System;
using System.Threading.Tasks;
using AntFood.Contracts;
using HotChocolate;

namespace AntFood.GraphQLServer.Schema.Queries
{
    public class QueryResolvers
    {
        public async Task<RestaurantType> GetRestaurant([Parent]Query query, Guid id)
        {
            return await query.GetRestaurant(id);
        }

        public async Task<RestaurantType[]> GetRestaurants([Parent]Query query)
        {
            return await query.GetRestaurants();
        }

        public async Task<TableType[]> GetTablesOfRestaurant([Parent]Query query, Guid id)
        {
            return await query.GetTablesOfRestaurant(id);
        }
    }
}
