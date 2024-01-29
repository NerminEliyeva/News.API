using Microsoft.AspNetCore.Mvc;
using NewsMVC.Models;
using System.Diagnostics;

namespace NewsMVC.Controllers
{
    public class NewsMvcController : Controller
    {
        private readonly ILogger<NewsMvcController> _logger;

        private readonly INewsService _newsServices;

        public NewsMvcController(INewsService newsServices)
        {
            _newsServices = newsServices;
        }
        public IActionResult Index()
        {
            // Implement logic to display a list of news (similar to GetAll action)
            var model = _newsServices.GetAll().Data;
            return View(model);
        }

        public IActionResult Details(int id)
        {
            // Implement logic to display details of a specific news item (similar to GetNewsById action)
            var model = _newsServices.GetById(id).Data;
            return View(model);
        }

        public IActionResult Create()
        {
            // Implement logic to display the create news form
            return View();
        }

        [HttpPost]
        public IActionResult Create(NewsDto news)
        {
            // Implement logic to add news (similar to AddNews action)
            _newsServices.AddNews(news);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            // Implement logic to display the edit news form (similar to GetNewsById action)
            var model = _newsServices.GetById(id).Data;
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(UpdatedNews news)
        {
            // Implement logic to update news (similar to UpdateNews action)
            _newsServices.UpdateNews(news);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            // Implement logic to display confirmation for deleting news (similar to GetNewsById action)
            var model = _newsServices.GetById(id).Data;
            return View(model);
        }

        [HttpPost]
        public IActionResult ConfirmDelete(int id)
        {
            // Implement logic to delete news (similar to Delete action)
            _newsServices.Delete(id);
            return RedirectToAction("Index");
        }
    }
}