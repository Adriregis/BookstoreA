using Microsoft.AspNetCore.Mvc;

namespace BookstoreA.Services
{
    public class BookService : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
