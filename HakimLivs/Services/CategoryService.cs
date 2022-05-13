using HakimLivs.Data;
using HakimLivs.Models;
using Microsoft.EntityFrameworkCore;

namespace HakimLivs.Services
{
    public class CategoryService
    {

        private readonly ApplicationDbContext _context;

        public CategoryService(ApplicationDbContext context)
        {
            _context = context;           
        }

        public async Task<List<Category>> GetCategories()
        {
            var category = await _context.Categories.ToListAsync();
            return category;
        }
    }
}
