using la_mia_pizzeria_static.Data;
using la_mia_pizzeria_static.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace la_mia_pizzeria_static.Controllers
{
    [Route("api/pizzas")]
    [ApiController]
    public class PizzasController : ControllerBase
    {

        [HttpGet]
        public IActionResult GetPizzas(int? categoryId)
        {
            using (PizzaContext db = new PizzaContext())
            {
                IEnumerable<Pizza> pizzas = db.Pizzas.OrderBy(p => p.Name).ToList();

                if(categoryId != null)
                {
                    pizzas = db.Pizzas.Where(p => p.CategoryId == categoryId).OrderBy(p => p.Name).ToList();
                }

                return Ok(pizzas);
            }
        }
    }
}
