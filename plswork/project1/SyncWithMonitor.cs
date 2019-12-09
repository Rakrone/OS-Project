using System;
using System.Threading;

namespace CriticalSectionDemo
{
    class SyncWithMonitor
    {
        private Transaction transaction;

        public SyncWithMonitor(Transaction transaction)
        {
            this.transaction = transaction;
        }

        public void IncreaseSync()
        {
            Monitor.Enter(this.transaction);
            try
            {
                Console.WriteLine("Enter Thread: {0}", Thread.CurrentThread.Name);
                this.transaction.IncreaseAccountBalance();
            }
            finally
            {
                Monitor.Exit(this.transaction);
            }
        }

        public void DecreaseSync()
        {
            Monitor.Enter(this.transaction);
            try
            {
                Console.WriteLine("Enter Thread: {0}", Thread.CurrentThread.Name);
                this.transaction.DecreaseAccountBalance();
            }
            finally
            {
                Monitor.Exit(this.transaction);
            }
        }
    }
}
