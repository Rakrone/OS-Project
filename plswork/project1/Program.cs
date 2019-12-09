using System;
using System.Threading;

namespace CriticalSectionDemo
{
    class Program

    {
        static void Main(string[] args)
        {
            Console.WriteLine("Pick up an option.");
            Console.WriteLine("1) Use unsynchronized transaction");
            Console.WriteLine("2) Use synchronized transaction with Monitor.");
            int choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1: NonSyncTransaction(); break;
                case 2: MonitorTransaction(); break;
                default: Console.WriteLine("Wrong Input"); break;
            }
        }

        public static Transaction GetAccountInfo()
        {            
            Console.Write("Enter balance: ");
            decimal balance = decimal.Parse(Console.ReadLine());
            Console.Write("Enter increase: ");
            decimal increase = decimal.Parse(Console.ReadLine());
            Console.Write("Enter decrease: ");
            decimal decrease = decimal.Parse(Console.ReadLine());


            return  new Transaction(new Account(balance), increase, decrease);
        }


        public static void MonitorTransaction()
        {
            Transaction tran = GetAccountInfo();

            SyncWithMonitor syncTran = new SyncWithMonitor(tran);

            Thread th1 = new Thread(new ThreadStart(syncTran.IncreaseSync));
            th1.Name = "Increase";
            th1.Start();
            Thread th2 = new Thread(new ThreadStart(syncTran.DecreaseSync));
            th2.Name = "Decrease";
            th2.Start();
        }
        
        public static void NonSyncTransaction()
        {
            Transaction tran = GetAccountInfo();

            Thread th1 = new Thread(new ThreadStart(tran.DecreaseAccountBalance));
            th1.Start();
            Thread th2 = new Thread(new ThreadStart(tran.IncreaseAccountBalance));
            th2.Start();

            th1.Join();
            th2.Join();
      

            Console.WriteLine("Current Account balance: {0}", tran.GetAccount().GetBalance());
        }
    }
}
