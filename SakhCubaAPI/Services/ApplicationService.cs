using Contracts.Interfaces;
using Microsoft.EntityFrameworkCore;
using SakhCubaAPI.Context;
using SakhCubaAPI.Models.DBModels;
using SakhCubaAPI.Models.ViewModels;

namespace SakhCubaAPI.Services
{
    public class ApplicationService
    {
        private readonly SakhCubaContext _context;
        private readonly AdminService _adminService;
        private readonly IRepositoryWrapper _repository;

        public ApplicationService(SakhCubaContext context, AdminService adminService, IRepositoryWrapper repository)
        {
            _context = context;
            _adminService = adminService;
            _repository = repository;
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
            var news = await _context.News.ToListAsync();
            if (news is null || !news.Any())
                return Enumerable.Empty<News>();
            return news;
        }

        public async Task<IEnumerable<News>> GetLastNewsAsync(int howMany)
        {
            var app = _repository.Application.GetAll(x => x.Decision);


            var news = await _context.News.TakeLast(howMany).ToListAsync();
            if (news == null)
            {
                return Enumerable.Empty<News>();
            }
            return news;
        }

        public async Task<bool> SendApplicationAsync(ApplicationViewModel applicationVM, string ip)
        {
            if (applicationVM is null)
                return false;

            var decisionHandler = await _context.Decisions.FirstOrDefaultAsync(d => d.Id == 1);
            applicationVM.DecisionId = decisionHandler.Id;
            applicationVM.Date = DateTime.UtcNow.Date;
            applicationVM.Ip = ip;

            var app = _adminService.ConvertViewModelToApp(applicationVM);
            if (app is null)
                return false;

            _context.Applications.Add(app);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
