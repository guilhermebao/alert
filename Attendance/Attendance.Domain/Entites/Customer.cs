using Attendance.Domain.Entites;
using System;
using System.Collections.Generic;

namespace Attendance.Domain.Entities
{
    public class Customer : BaseEntity
    {
        public string Name { get; private set; }
        public string PhoneNumber { get; private set; }
        public string Address { get; private set; }
        public string City { get; private set; }
        public string Neighborhood { get; private set; }
        public string Number { get; private set; }

        public ICollection<Appointment> Appointments { get; set; }

        public Customer(Guid id, string name, string phoneNumber, string address, string city, string neighborhood, string number)
        {
            ValidateDomain(name, phoneNumber, address, city, neighborhood, number);
            Id = id;
        }

        public Customer(string name, string phoneNumber, string address, string city, string neighborhood, string number)
        {
            ValidateDomain(name, phoneNumber, address, city, neighborhood, number);
        }

        public void ValidateDomain(string name, string phoneNumber, string address, string city, string neighborhood, string number)
        {
            Name = name;
            PhoneNumber = phoneNumber;
            Address = address;
            City = city;
            Neighborhood = neighborhood;
            Number = number;
        }
    }
}
