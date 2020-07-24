using System.Collections.Generic;
using System;
using PaymentContext.Shared.Entities;
using Flunt.Validations;

namespace PaymentContext.Domain.Entities
{
    public class Subscription : Entity
    {
        private readonly IList<Payment> _payments;

        public Subscription(DateTime? expireDate)
        {
            Active = true;
            CreateDate = DateTime.Now;
            LastUpdateDate = DateTime.Now;
            ExpireDate = expireDate;

            _payments = new List<Payment>();
        }

        public bool Active { get; private set; }
        public DateTime CreateDate { get; private set; }
        public DateTime LastUpdateDate { get; private set; }
        public DateTime? ExpireDate { get; private set; }
        public IReadOnlyCollection<Payment> Payments { get; private set; }

        public void AddPayment(Payment payment)
        {
            AddNotifications(new Contract()
                .Requires()
                .IsGreaterThan(DateTime.Now, payment.PaidDate, "Subscription.Payments", "Data atual não pode ser maior que a data do pagamento.")
            );

            if (Valid)
                _payments.Add(payment);
        }

        public void Activate()
        {
            Active = true;
            LastUpdateDate = DateTime.Now;
        }

        public void Inactivate()
        {
            Active = false;
            LastUpdateDate = DateTime.Now;
        }
    }
}