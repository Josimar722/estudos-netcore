﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using sistemaNet.Data;
using sistemaNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sistemaNet.Controller
{ 
      [ApiController]
      [Route("products")]
    public class ProductController : ControllerBase
    {

        [HttpGet]
        [Route("")]

        public async Task<ActionResult<List<Product>>> Get([FromServices] DataContext context)
        {

            try
            {
                var products = await context.Products.Include(x => x.Category).ToListAsync();
                return Ok(products);
            }
            
            catch(Exception ex)
            {
                var a = ex;
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("{id:int}")]
      
        public async Task<ActionResult<Product>> GetById([FromServices] DataContext context, int id)
        {
            var product = await context.Products.Include(x => x.Category)
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
                 return product;
        }

        [HttpGet]
        [Route("categories/{id:int}")]

        public async Task<ActionResult<List<Product>>> GetByCategory([FromServices]  DataContext context, int id)
        {
            var product = await context.Products
                .Include(x => x.Category)
                .AsNoTracking()
                .Where(x => x.CategoryId == id)
                .ToListAsync();
                return product;

        }

        [HttpPost]
        [Route("")]


        public async Task<ActionResult<Product>> Post(
            [FromServices] DataContext context,
            [FromBody] Product model)
        {
            if(ModelState.IsValid)
            {
                context.Products.Add(model);
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


