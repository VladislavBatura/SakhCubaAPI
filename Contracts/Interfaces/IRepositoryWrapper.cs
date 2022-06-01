using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Interfaces
{
    public interface IRepositoryWrapper
    {
        IApplicationRepository Application { get; }
        IDecisionRepository Decision { get; }
        INewsRepository News { get; }
        IJWTUsersRepository JWTUser { get; }
        void SaveAsync();
    }
}
