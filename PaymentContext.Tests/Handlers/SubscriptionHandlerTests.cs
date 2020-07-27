using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Commands;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.Handlers;
using PaymentContext.Tests.Mocks;

namespace PaymentContext.Tests
{
    [TestClass]
    public class SubscriptionHandlerTests
    {
        [TestMethod]
        public void ShouldReturnErrorWhenDocumentExists()
        {
            var handler = new SubscriptionHandler(new FakeStudentRepository(), new FakeEmailService());
            var command = new CreateBoletoSubscriptionCommand();
            command.FirstName = "User";
            command.LastName = "Teste";
            command.Document = "99999999999";
            command.Email = "userteste@msteste.com";
            command.BarCode = "123456789";
            command.BoletoNumber = "1234654987";
            command.PaymentNumber = "123121";
            command.PaidDate = DateTime.Now;
            command.ExpireDate = DateTime.Now.AddMonths(1);
            command.Total = 60;
            command.TotalPaid = 60;
            command.Payer = "User Teste";
            command.PayerDocument = "12345678911";
            command.PayerDocumentType = EDocumentType.CPF;
            command.PayerEmail = "payeruser@msteste.com";
            command.Street = "Rua teste";
            command.Number = "123";
            command.Neighborhood = "Centro";
            command.City = "Belo Horizonte";
            command.State = "MG";
            command.Country = "Brasil";
            command.ZipCode = "35000000";

            handler.Handle(command);
            Assert.AreEqual(false, handler.Valid);
        }
    }
}