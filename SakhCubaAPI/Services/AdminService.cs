using Microsoft.EntityFrameworkCore;
using SakhCubaAPI.Context;
using SakhCubaAPI.Models.DBModels;

namespace SakhCubaAPI.Services
{
    public class AdminService
    {
        private readonly SakhCubaContext _context;
        public AdminService(SakhCubaContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Application>> GetApplicationsAsync()
        {
            return await _context.Applications.Include(i => i.Decision).ToListAsync();
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
