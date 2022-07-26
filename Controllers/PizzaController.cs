﻿using la_mia_pizzeria_static.Data;
using la_mia_pizzeria_static.Models;
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
            List<Pizza> pizze;
            List<Category> categories;

            using (PizzaContext db = new PizzaContext())
            {
                pizze = db.Pizzas.ToList();
                categories = db.Categories.ToList();
            }

            ViewData["Title"] = "Menu";
            ViewData["Categories"] = categories;

            return View(pizze);
        }

        // GET: HomeController1/Details/5
        public ActionResult Details(int id)
        {

            Pizza pizzaCurrent;
            Category categoryCurrent;

            using (PizzaContext db = new PizzaContext())
            {
                pizzaCurrent = db.Pizzas.Where(p => p.Id == id).FirstOrDefault();
                categoryCurrent = db.Categories.Where(c => c.Id == pizzaCurrent.CategoryId).FirstOrDefault();    
            }

            if(pizzaCurrent == null)
            {
                ViewData["Title"] = "Error404";
                Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                return View("Error404");
            }
            else
            {
                ViewData["Title"] = pizzaCurrent.Name;
                
                if(categoryCurrent != null)
                {
                    ViewData["Category"] = categoryCurrent.Name;
                }
                else
                {
                    ViewData["Category"] = "Categoria non presente";
                }

                return View(pizzaCurrent);
            }

        }

        // GET: HomeController1/Create
        public ActionResult Create()
        {
            ViewData["Title"] = "Crea pizza";
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
