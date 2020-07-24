using System;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Domain.Entities
{
    public class CreditCardPayment : Payment
    {
        public CreditCardPayment(
            string cardHolderName,
            string lastCardNumbers,
            string lastTransactionNumber,
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
            CardHolderName = cardHolderName;
            LastCardNumbers = lastCardNumbers;
            LastTransactionNumber = lastTransactionNumber;
        }

        public string CardHolderName { get; private set; }
        public string LastCardNumbers { get; private set; }
        public string LastTransactionNumber { get; private set; }
    }
}