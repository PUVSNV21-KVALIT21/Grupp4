using HakimLivsGrupp4.Data;
using HakimLivsGrupp4.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace HakimLivsGrupp4.Services;

public class ProductService
{
    private IEnumerable<Product> products;

    private readonly ApplicationDbContext _context;

    public ProductService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Product>> GetProducts()
    {
        products = await _context.Products.ToListAsync();
        return products;
    }

    public async Task<IEnumerable<Product>> SearchProduct(string search)
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
}