using Microsoft.Azure.Cosmos;

namespace CapitalPlacementTask.Extensions
{
    public static class CosmosDbServiceExtensions
    {
        public static IServiceCollection AddCosmosDbService(this IServiceCollection services, IConfiguration configuration)
        {
            string endpointUri = configuration["CosmosDB:EndpointUri"];
            string primaryKey = configuration["CosmosDB:PrimaryKey"];
            string databaseName = configuration["CosmosDB:DatabaseName"];
            string containerName = configuration["CosmosDB:ContainerName"];

            CosmosClient cosmosClient = new CosmosClient(endpointUri, primaryKey);
            Container container = cosmosClient.GetContainer(databaseName, containerName);

            services.AddSingleton(cosmosClient);
            services.AddSingleton(container);


            return services;
        }

    }
}
