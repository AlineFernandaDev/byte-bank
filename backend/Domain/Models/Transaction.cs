using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Domain.Enums;

namespace backend.Models
{
    public class Transaction
    {
        public double Amount { get; set; }
        public TransactionType TransactionType { get; set; }
    }
}