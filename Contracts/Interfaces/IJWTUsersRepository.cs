using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Interfaces
{
    public interface IJWTUsersRepository : IRepositoryBase<JWT_Users>
    {
        Task<IEnumerable<JWT_Users>> GetAllJWTUsersAsync();
        Task<JWT_Users> GetJWTUsersByIdAsync(int id);
        Task<JWT_Users> GetJWTUsersByEmailAsync(string email);
        void CreateJWTUsers(JWT_Users jwtUser);
        void UpdateJWTUsers(JWT_Users jwtUser);
        void DeleteJWTUsers(JWT_Users jwtUser);
    }
}
