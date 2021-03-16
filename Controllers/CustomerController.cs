using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestApplication.Data;
using TestApplication.DTO;
using TestApplication.Models;

namespace TestApplication.Controllers
{
    [ApiController]
        [Route("[controller]")]
        public class CustomerController : ControllerBase
        {
            private readonly Context _context;

            public CustomerController(Context context)
            {
                _context = context;
            }

            [HttpGet]
            public async Task<ActionResult<IEnumerable<Customer>>> GetCustomers()
            {

            return await _context.Customer.ToListAsync();
            }

            [HttpGet("{id}")]
            public async Task<ActionResult<Customer>> GetCustomers_byId(int id)
            {
                
                var customers_by_id = await _context.Customer.FindAsync(id);

                if (customers_by_id == null)
                {
                    return NotFound();
                }
                return customers_by_id;
            }

            [HttpPost]
            public async Task<ActionResult<Customer>> Add_Customers(Customer Customer)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var customer = new Customer()
                {
                    firstname = Customer.firstname,
                    lastname = Customer.lastname,
                    age = Customer.age,
                    adress = Customer.adress

                };
                _context.Customer.Add(customer);
                await _context.SaveChangesAsync();

               

                return CreatedAtAction("GetCustomers", new { id = customer.id }, customer);
            }

            [HttpDelete("{id}")]
            public async Task<ActionResult<Customer>> Delete_Customer(int id)
            {
                var customer = _context.Customer.Find(id);


                if (customer == null)
                {
                    return NotFound();
                }
                else
                {
                    _context.Customer.Remove(customer);
                    await _context.SaveChangesAsync();
                    return customer;
                }
            }

            

          
        }
    }
