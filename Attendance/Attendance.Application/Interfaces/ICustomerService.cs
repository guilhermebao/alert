using Attendance.Application.DTOs;

namespace Attendance.Application.Interfaces;

public interface ICustomerService
{
    Task<IEnumerable<CustomerDto>> GetAllCustomersAsync();
    Task<CustomerDto> GetCustomerByIdAsync(Guid id);
    Task<CustomerDto> CreateCustomerAsync(CustomerDto customerDto);
    Task<CustomerDto> UpdateCustomerAsync(Guid id, CustomerDto customerDto);
    Task<bool> DeleteCustomerAsync(Guid id);
}
