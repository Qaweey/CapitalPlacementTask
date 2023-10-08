using CapitalPlacementTask.Models;

namespace CapitalPlacementTask.Repository.Interface
{
    public interface IWorkFlow
    {
        Task<WorkFlow> CreateWorkFlowDetails(WorkFlow workFlow);
        Task<WorkFlow> GetWorkFlow(string custId);

        Task<WorkFlow> UpdateProgramDetailsAsync(string custId, WorkFlow workFlow);
    }
}
