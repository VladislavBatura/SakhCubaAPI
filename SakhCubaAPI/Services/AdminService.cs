using Microsoft.EntityFrameworkCore;
using SakhCubaAPI.Context;
using SakhCubaAPI.Models.DBModels;
using SakhCubaAPI.Models.ViewModels;
using System.Linq;

namespace SakhCubaAPI.Services
{
    public class AdminService
    {
        private readonly SakhCubaContext _context;
        public AdminService(SakhCubaContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ApplicationViewModel>> GetApplicationsAsync()
        {
            return ConvertAppToAppViewModelCollection(await _context.Applications
                .Include(i => i.Decision)
                .ToListAsync());
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

            _context.Applications.Update(app);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteApplicationAsync(int id)
        {
            var app = IsExist(id);
            if (app.Result == null)
            {
                return false;
            }

            _context.Applications.Remove(app.Result);
            await _context.SaveChangesAsync();
            return true;
        }

        private async Task<Application?> IsExist(int id)
        {
            var app = await _context.Applications
                .Include(i => i.Decision)
                .FirstOrDefaultAsync(p => p.Id == id);
            return app;
        }
    }
}
