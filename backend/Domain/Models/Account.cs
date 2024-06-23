using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using backend.Domain.Enums;

namespace backend.Domain.Models
{
    public class Account
    {
        private static int _idCounter = 1;
        public readonly int Id = _idCounter++;
        public string Customer { get; set; } = null!;
        public decimal Balance { get; private set; }
        public List<Transaction> Transactions { get; private set; } = new();
        public Account(decimal initialBalance)
        {
            Balance = initialBalance;
        }
        public bool Deposit(decimal amount){
            Balance += amount;
            Transactions.Add(new Transaction(amount, TransactionType.DEPOSIT, TransactionDirection.INCOME));
            return true;
        }
        public bool Transfer(decimal amount, Account destinationAccount){
            if(Balance < amount){
                return false;
            }
            Balance -= amount;
            destinationAccount.Balance += amount;
            Transactions.Add(new Transaction(amount, TransactionType.TRANSFER, TransactionDirection.EXPENSE));
            return true;
        }
        public bool Withdraw(decimal amount){
            if(Balance < amount){
                return false;
            }
            Balance -= amount;
            Transactions.Add(new Transaction(amount, TransactionType.WITHDRAW, TransactionDirection.EXPENSE));
            return true;
        }
        public void ReceivedTransfer(decimal amount){
            Balance += amount;
            Transactions.Add(new Transaction(amount, TransactionType.TRANSFER, TransactionDirection.INCOME));
            return;
        }
        public override string ToString()
        {
            return $"Account {Id} - Customer: {Customer} - Balance: {Balance}";
        }

    }

}
