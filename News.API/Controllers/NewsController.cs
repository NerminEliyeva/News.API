using Microsoft.AspNetCore.Mvc;
using News.Models.Request;
using News.Services;
using News.Services.Interfaces;

namespace News.API.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class NewsController : ControllerBase
    {
        private readonly INewsService _newsServices;
        public NewsController(INewsService newsServices)
        {
            _newsServices = newsServices;
        }

        [HttpPost("AddNews")]
        public bool AddNews([FromBody] NewsDto news)
        {
            return _newsServices.AddNews(news);
        }
    }
}
