using Microsoft.EntityFrameworkCore;
using SakhCubaAPI.Context;
using SakhCubaAPI.Models.DBModels;

namespace SakhCubaAPI.Services
{
    public class ApplicationService
    {
        private readonly SakhCubaContext _context;

        public ApplicationService(SakhCubaContext context)
        {
            _context = context;
        }

        public async Task<News?> GetOneNewsAsync(int id)
        {
            var news = await _context.News.FirstOrDefaultAsync(i => i.Id == id);
            if (news == null)
            {
                return null;
            }
            return news;
        }

        public async Task<IEnumerable<News>> GetAllNewsAsync()
        {
            return await _context.News.ToListAsync();
        }

        public async Task<IEnumerable<News>> GetLastNewsAsync(int howMany)
        {
            var news = await _context.News.TakeLast(howMany).ToListAsync();
            if (news == null)
            {
                return Enumerable.Empty<News>();
            }
            return news;
        }

        public async Task<bool> SendApplicationAsync(Application application, string ip)
        {
            if (application == null)
            {
                return false;
            }

            var decisionHandler = await _context.Decisions.FirstOrDefaultAsync(d => d.Id == 1);
            application.DecisionId = decisionHandler.Id;
            var time = DateTime.Today;
            application.Date = time.Date;
            application.Ip = ip;
            _context.Applications.Add(application);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
