using HakimLivs.Data;
using HakimLivs.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace HakimLivs.Services
{
    public class OrderService
    {
        public string LoggedInUserID { get; private set; }

        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public class OrderDetails
        {
            public Order Order { get; set; }
            public Basket Basket { get; set; }
            public Discount Discount { get; set; }
            public List<BasketProduct> BasketProducts { get; set; }
        }

        public OrderService(ApplicationDbContext context, UserManager<ApplicationUser> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<List<Order>> GetOrders()
        {
            var orderList = await _context.Orders.Include(o => o.Basket).ThenInclude(b => b.Discount).ToListAsync();
            return orderList;
        }
        public async Task<OrderDetails> GetOrder(int id)
        {
            var order = await _context.Orders.Where(o => o.Id == id).Include(o => o.Basket).ThenInclude(b => b.User).Include(b => b.Basket).ThenInclude(b => b.Discount).SingleAsync();
            var basketProducts = await _context.BasketProducts.Where(bp => bp.Basket.Id == order.Basket.Id).Include(bp => bp.Product).ToListAsync();
            var orderDetails = new OrderDetails
            {
                Order = order,
                Basket = order.Basket,
                Discount = order.Basket.Discount,
                BasketProducts = basketProducts
            };

            return orderDetails;
        }

        //public async Task<List<Order>> GetAllOrdersAsync()
        //{
        //    var listOfOrders = await _context.Orders.Include(o => o.ApplicationUser).ToListAsync();
        //    return listOfOrders;
        //}
        public async Task SaveOrder(List<BasketProduct> basketProducts, decimal? orderValue, string paymentMethod, string discountCode)
        {


            if (discountCode == null || discountCode == "")
            {
                discountCode = "none";

            }
            var basketProductList = new List<BasketProduct>();


            LoggedInUserID = _userManager.GetUserId(_httpContextAccessor.HttpContext.User);
            var user = await _userManager.FindByIdAsync(LoggedInUserID);
            var basket = new Basket();
            var discount = _context.Discounts.Where(d => d.Code == discountCode).FirstOrDefault();

            basket.Discount = discount;
            basket.UserID = LoggedInUserID;
            basket.User = user;


            foreach (var item in basketProducts)
            {
                var product = _context.Products.AsNoTracking().Where(p => p.Id == item.Product.Id);
                //item.Product = item.Product;
                basketProductList.Add(item);
            }
            basketProductList.ForEach(bp => bp.Basket = basket);
            await _context.BasketProducts.AddRangeAsync(basketProducts);
            var order = new Order
            {
                Basket = basket,
                DeliveryAdress = basket.User.Address,
                DeliveryMethod = "PostNord",
                Orderdate = DateTime.Now,
                PaymentMethod = paymentMethod,
                TotalOrderValue = (decimal)orderValue

            };
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();


        }

        public async Task<bool> CheckDiscount(string discountCode)
        {
            var discount = _context.Discounts.Where(d => d.Code == discountCode).Any();
            return discount;
        }
        public async Task<decimal?> ApplyDiscount(string discountCode, decimal? orderValue)
        {
            var discount = _context.Discounts.Where(d => d.Code == discountCode).FirstOrDefault();

            var discountCalc = orderValue * ((decimal)discount.Percentage / 100);
            var newOrderValue = orderValue - discountCalc;
            return newOrderValue;
        }


    }
}
