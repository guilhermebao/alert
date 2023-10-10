using Attendance.Application.DTOs;
using Attendance.Domain.Entities;
using AutoMapper;

namespace Attendance.Application.Mappings;

public class DomainToDtoMappingProfile : Profile
{
    public DomainToDtoMappingProfile()
    {
        CreateMap<Customer, CustomerDto>().ReverseMap();
        CreateMap<Appointment, AppointmentDto>().ReverseMap();
        CreateMap<AppointmentCreateDto, Appointment>();
        CreateMap<CustomerCreateDto, Customer>();

    }
}
