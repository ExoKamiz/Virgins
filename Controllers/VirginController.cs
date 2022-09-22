using Microsoft.AspNetCore.Mvc;
using Virgins.Data;
using Virgins.Models;

namespace Virgins.Controllers
{
    public class VirginController : Controller
    {
        private readonly ApplicationDbContext _db;

        public VirginController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Virgin> listOfVirgins = _db.Virgins;
            return View();
        }
    }
}
