using la_mia_pizzeria_static.Data;
using la_mia_pizzeria_static.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace la_mia_pizzeria_static.Controllers.Api
{
    [Route("api/pizzas")]
    [ApiController]
    public class PizzasController : ControllerBase
    {
        //api/pizzas  oppure  api/pizzas?categoryId=3
        [HttpGet]
        public IActionResult GetPizzas(int? categoryId)
        {
            using (PizzaContext db = new PizzaContext())
            {
                IEnumerable<Pizza> pizzas;

                if (categoryId != null)
                {
                    pizzas = db.Pizzas.Where(p => p.CategoryId == categoryId).OrderBy(p => p.Name).ToList();
                }
                else
                {
                    pizzas = db.Pizzas.Include("Category").OrderBy(p => p.Name).ToList();
                }


                //if (String.IsNullOrEmpty(inputUser))
                //{
                //    String query = "SELECT * FROM pizzas p" +
                //        "INNER JOIN categories c" +
                //        "ON p.CategoryId = c.Id" +
                //        "WHERE CHARINDEX('" +
                //        inputUser +
                //        "', p.name) > 0";

                //    pizzas = db.Pizzas.FromSqlRaw(query).ToList();

                //}

                return Ok(pizzas);
            }
        }

        //api/pizzas/dash/search
        [Route("dash/search")]
        public IActionResult GetSearchPizza(string? name)
        {
            using (PizzaContext db = new PizzaContext())
            {
                IEnumerable<Pizza> pizzass;

                Console.WriteLine(name);

                if (name != null)
                {
                    String query = "SELECT * " +
                        "FROM pizzas p " +
                        "WHERE CHARINDEX('" +
                        name +
                        "', p.name) > 0";

                    Console.WriteLine(query);

                    pizzass = db.Pizzas.FromSqlRaw(query).Include("Category").ToList();
                }
                else
                {
                    pizzass = db.Pizzas.Include("Category").OrderBy(p => p.Name).ToList();
                }

                return Ok(pizzass);
            }
        }

        //api/pizzas/3
        [HttpGet("{id}")]
        public IActionResult GetDetailPizza(int id)
        {
            using (PizzaContext db = new PizzaContext())
            {
                Pizza pizzaCurrent = db.Pizzas.Include("Category").Where(p => p.Id == id).FirstOrDefault();

                if (pizzaCurrent == null)
                {
                    return NotFound("404 - Not Found");
                }
                else
                {
                    return Ok(pizzaCurrent);
                }
            }
        }


        //[HttpPost]
        //public IActionResult Post([FromBody] Utente model)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return UnprocessableEntity(ModelState);
        //    }
        //    using (UtenteContext context = new UtenteContext())
        //    {
        //        // ... inseriamo le informazioni a DB ...
        //        return Ok();
        //    }
        //}
        


    }
}
