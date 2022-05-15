using HakimLivs.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace HakimLivs.Services
{
    public class UserService
    {
        private readonly ApplicationDbContext _context;
        //private readonly ApplicationUser _applicationUser;
        //private readonly UserManager<ApplicationUser> _userManager;

        public UserService(ApplicationDbContext context)
        {
            _context = context;
            //_applicationUser = applicationUser;
            //_userManager = userManager;
        }

        public async Task DeleteUser(ApplicationUser user)
        {
            var userD = _context.Users.Where( u => u.Id == user.Id ).Single();
            _context.Users.Remove(userD);
            await _context.SaveChangesAsync();
        }

        public async Task<List<ApplicationUser>> UpdateUsers()
        {
            var userList =  await _context.Users.ToListAsync();
            return userList;
        }
    }
}
