using Microsoft.AspNetCore.Mvc;
using SimpleApp.Models;
using SimpleApp.Tests;

namespace SimpleApp.Controllers
{
    public class HomeController : Controller{

        public IDataSource DataSource = new ProductDataSource();
        public ViewResult Index()
        {
            return View(DataSource.Products);
        }
    }
}