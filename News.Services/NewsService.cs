using News.DAL.Abstract.Repostory;
using News.Models.Entities;
using News.Models.Request;
using News.Models.Response;
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

        public BaseResponsModel<bool> AddNews(NewsDto newNews)
        {
            BaseResponsModel<bool> model = new BaseResponsModel<bool>();
            try
            {
                model.IsSuccess = false;
                model.Obj = false;
                if (!string.IsNullOrWhiteSpace(newNews?.NewsHeader) && !string.IsNullOrEmpty(newNews?.NewsHeader))
                {             
                    model.Message = "Header null ola bilmez";
                    return model;
                }
                if (!string.IsNullOrWhiteSpace(newNews?.NewsContent) && !string.IsNullOrEmpty(newNews?.NewsContent))
                {
                    model.Message = "Content null ola bilmez";
                    return model;
                }
                _newsRepository.Add(new()
                {
                    NewsHeader = newNews.NewsHeader,
                    NewsContent = newNews.NewsContent
                });

                _newsRepository.SaveChanges();

                model.Obj = true;
                model.IsSuccess = true;
                model.Message = "Elave olundu";
                return model;
            }
            catch (Exception ex)
            {
                model.IsSuccess=false;
                model.Obj = false;
                model.Message = "Xeta bas verdi"+ex.ToString();
                return model;
            }

        }

        public BaseResponsModel<NewsEntity> GetById(int id)
        {
            BaseResponsModel<NewsEntity> model = new BaseResponsModel<NewsEntity>();
            try
            {
                var result = _newsRepository.GetById(id);
                if (result == null)
                {
                    model.IsSuccess = false;
                    model.Message = "Məlumat tapılmadı";
                }
                else
                {
                    model.IsSuccess = true;
                    model.Obj = result;
                }
                return model;
            }
            catch (Exception)
            {
                model.IsSuccess = false;
                model.Message = "Xəta baş verdi";
                return model;
            }
        }
        public BaseResponsModel<bool> UpdateNews(UpdatedNews news)
        {
            BaseResponsModel<bool> model = new BaseResponsModel<bool>();
            try
            {
                model.IsSuccess = false;
                model.Obj = false;
                if (news == null || news.NewsId <= 0)
                {
                    model.Message = "Boş dəyər göndərilə bilməz";
                    return model;
                }

                var oldNews = _newsRepository.GetById(news.NewsId);
                if (oldNews == null)
                {
                    model.Message = "Axtardığınız məlumat tapılmadı";
                    return model;
                }
                if (!string.IsNullOrEmpty(news.NewsHeader) && !string.IsNullOrWhiteSpace(news.NewsHeader))
                {
                    oldNews.NewsHeader = news.NewsHeader;
                }

                if (!string.IsNullOrEmpty(news.NewsContent) && !string.IsNullOrWhiteSpace(news.NewsContent))
                {
                    oldNews.NewsContent = news.NewsContent;
                }
                _newsRepository.SaveChanges();

                model.IsSuccess = true;
                model.Obj = true;
                model.Message = "Əməliyyat uğurlu oldu";
                return model;
            }
            catch (Exception)
            {
                model.IsSuccess = false;
                model.Obj = false;
                model.Message = "Xəta baş verdi";
                return model;
            }

        }

        
    }
}
