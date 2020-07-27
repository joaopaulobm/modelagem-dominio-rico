using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests.Entities
{
    [TestClass]
    public class DocumentTests
    {
        [TestMethod]
        public void ShouldReturnErrorWhenCNPJIsInvalid()
        {
            var document = new Document("123456", EDocumentType.CNPJ);
            Assert.IsTrue(document.Invalid);
        }

        [TestMethod]
        public void ShouldReturnSuccessWhenCNPJIsValid()
        {
            var document = new Document("46307212000117", EDocumentType.CNPJ);
            Assert.IsTrue(document.Valid);
        }

        [TestMethod]
        public void ShouldReturnErrorWhenCPFIsInvalid()
        {
            var document = new Document("123456", EDocumentType.CPF);
            Assert.IsTrue(document.Invalid);
        }

        [TestMethod]
        [DataTestMethod]
        [DataRow("24626315003")]
        [DataRow("78024384035")]
        public void ShouldReturnSuccessWhenCPFIsValid(string cpf)
        {
            var document = new Document(cpf, EDocumentType.CPF);
            Assert.IsTrue(document.Valid);
        }
    }
}
