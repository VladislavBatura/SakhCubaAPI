using Contracts.Interfaces;
using Repository.Repositories;
using Entities.Context;

namespace Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private SakhCubaContext _sakhCubaContext;
        private IApplicationRepository _application;
        private IDecisionRepository _decision;
        private INewsRepository _news;
        private IJWTUsersRepository _jwtUser;


        public IApplicationRepository Application {
            get
            {
                if (_application is null)
                    _application = new ApplicationRepository(_sakhCubaContext);

                return _application;
            }
        }

        public IDecisionRepository Decision
        {
            get
            {
                if (_decision is null)
                    _decision = new DecisionRepository(_sakhCubaContext);

                return _decision;
            }
        }

        public INewsRepository News
        {
            get
            {
                if (_news is null)
                    _news = new NewsRepository(_sakhCubaContext);

                return _news;
            }
        }

        public IJWTUsersRepository JWTUser
        {
            get
            {
                if (_jwtUser is null)
                    _jwtUser = new JWTUsersRepository(_sakhCubaContext);

                return _jwtUser;
            }
        }

        public RepositoryWrapper(SakhCubaContext sakhCubaContext)
        {
            _sakhCubaContext = sakhCubaContext;
        }

        public async Task SaveAsync()
        {
            await _sakhCubaContext.SaveChangesAsync();
        }
    }
}
