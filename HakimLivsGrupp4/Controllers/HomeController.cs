using HakimLivsGrupp4.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using HakimLivsGrupp4.Services;

namespace HakimLivsGrupp4.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private IEnumerable<Product> Products { get; set; }
        private readonly ProductService _productService;

        public HomeController(ILogger<HomeController> logger, ProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }

        public async Task<IActionResult> IndexAsync(string searchString)
        {
            if (!String.IsNullOrEmpty(searchString))
            {
                Products = await _productService.SearchProduct(searchString);
            }
            else
            {
                Products = await _productService.GetProducts();
            }
            return View(Products);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}