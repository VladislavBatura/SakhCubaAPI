using Microsoft.EntityFrameworkCore;
using SakhCubaAPI.Context;
using SakhCubaAPI.Models.DBModels;

namespace SakhCubaAPI.Services
{
    public class NewsService
    {
        private readonly SakhCubaContext _context;

        public NewsService(SakhCubaContext context)
        {
            _context = context;
        }

        public async void AddNewsAsync(News news)
        {
            news.Date = DateOnly.FromDateTime(DateTime.Today);
            _context.News.Add(news);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<News>> GetAllNewsAsync()
        {
            return await _context.News.ToListAsync();
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

        public async Task<bool> UpdateNewsAsync(News news)
        {
            if (news == null)
            {
                return false;
            }
            _context.News.Update(news);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteNewsAsync(int id)
        {
            var news = IsExist(id);
            if (news.Result == null)
            {
                return false;
            }
            _context.News.Remove(news.Result);
            await _context.SaveChangesAsync();
            return true;
        }

        private async Task<News?> IsExist(int id)
        {
            var news = await _context.News.FirstOrDefaultAsync(p => p.Id == id);
            return news;
        }
    }
}
