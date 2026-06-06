using MediCoreHMS.Domain.Common;
using System.Data;

namespace MediCoreHMS.Domain.Entities;

public class User : BaseEntity
{
    public string FullName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
    public bool IsActive { get; set; } = true;

    // Foreign Key
    public int RoleId { get; set; }

    // Navigation
    public Role Role { get; set; } = null!;
}