using backend.Domain.Models;
using backend.Domain.Enums;

Transaction[] randomTransactions = new Transaction[] {
    new Transaction{
        Amount = 100,
        TransactionType = TransactionType.DEPOSIT
    },
    new Transaction{
        Amount = 50,
        TransactionType = TransactionType.WITHDRAWAL
    },
    new Transaction{
        Amount = 10,
        TransactionType = TransactionType.TRANSFER
    }
;

Account account = new Account{
    Holder = "Lucas",
    Balance = 100,
    Transactions = randomTransactions
};










// Transaction transaction = new Transaction
// {
//     amount = 100,
//     TransactionType = TransactionType.DEPOSIT
// };