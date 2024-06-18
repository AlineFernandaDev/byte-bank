using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Domain.Models
{
    public class Account
    {
        public string Holder { get; set; }
        public double Balance { get; set; }
        public Transaction[] Transactions { get; set; }
    }
}