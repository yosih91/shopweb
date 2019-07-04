using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using test.Models;
namespace test.Data
{
    public class FruitslContext : DbContext
    {
       

            public FruitslContext(DbContextOptions<FruitslContext> options) : base(options)
            {
            }

            public DbSet<Fruits> Fruits { get; set; }
    }
        
}
