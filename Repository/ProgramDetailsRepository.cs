using CapitalPlacementTask.Models;
using CapitalPlacementTask.Repository.Interface;
using Microsoft.Azure.Cosmos;
using Newtonsoft.Json;

namespace CapitalPlacementTask.Repository
{
    public class ProgramDetailsRepository : IProgramDetails
    {
        private readonly Container _container;
        private readonly ILogger<ProgramDetailsRepository> _logger;

        public ProgramDetailsRepository(Container container,ILogger<ProgramDetailsRepository> logger)
        {
            _container = container ?? throw new ArgumentNullException(nameof(container));
            _logger = logger;
        }
        public async Task<ProgramDetails> CreateProgramDetails(ProgramDetails programDetails)
        {

            var response = await _container.CreateItemAsync(programDetails, new PartitionKey(programDetails.CustId));
            _logger.LogInformation(JsonConvert.SerializeObject(response.Resource));
            return response.Resource;

        }

        public async Task<ProgramDetails> GetProgramDetails(string custId)
        {
            try
            {
                var response = await _container.ReadItemAsync<ProgramDetails>(custId, new PartitionKey(custId));
                _logger.LogInformation(JsonConvert.SerializeObject(response.Resource));
                return response.Resource;
            }
            catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                _logger.LogInformation(ex.Message);
                return null; // Product not found
            }

        }

        public async Task<ProgramDetails> UpdateProgramDetailsAsync(string custId, ProgramDetails updatedProduct)
        {
            try
            {
                var response = await _container.ReplaceItemAsync(updatedProduct, custId, new PartitionKey(custId));
                _logger.LogInformation(JsonConvert.SerializeObject(response.Resource));
                return response.Resource;
            }
            catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                _logger.LogInformation(ex.Message);
                return null; // Product not found
            }

        }
    }
}
