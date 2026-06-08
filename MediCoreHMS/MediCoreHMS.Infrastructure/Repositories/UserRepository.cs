using MediCoreHMS.Application.Interfaces;
using MediCoreHMS.Domain.Entities;
using MediCoreHMS.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace MediCoreHMS.Infrastructure.Repositories;

public class UserRepository : GenericRepository<User>, IUserRepository
{
    public UserRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<User?> GetByEmailAsync(string email)
        => await _dbSet.Include(u => u.Role)
                       .FirstOrDefaultAsync(u => u.Email == email);

    public async Task<bool> EmailExistsAsync(string email)
        => await _dbSet.AnyAsync(u => u.Email == email);
}