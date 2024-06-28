using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
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
        public Balance Balance { get; private set; }
        public List<Transaction> Transactions { get; private set; } = new();
        public Account()
        {
            Balance = new Balance(0, "BRL");
        }
        public bool Deposit(decimal amount)
        {
            if (amount <= 0)
            {   
                Console.WriteLine("Amount must be greater than zero");
                return false;
            }
            var transaction = new Transaction(amount, TransactionType.DEPOSIT, TransactionDirection.INCOME);
            Balance.UpdateBalance(amount, transaction);
            Transactions.Add(transaction);
            return true;
        }
        public bool Transfer(decimal amount, Account destinationAccount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Operation not allowed");
                return false;
            }
            var transaction = new Transaction(amount, TransactionType.TRANSFER, TransactionDirection.EXPENSE);
            Balance.UpdateBalance(-amount, transaction);
            destinationAccount.ReceivedTransfer(amount);
            Transactions.Add(transaction);
            return true;
        }
        public bool Withdraw(decimal amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Operation not allowed");
                return false;
            }
            var transaction = new Transaction(amount, TransactionType.WITHDRAW, TransactionDirection.EXPENSE);
            Balance.UpdateBalance(-amount, transaction);
            Transactions.Add(transaction);
            return true;
        }
        public void ReceivedTransfer(decimal amount)
        {
            if(amount <= 0)
            {
                Console.WriteLine("Amount must be greater than zero");
                return;
            }
            var transaction = new Transaction(amount, TransactionType.TRANSFER, TransactionDirection.INCOME);
            Balance.UpdateBalance(amount, transaction);
            Transactions.Add(transaction);
        }
        public override string ToString()
        {
            string aux = "";
            Transactions.ForEach(transaction => aux += $"{Id} - {Customer} - {transaction} - {Balance} \n");
            return aux;
        }
    }
}
