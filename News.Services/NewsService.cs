using News.DAL.Abstract.Repostory;
using News.Models.Entities;
using News.Models.Request;
using News.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.Services
{
    public class NewsService : INewsService
    {
        private readonly INewsRepository _newsRepository;

        public NewsService(INewsRepository newsRepository)
        {
            _newsRepository = newsRepository;
        }

        public bool AddNews(NewsDto newNews)
        {
            try
            {             
                _newsRepository.Add(new()
                {
                    NewsHeader = newNews.NewsHeader,
                    NewsContent = newNews.NewsContent
                });
                _newsRepository.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
           
        }

        public bool UpdateNews(int id, NewsDto newNews)
        {
            return true;
        }
    }
}
