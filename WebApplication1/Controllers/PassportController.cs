using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class PassportController : Controller
    {
        // GET: /passport/
        public ActionResult Index()
        {
            var places = new List<PlaceOfBirth>
            {
                new PlaceOfBirth { Id = 1, Name = "Москва", Code = 45 },
                new PlaceOfBirth { Id = 1, Name = "Санкт-Петербург", Code = 40 },
                new PlaceOfBirth { Id = 1, Name = "Нижний Новгород", Code = 77 },
                new PlaceOfBirth { Id = 1, Name = "Новосибирск", Code = 50 },
                new PlaceOfBirth { Id = 1, Name = "Рязань", Code = 61 },
                new PlaceOfBirth { Id = 1, Name = "Ярославль", Code = 78 },
                new PlaceOfBirth { Id = 1, Name = "Самара", Code = 36 },
                new PlaceOfBirth { Id = 1, Name = "Челябинск", Code = 75 },
                new PlaceOfBirth { Id = 1, Name = "Владивосток", Code = 05 },
                new PlaceOfBirth { Id = 1, Name = "Хабаровск", Code = 08 }
            };
            return View(places);
        }
        // GET: /passport/browse
        public ActionResult Browse(int cityCode)
        {
            return View(cityCode);
        }
        // GET: /passport/Details
        public ActionResult Details(int id)
        {
            var pass = new PassportItem();
            pass.Name = "Иванов";
            pass.Surname = "Иван";
            return View(pass);
        }
    }
}