using HakimLivsGrupp4.Data;
using HakimLivsGrupp4.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Security.Principal;

namespace HakimLivsGrupp4.Services;

public class ProductService
{
    private IEnumerable<Product> products;
    private Basket Basket;

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
                l.Brand.Contains(search) ||
                l.Category.Contains(search))
                .ToListAsync();
        
        return products;

    }
    public async Task<Action> AddProduct(Product product)
    {
        var currentUser = await _context.AS
        var basket = await _context.Basket.Where(x => x.UserID == currentUser.User).ToList();

        if (basket.productList != null)
        {
            basket.productList.Add(product);
        }
        else
        {
            basket.productList = new List<Product>();
            basket.productList.Add(product);
        }
        foreach (var item in productList)
        {

        }
    }
}