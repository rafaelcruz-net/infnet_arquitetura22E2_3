using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
//using api.Models;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        public ProductController()
        {
            
        }


        [HttpGet("{id}/sync")]
        public IActionResult Get(int id)
        {
            Thread.Sleep(5000);
            return Ok(new
            {
                Id = id,
                Product = $"Product {id}"
            });
        }

        [HttpGet("{id}/async")]
        public async Task<IActionResult> GetAsync(int id)
        {
            await Task.Delay(5000);

            return Ok(new
            {
                Id = id,
                Product = $"Product {id}"
            });
        }


    }
}