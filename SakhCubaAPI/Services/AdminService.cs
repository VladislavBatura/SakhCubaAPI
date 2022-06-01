using Contracts.Interfaces;
using Entities.Context;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using SakhCubaAPI.Models.ViewModels;
using System.Linq;

namespace SakhCubaAPI.Services
{
    public class AdminService
    {
        private readonly IRepositoryWrapper _repository;

        public AdminService(IRepositoryWrapper repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<ApplicationViewModel>> GetApplicationsAsync()
        {
            return ConvertAppToAppViewModelCollection(await _repository
                .Application
                .GetAllApplicationsAsync());
        }

        private IEnumerable<ApplicationViewModel> ConvertAppToAppViewModelCollection(
            IEnumerable<Application> app)
        {
            var coll = Enumerable.Empty<ApplicationViewModel>();
            foreach (var appItem in app)
            {
                var tempApp = ConvertAppToViewModel(appItem);
                if (tempApp is not null && tempApp.Id is not 0)
                    coll = coll.Append(tempApp);
            }
            return coll;
        }

        public ApplicationViewModel? ConvertAppToViewModel(Application app)
        {
            if (app is null)
                return null;

            var appViewModel = new ApplicationViewModel()
            {
                Id = app.Id,
                Nickname = app.Nickname,
                DiscordNickname = app.DiscordNickname,
                About = app.About,
                Ip = app.Ip,
                Date = app.Date,
                DecisionId = app.DecisionId,
                Decision = app.Decision.DecisionName
            };

            return appViewModel;
        }

        public Application? ConvertViewModelToApp(ApplicationViewModel appVM)
        {
            if (appVM is null)
                return null;

            var app = new Application()
            {
                Id = appVM.Id,
                Nickname = appVM.Nickname,
                DiscordNickname = appVM.DiscordNickname,
                About = appVM.About,
                Ip = appVM.Ip,
                Date = appVM.Date,
                DecisionId = appVM.DecisionId
            };

            return app;
        }

        public async Task<ApplicationViewModel?> GetApplicationAsync(int id)
        {
            var app = await IsExist(id);
            if (app == null)
                return null;

            var convertedApp = ConvertAppToViewModel(app);
            if (convertedApp is null)
                return null;

            return convertedApp;
        }

        public async Task<bool> UpdateApplicationAsync(ApplicationViewModel application)
        {
            if (application is null)
            {
                return false;
            }

            var app = ConvertViewModelToApp(application);
            if (app is null)
                return false;

            _repository.Application.Update(app);
            await _repository.SaveAsync();
            return true;
        }

        public async Task<bool> DeleteApplicationAsync(int id)
        {
            var app = await IsExist(id);
            if (app == null)
            {
                return false;
            }

            _repository.Application.Delete(app);
            await _repository.SaveAsync();
            return true;
        }

        private async Task<Application?> IsExist(int id)
        {
            var app = await _repository
                .Application
                .GetApplicationWithDetailsAsync(id);
            return app;
        }
    }
}
