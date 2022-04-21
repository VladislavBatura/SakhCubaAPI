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
            return ConvertAppToAppViewModelCollection(await _context.
                Applications.Include(i => i.Decision).ToListAsync());
        }

        private IEnumerable<ApplicationViewModel> ConvertAppToAppViewModelCollection(
            IEnumerable<Application> app)
        {
            var coll = Enumerable.Empty<ApplicationViewModel>();
            foreach (var appItem in app)
            {
                var tempApp = ConvertApp(appItem);
                if (tempApp.Id is not 0)
                    coll = coll.Append(tempApp);
            }
            return coll.ToList();
        }

        private ApplicationViewModel ConvertApp(Application app)
        {
            if (app == null)
                return new ApplicationViewModel();
            var appViewModel = new ApplicationViewModel();
            appViewModel.Id = app.Id;
            appViewModel.Nickname = app.Nickname;
            appViewModel.DiscordNickname = app.DiscordNickname;
            appViewModel.About = app.About;
            appViewModel.Ip = app.Ip;
            appViewModel.Date = app.Date;
            appViewModel.DecisionId = app.DecisionId;
            appViewModel.Decision = app.Decision.DecisionName;
            return appViewModel;
        }

        public Application? GetApplication(int id)
        {
            var app = IsExist(id);
            if (app.Result == null)
            {
                return null;
            }
            return app.Result;
        }

        public async Task<bool> UpdateApplication(Application application)
        {
            if (application == null)
            {
                return false;
            }
            _context.Applications.Update(application);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteApplication(int id)
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
            var app = await _context.Applications.FirstOrDefaultAsync(p => p.Id == id);
            return app;
        }
    }
}
