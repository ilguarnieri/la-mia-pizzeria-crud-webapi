using la_mia_pizzeria_static.Data;
using la_mia_pizzeria_static.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace la_mia_pizzeria_static.Controllers
{
    public class PizzaController : Controller
    {
        // GET: HomeController1
        public ActionResult Menu()
        {
            List<Category> categories;

            using (PizzaContext db = new PizzaContext())
            {
                categories = db.Categories.ToList();
            }

            ViewData["Categories"] = categories;

            return View();
        }

        // GET: HomeController1/Details/5
        public ActionResult Details(int id)
        {
            ViewData["id"] = id;
            return View();
        }
        
    }
}
