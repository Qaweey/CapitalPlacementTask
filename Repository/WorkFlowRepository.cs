using CapitalPlacementTask.Models;
using CapitalPlacementTask.Repository.Interface;
using Microsoft.Azure.Cosmos;
using Newtonsoft.Json;

namespace CapitalPlacementTask.Repository
{
    public class WorkFlowRepository : IWorkFlow
    {
        private readonly Container _container;
        private readonly ILogger<WorkFlowRepository> _logger;

        public WorkFlowRepository(Container container, ILogger<WorkFlowRepository> logger)
        {
            _container = container ?? throw new ArgumentNullException(nameof(container));
            _logger = logger;
        }
        public async Task<WorkFlow> CreateWorkFlowDetails(WorkFlow workFlow)
        {
            var response = await _container.CreateItemAsync(workFlow, new PartitionKey(workFlow.CustId));
            _logger.LogInformation(JsonConvert.SerializeObject(response.Resource));
            return response.Resource;
        }

        public async Task<WorkFlow> GetWorkFlow(string custId)
        {
            try
            {
                var response = await _container.ReadItemAsync<WorkFlow>(custId, new PartitionKey(custId));
                _logger.LogInformation(JsonConvert.SerializeObject(response.Resource));
                return response.Resource;
            }
            catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                _logger.LogInformation(ex.Message);
                return null; // Product not found
            }
        }

        public async Task<WorkFlow> UpdateProgramDetailsAsync(string custId, WorkFlow workFlow)
        {
            try
            {
                var response = await _container.ReplaceItemAsync(workFlow, custId, new PartitionKey(custId));
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
