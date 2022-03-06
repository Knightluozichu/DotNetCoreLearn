using Microsoft.AspNetCore.Mvc;
using SampleApp.Models;

namespace SampleApp.Controllers
{
    public class HomeController : Controller{
        public ViewResult Index()
        {
            return View(Product.GetProducts());
        }
    }
}