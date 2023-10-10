using Attendance.Domain.Entities;

namespace Attendance.Domain.Interfaces;

public interface IAppointmentRepository : IBaseRepository<Appointment, Guid>
{

}
