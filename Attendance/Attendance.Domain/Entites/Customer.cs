using Attendance.Domain.Entites;
using Attendance.Domain.Validation;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Net;
using System.Xml.Linq;

namespace Attendance.Domain.Entities;

public class Customer : BaseEntity
{
    public string Name { get; private set; }
    public string PhoneNumber { get; private set; }
    public string Address { get; private set; }
    public string City { get; private set; }
    public string Neighborhood { get; private set; }
    public string Number { get; private set; }

    public Customer(Guid id, string name, string phoneNumber, string address, string city, string neighborhood, string number)
    {
        ValidateDomain(name, phoneNumber, address, city, neighborhood, number);
        Id = id;
    }
    public Customer(string name, string phoneNumber, string address, string city, string neighborhood, string number)
    {
        ValidateDomain(name, phoneNumber, address, city, neighborhood, number);
    }
    public void Update(string name, string phoneNumber, string address, string city, string neighborhood, string number)
    {
        ValidateDomain(name, phoneNumber, address, city, neighborhood, number);
    }
    public void ValidateDomain(string name, string phoneNumber, string address, string city, string neighborhood, string number)
    {
        DomainExceptionValidation.When(name.Length > 200, "O nome deve ter no máximo 200 caracteres");
        DomainExceptionValidation.When(phoneNumber.Length > 20, "O telefone deve ter no máximo 20 caracteres");
        DomainExceptionValidation.When(address.Length > 100, "O endereço deve ter no máximo 100 caracteres");
        DomainExceptionValidation.When(city.Length > 50, "A cidade deve ter no máximo 50 caracteres");
        DomainExceptionValidation.When(neighborhood.Length > 50, "O bairro deve ter no máximo 50 caracteres");
        DomainExceptionValidation.When(number.Length > 10, "O número deve ter no máximo 10 caracteres");

        Name = name;
        PhoneNumber = phoneNumber;
        Address = address;
        City = city;
        Neighborhood = neighborhood;
        Number = number;
    }

}
