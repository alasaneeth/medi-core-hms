using MediCoreHMS.Application.Interfaces;
using MediCoreHMS.Domain.Entities;
using MediCoreHMS.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace MediCoreHMS.Infrastructure.Repositories;

public class RoleRepository : GenericRepository<Role>, IRoleRepository
{
    public RoleRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<Role?> GetByNameAsync(string name)
        => await _dbSet.FirstOrDefaultAsync(r => r.Name == name);
}