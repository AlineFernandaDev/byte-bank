using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace backend.Domain.Models
{
    public class Balance
    {
        public decimal CurrentValue { get; private set; }
        public DateTime LastUpdateDate { get; private set; }
        public decimal InicialBalance { get; private set; }
        public decimal TotalCredits { get; private set; }
        public decimal TotalDebits { get; private set; }
        public List<Transaction> TransactionHistory { get; private set; }
        public string Currency { get; private set; }
        public Balance(decimal initialValue, string currency)
        {
            InicialBalance = initialValue;
            CurrentValue = initialValue;
            TotalCredits = 0;
            TotalDebits = 0;
            TransactionHistory = new();
            Currency = currency;
            LastUpdateDate = DateTime.Now;
        }
        public void UpdateBalance(decimal amount, Transaction transaction)
        {
            if (amount < 0 && CurrentValue + amount < 0)
            {
                throw new InvalidOperationException("Balance cannot be negative");
            }
            CurrentValue += amount;
            LastUpdateDate = DateTime.Now;
            if (amount > 0)
            {
                TotalCredits += amount;
            }
            else
            {
                TotalDebits += amount;
            }
            TransactionHistory.Add(transaction);
        }
        public override string ToString()
        {
            return $"Balance: {CurrentValue:C}, LastUpdateDate: {LastUpdateDate}";
        }
    }
}

