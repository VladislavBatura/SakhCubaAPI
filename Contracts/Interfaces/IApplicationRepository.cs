using SakhCubaAPI.Models.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Interfaces
{
    public interface IApplicationRepository : IRepositoryBase<Application>
    {
        Task<IEnumerable<Application>> GetAllApplicationsAsync();
        Task<Application> GetApplicationByIdAsync(int id);
        Task<Application> GetApplicationWithDetailsAsync(int id);
        void CreateApplication(Application application);
        void UpdateApplication(Application application);
        void DeleteApplication(Application application);
    }
}
