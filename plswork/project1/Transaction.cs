using System;
using System.Threading;

namespace CriticalSectionDemo
{
    class Transaction
    {
        private Account bankAccount;

        private decimal increaseAmount;

        private decimal decreaseAmount;

        public Transaction(Account bankAccount, decimal increaseAmount, decimal decreaseAmount)
        {
            this.bankAccount = bankAccount;
            this.increaseAmount = increaseAmount;
            this.decreaseAmount = decreaseAmount;

            Console.WriteLine("Opening multiple threads that will try to edit the balance.");
        }

        public void DecreaseAccountBalance()
        {
            for (int i = 0; i < 5; i++)
            {
                this.bankAccount.DecreaseBalance(this.decreaseAmount);
                Thread.Sleep(500);
            }
        }

        public void IncreaseAccountBalance()
        {
            for (int i = 0; i < 5; i++)
            {
                this.bankAccount.IncreaseBalance(this.increaseAmount);
                Thread.Sleep(500);
            }
        }

        public Account GetAccount()
        {
            return this.bankAccount;
        }
    }
}
