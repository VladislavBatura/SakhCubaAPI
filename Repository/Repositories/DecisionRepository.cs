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
    public class DecisionRepository : RepositoryBase<Decision>, IDecisionRepository
    {
        public DecisionRepository(SakhCubaContext sakhCubaContext) : base(sakhCubaContext)
        {
        }

        public void CreateDecision(Decision decision)
        {
            Create(decision);
        }

        public void DeleteDecision(Decision decision)
        {
            Delete(decision);
        }

        public async Task<IEnumerable<Decision>> GetAllDecisionAsync()
        {
            return await GetAll()
                .OrderBy(a => a.Id)
                .ToListAsync();
        }

        public async Task<Decision> GetDecisionByIdAsync(int id)
        {
            return await GetByCondition(c => c.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<Decision> GetDecisionWithDetailsAsync(int id)
        {
            return await GetByCondition(c => c.Id == id)
                .Include(a => a.Applications)
                .FirstOrDefaultAsync();
        }

        public void UpdateDecision(Decision decision)
        {
            Update(decision);
        }
    }
}
