using MediCoreHMS.Domain.Common;
using MediCoreHMS.Domain.Enums;

namespace MediCoreHMS.Domain.Entities;

public class Appointment : BaseEntity
{
    public DateTime AppointmentDate { get; set; }
    public TimeSpan AppointmentTime { get; set; }
    public AppointmentStatus Status { get; set; } = AppointmentStatus.Scheduled;
    public string? Notes { get; set; }

    // Foreign Keys
    public int PatientId { get; set; }
    public int DoctorId { get; set; }

    // Navigation
    public Patient Patient { get; set; } = null!;
    public Doctor Doctor { get; set; } = null!;
}