using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Bakehouse.Models;

namespace Bakehouse.Controllers
{
    public class HomeController : Controller
    {
        BakeContext db;
        new Logic logic = new Logic();
        public HomeController(BakeContext context)
        {
            db = context;
        }
        public IActionResult Index()
        {
            logic.GetPrice(db.Products.ToList());
            logic.FutureHour(db.Products.ToList());
            return View(db.Products.ToList());
        }
    }
}