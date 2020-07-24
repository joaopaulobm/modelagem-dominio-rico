using System;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Domain.Entities
{
    public class PayPalPayment : Payment
    {
        public PayPalPayment(
            Email email,
            DateTime paidDate,
            DateTime? expireDate,
            decimal total,
            decimal totalPaid,
            string payer,
            Document document,
            Address address) : base(
                paidDate,
                expireDate,
                total, totalPaid,
                payer,
                document,
                address)
        {
            Email = email;
        }

        public Email Email { get; private set; }
    }
}