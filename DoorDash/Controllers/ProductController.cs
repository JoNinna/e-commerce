using Microsoft.AspNetCore.Mvc;
using DoorDash.Data;
using DoorDash.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DoorDash.Controllers
{
    [Route("test")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get() => Ok("Hello, World!");
    }

    [Route("api/[controller]")] //api endpoint
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ApplicationDbContext _context; //ApplicationDbContext classused to access entities
                                                        //_context is used to indicate it's a private field

        //This is the constructor for the ProductsController class. 
        //When an instance of this class is created, this constructor is called to initialize the object.
        public ProductsController(ApplicationDbContext context) //parameter used to interact with the DB
        {
            _context = context; //This assignment ensures that the _context field 
                                //now holds a reference to the ApplicationDbContext that the controller 
                                //will use to query the database, add or remove records, and save changes.
        }

        // GET: api/Products - ASP.NET Core Web API action method that retrieves a list of products from a database
        [HttpGet] //GetProducts method will respond to HTTP GET requests.
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts() //the method returns
        //a Task, having the result type ActionResult, containing a collection of Product object, 
        //in this case a list of products from the DB
        //ActionResult provides the returning HTTP responses, 200 OK, or 404 Not Found
        {
            return await _context.Products.ToListAsync();
            //It fetches all the products from the database and converts them into an in-memory collection.
            //The await keyword ensures that the method execution waits until the database operation is complete
        }

        // GET: api/Products/5 - controller action method that retrieves a single product by its id from the database
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }
    }
}
