using Attendance.Domain.Entities;
using Attendance.Domain.Interfaces;
using Attendance.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attendance.Infra.Data.Repositories
{
    public class AppointmentRepository : BaseRepository<Appointment, Guid>, IAppointmentRepository
    {
        public AppointmentRepository(AppDbContext context) : base(context)
        {
        }
    }
}
