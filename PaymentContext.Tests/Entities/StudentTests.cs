using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests.Entities
{
    [TestClass]
    public class StudentTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var name = new Name("João Paulo", "Mendes");

            var email = new Email("joaopaulodev@baltateste.com");
            var document = new Document("12345678912", EDocumentoType.CPF);
            var student = new Student(name, document, email);

            var subscription = new Subscription(null);
            student.AddSubscription(subscription);
        }
    }
}
