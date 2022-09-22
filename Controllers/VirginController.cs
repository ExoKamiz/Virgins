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
            return View(listOfVirgins);
        }

        //GET - CREATE
        public IActionResult Create()
        {
            return View();
        }

        //POST - CREATE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Virgin obj) //тут получаем обьект который нужно добавить в бд
        {
            if (ModelState.IsValid)               //проверяет выполнены ли все правила которые вы определили для своей модели; валидация со стороны сервера
            {
                _db.Virgins.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index"); //перенаправление исполнение кода в метод Index
            }
            return View(obj);
        }
    }
}
