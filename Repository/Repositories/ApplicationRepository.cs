using Contracts.Interfaces;
using Microsoft.EntityFrameworkCore;
using SakhCubaAPI.Context;
using SakhCubaAPI.Models.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class ApplicationRepository : RepositoryBase<Application>, IApplicationRepository
    {
        public ApplicationRepository(SakhCubaContext sakhCubaContext) : base(sakhCubaContext)
        {

        }

        public void CreateApplication(Application application)
        {
            Create(application);
        }

        public void DeleteApplication(Application application)
        {
            Delete(application);
        }

        public async Task<IEnumerable<Application>> GetAllApplicationsAsync()
        {
            return await GetAll()
                .OrderBy(a => a.Id)
                .ToListAsync();
        }

        public async Task<Application> GetApplicationByIdAsync(int id)
        {
            return await GetByCondition(c => c.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<Application> GetApplicationWithDetailsAsync(int id)
        {
            return await GetByCondition(c => c.Id == id)
                .Include(a => a.Decision)
                .FirstOrDefaultAsync();
        }

        public void UpdateApplication(Application application)
        {
            Update(application);
        }
    }
}
