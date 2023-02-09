using News.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.Services.Interfaces
{
    public interface INewsService
    {
        bool AddNews(NewsDto newNews);

        bool UpdateNews(int id, NewsDto newNews);
    }
}
