using Flunt.Validations;
using PaymentContext.Domain.Enums;
using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObjects
{
    public class Document : ValueObject
    {
        public Document(string number, EDocumentType eDocumentoType)
        {
            Number = number;
            EDocumentoType = eDocumentoType;

            AddNotifications(new Contract()
                .Requires()
                .IsTrue(Validate(), "Document.Number", "Documento inválido.")
            );
        }

        public string Number { get; set; }
        public EDocumentType EDocumentoType { get; set; }

        private bool Validate()
        {
            if (EDocumentoType.Equals(EDocumentType.CNPJ) && Number.Length == 14)
                return true;

            if (EDocumentoType.Equals(EDocumentType.CPF) && Number.Length == 11)
                return true;

            return false;
        }
    }
}