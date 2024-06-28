using backend.Domain.Models;
using backend.Domain.Enums;
using System.Transactions;
Account c1 = new(){
    Customer = "Aline",
};

Account c2 = new(){
    Customer = "Bruno",
};
c1.Deposit(200);
c1.Transfer(50, c2);
c1.Withdraw(60);
c1.ReceivedTransfer(10);
Console.WriteLine(c1.ToString());
Console.WriteLine(c2.ToString());

