using HakimLivs.Data;
using HakimLivs.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace HakimLivs.Services
{
    public class AdminService
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AdminService(ApplicationDbContext context, UserManager<ApplicationUser> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task SaveOrderHistory(ApplicationUser userToBeRemoved)
        {
            var user = await _userManager.FindByIdAsync("836d7d5c-5691-474d-8a0b-ddc9a5ac80ff");
            var orderList = _context.Orders.Select(x => x).Include(x => x.Basket).Include(x => x.Basket.Discount).Where(x => x.Basket.UserID == userToBeRemoved.Id).ToList();
            var oldbasketList = _context.Baskets.Select(x => x).Where(x => x.UserID == userToBeRemoved.Id).ToList();
            //var oldBasketList = new List<Basket>();
            
            foreach(var basket in oldbasketList)
            {
                basket.UserID = user.Id;
            }
            _context.Baskets.UpdateRange(oldbasketList);

            foreach (var order in orderList)
            {
                order.DeliveryAdress = user.Address;
            }
            _context.Orders.UpdateRange(orderList);

            _context.SaveChanges();
        }

        public async Task LoadTestData()
        {
            var categoryList = new List<Category>
            {
                new Category { Name = "Skafferi" },
                new Category { Name = "Träning & Vikt" },
                new Category { Name = "Snacks & Godis" },
                new Category { Name = "Drycker" },
                new Category { Name = "Hygien & Apotek" },
                new Category { Name = "Barn & Baby" },
                new Category { Name = "Hem & Städ" },
            };

            var unitList = new List<Unit>
            {
                new Unit { Name = "g"},
                new Unit { Name = "hg"},
                new Unit { Name = "kg"},
                new Unit { Name = "ml"},
                new Unit { Name = "cl"},
                new Unit { Name = "l"},
                new Unit { Name = "pack"},
                new Unit { Name = "st"},
            };

            var categoryExists = await _context.Categories.AnyAsync();
            if (!categoryExists)
            {
                _context.AddRange(categoryList);
                await _context.SaveChangesAsync();
            }

            var unitExists = await _context.Units.AnyAsync();
            if (!unitExists)
            {
                _context.AddRange(unitList);
                await _context.SaveChangesAsync();
            }

            var productsExists = _context.Products.Any();
            if (!productsExists)
            {
                string path = @"Data\BasProdukter1.csv";
                string[] lines = File.ReadAllLines(path, System.Text.Encoding.Latin1);

                var existingCategories = await _context.Categories.ToListAsync();
                var existingUnits = await _context.Units.ToListAsync();
                foreach (string line in lines)
                {
                    var values = line.Split(';');
                    Product product = new Product();

                    product.Name = values[0];
                    product.Brand = values[1];
                    product.Description = values[2];
                    product.UnitQty = int.Parse(values[3]);
                    product.UnitID = existingUnits[int.Parse(values[4]) - 1].Id;
                    product.TableOfContent = values[5];
                    product.Price = decimal.Parse(values[6]);
                    product.CategoryID = existingCategories[int.Parse(values[7]) - 1].Id;
                    product.Stock = int.Parse(values[8]);
                    product.ImgPath = values[9];

                    _context.Products.Add(product);
                }

                await _context.SaveChangesAsync();
            }
        }
    }
}