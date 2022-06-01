using SakhCubaAPI.Models.DBModels;
using Contracts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SakhCubaAPI.Context;
using Microsoft.EntityFrameworkCore;

namespace Repository.Repositories
{
    public class NewsRepository : RepositoryBase<News>, INewsRepository
    {
        public NewsRepository(SakhCubaContext sakhCubaContext) : base(sakhCubaContext)
        {
        }

        public void CreateNews(News news)
        {
            Create(news);
        }

        public void DeleteNews(News news)
        {
            Delete(news);
        }

        public async Task<IEnumerable<News>> GetAllNewsAsync()
        {
            return await GetAll()
                .OrderBy(a => a.Id)
                .ToListAsync();
        }

        public async Task<News> GetNewsByIdAsync(int id)
        {
            return await GetByCondition(c => c.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<News> GetNewsWithDetailsAsync(int id)
        {
            return await GetByCondition(c => c.Id == id)
                .FirstOrDefaultAsync();
        }

        public void UpdateNews(News news)
        {
            Update(news);
        }
    }
}
