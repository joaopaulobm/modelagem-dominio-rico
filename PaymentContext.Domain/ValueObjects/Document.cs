using Flunt.Validations;
using PaymentContext.Domain.Enums;
using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObjects
{
    public class Document : ValueObject
    {
        public Document(string number, EDocumentoType eDocumentoType)
        {
            Number = number;
            EDocumentoType = eDocumentoType;

            AddNotifications(new Contract()
                .Requires()
                .IsTrue(Validate(), "Document.Number", "Documento inválido.")
            );
        }

        public string Number { get; set; }
        public EDocumentoType EDocumentoType { get; set; }

        private bool Validate()
        {
            if (EDocumentoType.Equals(EDocumentoType.CNPJ) && Number.Length == 14)
                return true;

            if (EDocumentoType.Equals(EDocumentoType.CPF) && Number.Length == 11)
                return true;

            return false;
        }
    }
}