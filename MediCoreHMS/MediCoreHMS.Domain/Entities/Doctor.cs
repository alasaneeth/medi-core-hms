using MediCoreHMS.Domain.Common;
using MediCoreHMS.Domain.Enums;

namespace MediCoreHMS.Domain.Entities;

public class Doctor : BaseEntity
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Specialization { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string LicenseNumber { get; set; } = string.Empty;
    public decimal ConsultationFee { get; set; }
    public Gender Gender { get; set; }
    public bool IsAvailable { get; set; } = true;

    // Navigation
    public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
}