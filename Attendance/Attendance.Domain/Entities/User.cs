using Attendance.Domain.Validation;

namespace Attendance.Domain.Entities
{
    public class User
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }

        public User(Guid id, string name, string email)
        {
           DomainExceptionValidation.When(id == Guid.Empty, "O id não pode ser vazio");
           Id = id;
           ValidateDomain(name, email);
        }
        public User(string name, string email)
        {
            ValidateDomain(name, email);
        }

        public void ChangePassword(byte[] passwordHash, byte[] passwordSalt)
        {
            PasswordHash = passwordHash;
            PasswordSalt = passwordSalt;
        }

        private void ValidateDomain(string name, string email)
        {
            DomainExceptionValidation.When(name == null, "O nome é obrigatório");
            DomainExceptionValidation.When(email == null, "O email é obrigatório");
            DomainExceptionValidation.When(name.Length > 250, "O nome não pode ultrapassar 250 caracteres");
            DomainExceptionValidation.When(email.Length > 200, "O email não pode ultrapassar 200 caracteres");

            Name = name;
            Email = email;

        }
    }
}
