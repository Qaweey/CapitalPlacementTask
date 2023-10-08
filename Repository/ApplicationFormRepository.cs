using CapitalPlacementTask.Models;
using CapitalPlacementTask.Repository.Interface;
using Microsoft.Azure.Cosmos;
using Newtonsoft.Json;

namespace CapitalPlacementTask.Repository
{
    public class ApplicationFormRepository : IApplicationForm
    {
        private readonly Container _container;
        private readonly ILogger<ApplicationFormRepository> _logger;

        public ApplicationFormRepository(Container container, ILogger<ApplicationFormRepository> logger)
        {
            _container = container ?? throw new ArgumentNullException(nameof(container));
            _logger = logger;
        }
        public async Task<ApplicationForm> CreateApplicationForm(ApplicationForm appForm)
        {
            var response = await _container.CreateItemAsync(appForm, new PartitionKey(appForm.CustId));
            _logger.LogInformation(JsonConvert.SerializeObject(response.Resource));  
            return response.Resource;
        }

        public async Task<ApplicationForm> GetApplicationForm(string custId)
        {
            try
            {
                var response = await _container.ReadItemAsync<ApplicationForm>(custId, new PartitionKey(custId));
                _logger.LogInformation(JsonConvert.SerializeObject(response.Resource));
                return response.Resource;
            }
            catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                _logger.LogInformation(ex.Message);
                return null; // Product not found
            }
        }

        public async Task<ApplicationForm> UpdateApplicationFormAsync(string custId, ApplicationForm updatedAppform)
        {
            try
            {
                var response = await _container.ReplaceItemAsync(updatedAppform, custId, new PartitionKey(custId));
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
