using Attendance.Application.DTOs;
using Attendance.Domain.Entities;
using AutoMapper;

namespace Attendance.Application.Mappings;

public class DomainToDtoMappingProfile : Profile
{
    public DomainToDtoMappingProfile()
    {
        CreateMap<Customer, CustomerDto>();
        CreateMap<CustomerDto, Customer>();

        CreateMap<Appointment, AppointmentDto>();
        CreateMap<AppointmentDto, Appointment>();

        CreateMap<AppointmentCreateDto, Appointment>();
        CreateMap<CustomerCreateDto, Customer>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());

        CreateMap<UserDto, User>().ReverseMap();
        CreateMap<UserCreateDto, User>().ReverseMap();

    }
}

