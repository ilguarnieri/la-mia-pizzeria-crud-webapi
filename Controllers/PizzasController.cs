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
        public IActionResult GetPizzas()
        {
            using (PizzaContext db = new PizzaContext())
            {
                IEnumerable<Pizza> pizzas = db.Pizzas.ToList();

                return Ok(pizzas);
            }
        }
    }
}
