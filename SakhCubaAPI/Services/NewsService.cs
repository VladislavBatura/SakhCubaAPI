using Contracts.Interfaces;
using Entities.Context;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace SakhCubaAPI.Services
{
    public class NewsService
    {
        private readonly IRepositoryWrapper _repository;

        public NewsService(IRepositoryWrapper repository)
        {
            _repository = repository;
        }

        public async Task AddNewsAsync(News news)
        {
            news.Date = DateTime.UtcNow.Date;
            _repository.News.CreateNews(news);
            await _repository.SaveAsync();
        }

        public async Task<IEnumerable<News>> GetAllNewsAsync()
        {
            return await _repository.News.GetAllNewsAsync();
        }

        public async Task<News?> GetOneNewsAsync(int id)
        {
            var news = await _repository.News.GetNewsByIdAsync(id);
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

            _repository.News.UpdateNews(news);
            await _repository.SaveAsync();
            return true;
        }

        public async Task<bool> DeleteNewsAsync(int id)
        {
            var news = await IsExist(id);
            if (news is null)
            {
                return false;
            }

            _repository.News.DeleteNews(news);
            await _repository.SaveAsync();
            return true;
        }

        private async Task<News?> IsExist(int id)
        {
            var news = await _repository.News.GetNewsByIdAsync(id);
            return news;
        }
    }
}
