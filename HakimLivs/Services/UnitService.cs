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

        public async Task<List<string>> GetUnitNames()
        {
            var units = await _context.Units.ToListAsync();
            var names = new List<string>();
            foreach (var unit in units)
            {
                names.Add(unit.Name.ToString());
            }
            return names;
        }
    }
}