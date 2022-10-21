using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ShoppingWithBetty.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingWithBetty.DataAccess.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
       public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base (options)
        {

        }
        public DbSet<Catagory> Catagories { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
