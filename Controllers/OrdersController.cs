using DTO;
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
        public class OrdersController : ControllerBase
        {
            private readonly Context _context;

            public OrdersController(Context context)
            {
                _context = context;
            }

            [HttpGet]
            public async Task<ActionResult<IEnumerable<Orders>>> GetOrders()
            {
                return await _context.Orders.ToListAsync();
            }

            [HttpPost("Order")]
            public async Task<ActionResult<IEnumerable<OrdersDTO>>> Order(OrdersDTO request)
            {
                foreach (var item in request.id_products)
                {
                    var Orders = new Orders()
                    {
                        id_customer = request.id_customer,
                        id_orders = item
                        
                    };
                    await _context.Orders.AddAsync(Orders);
                    await _context.SaveChangesAsync();
                }

                return CreatedAtAction("GetOrders", request);
            }


            
        }
    }

