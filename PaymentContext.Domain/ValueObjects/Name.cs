using Flunt.Validations;
using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObjects
{
    public class Name : ValueObject
    {
        public Name(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;

            AddNotifications(new Contract()
                .Requires()
                .HasMinLen(FirstName, 2, "Name.FirstName", "Nome deve conter pelo menos 2 caracteres.")
                .HasMinLen(LastName, 2, "Name.LastName", "Sobre nome deve conter pelo menos 2 caracteres.")
                .HasMaxLen(FirstName, 50, "Name.FirstName", "Nome deve conter pelo menos 50 caracteres.")
                .HasMaxLen(LastName, 50, "Name.LastName", "Sobre nome deve conter pelo menos 50 caracteres.")
            );
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
    }
}