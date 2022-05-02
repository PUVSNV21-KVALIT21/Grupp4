using HakimLivsGrupp4.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HakimLivsGrupp4.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Basket> Basket { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<BasketProduct> BasketProduct { get; set; }
        
    }
}