using SakhCubaAPI.Models.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Interfaces
{
    public interface IDecisionRepository : IRepositoryBase<Decision>
    {
        Task<IEnumerable<Decision>> GetAllDecisionAsync();
        Task<Decision> GetDecisionByIdAsync(int id);
        Task<Decision> GetDecisionWithDetailsAsync(int id);
        void CreateDecision(Decision decision);
        void UpdateDecision(Decision decision);
        void DeleteDecision(Decision decision);
    }
}
