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

            ViewData["Title"] = "Menu - ";
            ViewData["Categories"] = categories;

            return View();
        }

        // GET: HomeController1/Details/5
        public ActionResult Details(int id)
        {
            ViewData["id"] = id;
            ViewData["Title"] = "Info Pizza - ";
            return View();
        }










        // GET: HomeController1/Create
        [Authorize]
        public ActionResult Create()
        {
            ViewData["Title"] = "Crea pizza - ";
            CategoryPizza model = new CategoryPizza();

            using (PizzaContext db = new PizzaContext())
            {
                List<Category> categories = db.Categories.OrderBy(c => c.Name).ToList();

                model.Categories = categories;
                model.Pizza = new Pizza();
            }

            return View(model);
        }

        // POST: HomeController1/Create
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CategoryPizza pizzaModel)
        {
            using(PizzaContext db = new PizzaContext())
            {
                if (!ModelState.IsValid)
                {
                    ViewData["Title"] = "Crea pizza";
                    List<Category> categories = db.Categories.OrderBy(c => c.Name).ToList();
                    pizzaModel.Categories = categories;

                    return View("Create", pizzaModel);
                }

                pizzaModel.Pizza.Ingredients = pizzaModel.Pizza.Ingredients.Replace(", ", ",");
                db.Pizzas.Add(pizzaModel.Pizza);
                db.SaveChanges();

                int newPizzaId = db.Pizzas.OrderByDescending(p => p.Id).Select(p => p.Id).First();

                return RedirectToAction("Details", "Pizza", new { id = newPizzaId });
            }
        }

        // GET: HomeController1/Edit/5
        [Authorize]
        public ActionResult Edit(int id)
        {
            using(PizzaContext db = new PizzaContext())
            {
                Pizza pizzaChange = db.Pizzas.Where(p => p.Id == id).FirstOrDefault();

                if(pizzaChange == null)
                {
                    ViewData["Title"] = "Error404";
                    Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    return View("Error404");
                }

                List<Category> categories = db.Categories.ToList();

                ViewData["Title"] = pizzaChange.Name;
                ViewData["Categories"] = categories;

                return View(pizzaChange);
            }
        }

        // POST: HomeController1/Edit/5
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Pizza pizza)
        {
            if (!ModelState.IsValid)
            {
                ViewData["Title"] = pizza.Name;
                return View("Edit", pizza);
            }

            using (PizzaContext db = new PizzaContext())
            {
                Pizza pizzaEdit = db.Pizzas.Where(p => p.Id == id).FirstOrDefault();

                if(pizzaEdit == null)
                {
                    ViewData["Title"] = "Error404";
                    Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    return View("Error404");
                }

                pizzaEdit.Name = pizza.Name;
                pizza.Ingredients = pizza.Ingredients.Replace(", ", ",");
                pizzaEdit.Ingredients = pizza.Ingredients;
                pizzaEdit.CategoryId = pizza.CategoryId;
                pizzaEdit.Price = pizza.Price;
                pizzaEdit.Photo = pizza.Photo;

                db.SaveChanges();
            }

            return RedirectToAction("Details", "Pizza", new { id = id });
        }

        // POST: HomeController1/Delete/5
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            using(PizzaContext db = new PizzaContext())
            {
                Pizza pizzaDelete = db.Pizzas.Where(p => p.Id == id).FirstOrDefault();

                if(pizzaDelete == null)
                {
                    ViewData["Title"] = "Error404";
                    Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    return View("Error404");
                }

                db.Pizzas.Remove(pizzaDelete);
                db.SaveChanges();
                return RedirectToAction("Menu", "Pizza");
            }
        }
    }
}
