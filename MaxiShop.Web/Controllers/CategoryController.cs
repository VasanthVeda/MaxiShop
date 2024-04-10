using MaxiShop.Web.Data;
using MaxiShop.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MaxiShop.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ApplicationDbContext _dbcontext;

        public CategoryController(ApplicationDbContext dbContext)
        {
            _dbcontext = dbContext;
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public ActionResult Create([FromBody]Category category)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _dbcontext.Category.Add(category);
            _dbcontext.SaveChanges();
            return Ok();
        }
    }

}
