using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests.Entities
{
    [TestClass]
    public class StudentTests
    {
        private readonly Name _name;
        private readonly Document _document;
        private readonly Email _email;
        private readonly Address _address;
        private readonly Student _student;

        public StudentTests()
        {
            _name = new Name("João Paulo", "Mendes");
            _email = new Email("joaopaulodev@baltateste.com");
            _document = new Document("12345678912", EDocumentType.CPF);
            _address = new Address("Rua Teste", "100", "Centro", "Divinópolis", "MG", "Brasil", "35000000");
            _student = new Student(_name, _document, _email);
        }

        [TestMethod]
        public void ShouldReturnErrorWhenHadActiveSubscription()
        {
            var subscription = new Subscription(null);
            var payment = new PayPalPayment("123456", _email, DateTime.Now, DateTime.Now.AddDays(3), 100, 100, "User", _document, _address);

            subscription.AddPayment(payment);
            _student.AddSubscription(subscription);
            _student.AddSubscription(subscription);

            Assert.IsTrue(_student.Invalid);
        }

        [TestMethod]
        public void ShouldReturnErrorWhenSubscriptionHasNoPayment()
        {
            var subscription = new Subscription(null);
            _student.AddSubscription(subscription);

            Assert.IsTrue(_student.Invalid);
        }


        [TestMethod]
        public void ShouldReturnSuccessWhenAddSubscription()
        {
            var subscription = new Subscription(null);
            var payment = new CreditCardPayment("User Card", "123", "123", DateTime.Now, DateTime.Now.AddDays(3), 100, 100, "User", _document, _address);

            subscription.AddPayment(payment);
            _student.AddSubscription(subscription);

            Assert.IsTrue(_student.Valid);
        }
    }
}
