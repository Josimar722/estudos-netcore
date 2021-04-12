using Microsoft.EntityFrameworkCore;
using sistemaNet.Models;
using System;

namespace sistemaNet.Data
{
    public class DataContext : DbContext
    {
        
        public DataContext(DbContextOptions<DataContext> options)

            : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }

        public DbSet<Category> Categories { get; set; }

       
    }



}
