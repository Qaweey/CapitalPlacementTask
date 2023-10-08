using CapitalPlacementTask.Models;

namespace CapitalPlacementTask.Repository.Interface
{
    public interface IApplicationForm
    {
        Task<ApplicationForm> CreateApplicationForm(ApplicationForm appForm);
        Task<ApplicationForm> GetApplicationForm(string custId);

        Task<ApplicationForm> UpdateApplicationFormAsync(string custId, ApplicationForm updatedAppform);
    }
}
