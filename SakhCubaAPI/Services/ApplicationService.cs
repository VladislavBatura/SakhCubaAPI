using Contracts.Interfaces;
using Entities.Context;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using SakhCubaAPI.Models.ViewModels;

namespace SakhCubaAPI.Services
{
    public class ApplicationService
    {
        private readonly AdminService _adminService;
        private readonly IRepositoryWrapper _repository;

        public ApplicationService(AdminService adminService, IRepositoryWrapper repository)
        {
            _adminService = adminService;
            _repository = repository;
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

        public async Task<IEnumerable<News>> GetAllNewsAsync()
        {
            var news = await _repository.News.GetAllNewsAsync();
            if (news is null || !news.Any())
                return Enumerable.Empty<News>();
            return news;
        }

        public async Task<IEnumerable<News>> GetLastNewsAsync(int howMany)
        {
            var news = await _repository.News.GetAllNewsAsync();
            news = news.Take(howMany).ToList();
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

            var decisionHandler = await _repository.Decision.GetDecisionByIdAsync(1);
            applicationVM.DecisionId = decisionHandler.Id;
            applicationVM.Date = DateTime.UtcNow.Date;
            applicationVM.Ip = ip;

            var app = _adminService.ConvertViewModelToApp(applicationVM);
            if (app is null)
                return false;

            _repository.Application.CreateApplication(app);
            await _repository.SaveAsync();

            return true;
        }
    }
}
