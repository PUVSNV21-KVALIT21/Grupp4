using HakimLivs.Data;
using HakimLivs.Models;
using Microsoft.AspNetCore.Identity;

namespace HakimLivs.Services
{
    public class OrderService
    {
        public string LoggedInUserID { get; private set; }

        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;


        public OrderService(ApplicationDbContext context, UserManager<ApplicationUser> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task SaveOrder(List<BasketProduct> basketProducts, decimal? orderValue)
        {
            LoggedInUserID = _userManager.GetUserId(_httpContextAccessor.HttpContext.User);

            var basket = new Basket();

            var discount = _context.Discounts.Where(d => d.Code == "none").FirstOrDefault();
            var test = _context.Discounts.Any();
            var test2 = _context.Products.Any();

            basket.Discount = discount;
            basket.UserID = LoggedInUserID;
            basketProducts.ForEach(bp => bp.Basket = basket);

            var order = new Order
            {
                Basket = basket,
                DeliveryAdress = "Testadress 1, 503 80, Borås",
                DeliveryMethod = "PostNord",
                Orderdate = DateTime.Now,
                PaymentMethod = "VISA",
                TotalOrderValue = (decimal)orderValue * (basket.Discount.Percentage / 100),
               
            };
            await _context.BasketProducts.AddRangeAsync(basketProducts);
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();


        }


    }
}
