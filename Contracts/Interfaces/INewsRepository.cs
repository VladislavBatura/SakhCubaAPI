using SakhCubaAPI.Models.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Interfaces
{
    public interface INewsRepository : IRepositoryBase<News>
    {
        Task<IEnumerable<News>> GetAllNewsAsync();
        Task<News> GetNewsByIdAsync(int id);
        Task<News> GetNewsWithDetailsAsync(int id);
        void CreateNews(News news);
        void UpdateNews(News news);
        void DeleteNews(News news);
    }
}
