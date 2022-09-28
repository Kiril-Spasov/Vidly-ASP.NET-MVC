using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vidly.Data;
using Vidly.Dtos;
using Vidly.Models;
using System.Linq;
using AutoMapper;


namespace Vidly.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private ApplicationDbContext _context;
        private IMapper _mapper;

        public CustomersController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET /api/customers
        [HttpGet]
        public ActionResult<IEnumerable<CustomerDto>> GetCustomers()
        {
            var customerDtos = _context.Customers
                .Include(c => c.MembershipType)
                .ToList()
                .Select(_mapper.Map<Customer, CustomerDto>);

            return Ok(customerDtos);
        }

        // GET /api/customer/1
        [HttpGet("{id}")]
        public ActionResult<CustomerDto> GetCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return NotFound();

            return Ok(_mapper.Map<Customer, CustomerDto>(customer));
        }

        // POST /api/customers
        [HttpPost]
        public ActionResult<CustomerDto> CreateCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var customer = _mapper.Map<CustomerDto, Customer>(customerDto);

            _context.Customers.Add(customer);
            _context.SaveChanges();

            customerDto.Id = customer.Id;

            var uri = new Uri($"https://localhost:7084/api/customers/{customer.Id}");

            return Created(uri, customerDto);
        }

        // PUT /api/customers/1
        [HttpPut("{id}")]
        public ActionResult UpdateCustomer(int id, CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerInDb == null)
                return NotFound();

            _mapper.Map(customerDto, customerInDb);

            /* customerInDb.Name = customerDto.Name;
            customerInDb.Birthdate = customerDto.Birthdate;
            customerInDb.IsSubscribedToNewsletter = customerDto.IsSubscribedToNewsletter;
            customerInDb.MembershipTypeId = customerDto.MembershipTypeId; */

            _context.SaveChanges();

            return RedirectToAction("Index", "Customers");
        }

        // DELETE /api/customers/1
        [HttpDelete("{id}")]
        public ActionResult DeleteCustomer(int id)
        {
            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

             if (customerInDb == null)
                 return NotFound();

            _context.Customers.Remove(customerInDb);
            _context.SaveChanges();

             return Ok();
        }
    }
}
