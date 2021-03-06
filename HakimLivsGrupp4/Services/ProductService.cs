using HakimLivsGrupp4.Data;
using HakimLivsGrupp4.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Linq;
using System.Security.Principal;
using Microsoft.AspNetCore.Http;
using HakimLivsGrupp4.Controllers;

namespace HakimLivsGrupp4.Services;

public class ProductService
{
    private IEnumerable<Product> products;
    private Basket Basket;
    private readonly UserManager<IdentityUser> _userManager;
    private readonly IHttpContextAccessor _httpContextAccessor;

    private readonly ApplicationDbContext _context;
    private readonly HomeController _homeController;

    public ProductService(ApplicationDbContext context, UserManager<IdentityUser> userManager, IHttpContextAccessor httpContextAccessor)
    {
        _context = context;
        _userManager = userManager;
        _httpContextAccessor = httpContextAccessor;
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
    public async Task AddProduct(Product product)
    {
        var currentUser = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);
        var basket = _context.Basket.Where(x => x.UserID.ToString() == currentUser.Id).FirstOrDefault();

        if (basket.ProductList != null)
        {
            var basketProduct = basket.ProductList.Where(x => x.ProductID == product.Id).FirstOrDefault();
            if(basketProduct != null)
            {
                basketProduct.ProductQuantity++;
            }
            else
            {
                BasketProduct basketProductInit = new BasketProduct()
                {
                    BasketID = basket.Id,
                    ProductID = product.Id,
                    ProductQuantity = 1
                };
            }
        }
        else
        {
            basket.ProductList = new List<BasketProduct>();
            BasketProduct basketProductInit = new BasketProduct()
            {
                BasketID = basket.Id,
                ProductID = product.Id,
                ProductQuantity = 1
            };
        }
    }
}
