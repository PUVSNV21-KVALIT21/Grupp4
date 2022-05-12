using HakimLivs.Data;
using HakimLivs.Models;
using Microsoft.EntityFrameworkCore;

namespace HakimLivs.Services
{
    public class UnitService
    {

        private readonly ApplicationDbContext _context;

        public UnitService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Unit>> GetUnits()
        {
            var unit = await _context.Units.ToListAsync();
            return unit;
        }
    }
}