using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Domain;
using backend.Domain.Enums;

namespace backend.Domain.Models
{
    public class Transaction
    {
        public decimal Balance;
        public TransactionType TransactionType;
        public TransactionDirection TransactionDirection;
        public DateTime Date { get; set; } = DateTime.Now;
        public Transaction(decimal amount, TransactionType transactionType, TransactionDirection transactionDirection)
        {
            Balance = amount;
            TransactionType = transactionType;
            TransactionDirection = transactionDirection;
        }

        }
    }
