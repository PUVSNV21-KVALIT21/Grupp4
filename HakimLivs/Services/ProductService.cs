using HakimLivs.Data;
using HakimLivs.Models;
using Microsoft.EntityFrameworkCore;

namespace HakimLivs.Services
{
    public class ProductService
    {
        private readonly ApplicationDbContext _context;

        public ProductService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Product>> GetProducts()
        {
            var products = await _context.Products.AsNoTracking().Include(p => p.Unit).Include(p => p.Category).ToListAsync();
            return products;
        }

        public async Task<List<Product>> SearchProduct(string search)
        {
            var products = await _context.Products
                .Where(l =>
                        l.Name.Contains(search) ||
                        l.Brand.Contains(search)
                    //||l.Category.Contains(search)
                )
                .ToListAsync();

            return products;
        }

        public async Task<List<Product>> GetProductByCategory(int id)
        {
            var products = await _context.Products
                .Where(l => l.CategoryID == id)
                .ToListAsync();

            return products;
        }

        public async Task SaveProduct(Product product)
        {
            var alreadyExists = await _context.Products.FindAsync(product.Id);
            if (alreadyExists == null)
            {
                _context.Products.Add(product);
            }
            else
            {
                _context.Products.Update(product);
            }

            await _context.SaveChangesAsync();
        }

        public async Task DeleteProduct(Product product)
        {
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }
    }
}