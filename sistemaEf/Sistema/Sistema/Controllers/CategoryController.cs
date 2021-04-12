using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using sistemaNet.Data;
using sistemaNet.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace sistemaNet.Controllers
{

    [ApiController]
    [Route("categories")]
    public class CategotyController : ControllerBase

    {
        [HttpGet]
        [Route("")]

        public async Task<ActionResult<List<Category>>> Get([FromServices] DataContext context)
        {

            var categories = await context.Categories.ToListAsync();
            return categories;
        }


        [HttpPost]
        [Route("")]

        public async Task<ActionResult<Category>> Post([FromServices] DataContext context,
            [FromBody] Category model)
        {
            if (ModelState.IsValid)
            {
                context.Categories.Add(model);
                await context.SaveChangesAsync();
                return model;
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
    }
}
