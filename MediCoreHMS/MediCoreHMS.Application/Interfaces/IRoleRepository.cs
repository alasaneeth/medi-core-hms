using MediCoreHMS.Domain.Entities;

namespace MediCoreHMS.Application.Interfaces;

public interface IRoleRepository : IGenericRepository<Role>
{
    Task<Role?> GetByNameAsync(string name);
}