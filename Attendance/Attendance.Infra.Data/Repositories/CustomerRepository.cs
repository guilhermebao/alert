using Attendance.Domain.Entities;
using Attendance.Domain.Interfaces;
using Attendance.Infra.Data.Context;

namespace Attendance.Infra.Data.Repositories;

public class CustomerRepository : BaseRepository<Customer, Guid>, ICustomerRepository
{
    public CustomerRepository(AppDbContext context) : base(context)
    {
    }

}
