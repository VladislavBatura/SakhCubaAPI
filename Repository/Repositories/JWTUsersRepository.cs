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
    public class JWTUsersRepository : RepositoryBase<JWT_Users>, IJWTUsersRepository
    {
        public JWTUsersRepository(SakhCubaContext sakhCubaContext) : base(sakhCubaContext)
        {
        }

        public void CreateJWTUsers(JWT_Users jwtUser)
        {
            Create(jwtUser);
        }

        public void DeleteJWTUsers(JWT_Users jwtUser)
        {
            Delete(jwtUser);
        }

        public async Task<IEnumerable<JWT_Users>> GetAllJWTUsersAsync()
        {
            return await GetAll()
                .OrderBy(a => a.Id)
                .ToListAsync();
        }

        public async Task<JWT_Users> GetJWTUsersByIdAsync(int id)
        {
            return await GetByCondition(c => c.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<JWT_Users> GetJWTUsersWithDetailsAsync(int id)
        {
            return await GetByCondition(c => c.Id == id)
                .FirstOrDefaultAsync();
        }

        public void UpdateJWTUsers(JWT_Users jwtUser)
        {
            Update(jwtUser);
        }
    }
}
