using HakimLivsGrupp4.Data;
using HakimLivsGrupp4.Models;
using Microsoft.EntityFrameworkCore;

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
}