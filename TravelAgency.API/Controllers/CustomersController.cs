using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TravelAgency.Data;
using TravelAgency.Data.Models; 

namespace TravelAgency.API.Controllers
{
    [ApiController]
    [Route("api/Customers")]
    public class CustomersController : ControllerBase
    {
        private readonly TravelAgencyDbContext _context;

        public CustomersController(TravelAgencyDbContext context)
        {
            _context = context;
        }

        // GET: api/customers
        [HttpGet("All", Name = "GetAllCustomers")]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<IActionResult> GetAll()
        {
            var Customers = await _context.Customers.ToListAsync() ;

            if (Customers != null)
            {
                return Ok(Customers);
            }
            return NotFound("No customers Founded");

        }

        // GET: api/customers/5
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        [HttpGet("{id}" , Name ="GetCustomersById")]
        public async Task<IActionResult> GetById(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer == null) return NotFound();
            if (id < 1) return BadRequest($"No accepted id: ={id}");

            return Ok(customer);
        }

        // POST: api/customers
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> Create(Customer customer)
        {
            if (customer == null || string.IsNullOrEmpty(customer.FullName) || string.IsNullOrEmpty(customer.Email) )
            {
                return BadRequest("Invalid student data.");
            }
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetCustomersById", new { id = customer.Id }, customer);
        }

        // PUT: api/customers/5
        [HttpPut("{id}", Name ="UpdateCustomer")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Update(int id, Customer customerUpdated)
        {

            if (id < 1 || customerUpdated == null || string.IsNullOrEmpty(customerUpdated.FullName) )
            {
                return BadRequest("Invalid Customer data.");
            }
            var customer = await _context.Customers.FindAsync(id);

            if (customer == null)
            {
                return NotFound($"Customer with id= {id} is not found");
            }
            _context.Entry(customer).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE: api/customers/5
        [HttpDelete("{id}", Name = "DeleteCustomer")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> Delete(int id)
        {
            if (id < 1)
            {
                return BadRequest($"No accepted id:{id}");
            }
            var customer = await _context.Customers.FindAsync(id);
            if (customer == null) return NotFound($"Customer with id = {id} Not found");

            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
