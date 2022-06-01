using Contracts.Interfaces;
using Entities.Context;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

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

        public async Task<JWT_Users> GetJWTUsersByEmailAsync(string email)
        {
            return await GetByCondition(c => c.Email.Equals(email))
                .FirstOrDefaultAsync();
        }

        public void UpdateJWTUsers(JWT_Users jwtUser)
        {
            Update(jwtUser);
        }
    }
}
