using Microsoft.AspNetCore.Mvc;
using Virgins.Data;
using Virgins.Models;

namespace Virgins.Controllers
{
    public class VirginController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public VirginController(ApplicationDbContext db, IWebHostEnvironment webHostEnvironment)
        {
            _db = db;
            _webHostEnvironment = webHostEnvironment;
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
                //если новое изображение загружено - нам нужно его получить
                var files = HttpContext.Request.Form.Files;     //сохраним загруженное нами изображение в files, извлекая его с помощью HttpContext
                                                                //класс HttpRequest позволяет ASP.NET считывать значения HTTP, отправляемые клиентом во время веб-запроса
                                                                //Form олучает коллекцию переменных формы, Files получает коллекцию загруженных с клиента файлов
                string webRootPath = _webHostEnvironment.WebRootPath;   //записывает в переменную путь к папке wwwroot


                    //Creating
                    string upload = webRootPath + WC.VirginImage; //получаем путь в папку в которой будут храниться файлы с картинками
                    string fileName = Guid.NewGuid().ToString();    //GUID — это 128-разрядное целое число (16 байт), которое можно использовать во всех компьютерах и сетях,
                                                                    //где требуется уникальный идентификатор. Такой идентификатор имеет очень низкую вероятность дублирования.
                    string extension = Path.GetExtension(files[0].FileName);    //получаем разрешение файла присваивая значения файла который был загружен;
                                                                                //Path - это строка, предоставляющая расположение файла или каталога, GetExtension - определяет, включает ли путь расширение имени файла
                                                                                //скопируем файл в новое место которое определяется значением upload
                    using (var fileStream = new FileStream(Path.Combine(upload, fileName + extension), FileMode.Create))    //добавлем встроенный класс, с экземпляром класса FileStream(исп. для управления файлами);
                                                                                                                            //Combine - объединяет две строки в путь; FileMode - указывает, каким образом операционная система должна открыть файл
                    {
                        files[0].CopyTo(fileStream);
                    }
                    //обновляем ссылку на Image внутри сущности Product указав новый путь для доступа
                    obj.Image = fileName + extension;

                    _db.Virgins.Add(obj); //добавляем новый товар
                                
                    _db.SaveChanges();
                    return RedirectToAction("Index"); //перенаправление исполнение кода в метод Index
            }
            return View(obj);
        }
    }
}
