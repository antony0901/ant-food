using System;
using AntFood.Contracts;
using AntFood.Contracts.Enums;
using AntFood.Contracts.Types;
using AntFood.Domain;
using AntFood.Domain.Services;
using AntFood.GraphQLServer.Schema;
using AntFood.GraphQLServer.Schema.Mutations;
using AntFood.GraphQLServer.Schema.Queries;
using AntFood.GraphQLServer.Types;
using GraphQL.Server.Ui.Playground;
using HotChocolate;
using HotChocolate.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AntFood.GraphQLServer
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContextPool<AFDbContext>(options => 
                options.UseMySql(Configuration.GetConnectionString("DefaultConnection")));
                
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddScoped<IRestaurantService, RestaurantService>();
            services.AddScoped<ITableService, TableService>();

            services.AddDataLoaderRegistry();
            //ConfigureGraphQLCodeFirst(services);
            ConfigureGraphQLSchemaFirst(services);
        }

        public void ConfigureGraphQLCodeFirst(IServiceCollection services)
        {
            services.AddGraphQL(sp => SchemaBuilder.New()
              .AddQueryType<QueryType>()
              .AddMutationType<MutationType>()
              .AddServices(sp)
              .Create());
        }

        public void ConfigureGraphQLSchemaFirst(IServiceCollection services)
        {
            services.AddGraphQL(sp => SchemaBuilder.New()
                .AddDocumentFromFile("schema.graphql")
                .BindComplexType<Query>(c => c.To("Query"))
                .BindResolver<QueryResolvers>(c => c.To<Query>())
                .BindComplexType<Mutation>(c => c.To("Mutation"))
                .BindResolver<MutationResolvers>(c => c.To<Mutation>())
                .BindComplexType<RestaurantType>(ctx => ctx.To("RestaurantType"))
                .BindComplexType<TableType>(c => c.To("TableType"))
                .BindComplexType<OrderType>(c => c.To("OrderType"))
                .BindResolver<OrderTypeResolver>(c => c.To<OrderType>())
                .BindComplexType<OrderItemType>(c => c.To("OrderItemType"))
                .BindComplexType<AddTableInput>(c => c.To("AddTableInput"))
                .Create());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseWebSockets();
            app.UseGraphQL("/graphql");
            app.UseGraphQLPlayground(new GraphQLPlaygroundOptions()
            {
                Path = "/graphql"
            });
        }
    }
}
