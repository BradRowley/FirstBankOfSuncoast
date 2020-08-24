using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;

namespace FirstBankOfSuncoast
{
    class Transaction
    {
        // public string Name { get; set; }
        public int CheckingAccount { get; set; }
        public int SavingsAccount { get; set; }
        public int Deposit { get; set; }
        public int Withdraw { get; set; }



        public string Description()
        {
            var description = $"Your Checking amount is {CheckingAccount} and your savings amount is {SavingsAccount}";

            return description;
        }
        // public string Description2()
        // {
        //     var description2 = $"";
        //     return description2;



        // }

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////


        // Need a way to make only postive number

        // Still need to get how you store the different transactions instead of just one list of Transactions

        // Do I need multiple csv files?

        // Need to put in withdraw System

        // Get the non header to show in csv to work

        // need option to see account for both all transactions

        class Program
        {
            static void Main(string[] args)
            {
                var transactions = new List<Transaction>();
                var savingsaccount = new List<int>();
                var checkingaccount = new List<int>();





                if (File.Exists($"transactions.csv"))
                {

                    var fileReader = new StreamReader("transactions.csv");
                    var csvReader = new CsvReader(fileReader, CultureInfo.InvariantCulture);
                    transactions = csvReader.GetRecords<Transaction>().ToList();
                    // csvReader.Configuration.HasHeaderRecord = false;

                }



                Console.WriteLine();
                Console.WriteLine("Welcome to First Bank of Suncoast");
                Console.WriteLine($"{transactions}");
                Console.WriteLine();
                Console.WriteLine();


                var isRunning = true;
                while (isRunning)
                {

                    Console.WriteLine("Menu options");
                    Console.WriteLine(" Deposit Savings -   make a deposit");
                    Console.WriteLine(" Deposit Checking -  make a deposit");
                    Console.WriteLine(" Withdraw Savings -  make a withdraw");
                    Console.WriteLine(" Withdraw Checking - make a withdraw");
                    Console.WriteLine(" See Account - See amount of savings and checking in your account");
                    Console.WriteLine(" Quit - Quit the program");
                    Console.WriteLine();
                    Console.Write("Option: ");
                    var option = Console.ReadLine();

                    if (option == "Deposit Savings")
                    {
                        Console.Write("Deposit Savings Amount: ");
                        var depositSavingsString = Console.ReadLine();
                        var depositsavings = int.Parse(depositSavingsString);
                        savingsaccount.Add(depositsavings);
                        foreach (var despositsavings in savingsaccount)
                        {
                            Console.WriteLine();
                        }

                        // Only counts number instead of the value WRONG
                        Console.WriteLine($"Our list has: {savingsaccount.Count()} entries");
                        Console.WriteLine("------------------");


                    }
                    if (option == "Deposit Checking")
                    {
                        Console.Write("Deposit Checking Amount: ");
                        var depositCheckingString = Console.ReadLine();
                        var depositchecking = int.Parse(depositCheckingString);
                        checkingaccount.Add(depositchecking);

                        foreach (var despositchecking in checkingaccount)
                        {
                            Console.WriteLine();
                        }
                        Console.WriteLine($"Our list has: {checkingaccount.Count()} entries");
                        Console.WriteLine("------------------");

                    }

                    if (option == "Quit")
                    {
                        isRunning = false;
                    }
                    if (option == "Withdraw Saving")
                    {


                    }
                    if (option == "Withdraw Checking")
                    {


                    }

                    if (option == "See Account")
                    {
                        // Console.WriteLine(transactions.Description);

                    }

                    var fileWriter = new StreamWriter("transactions.csv");

                    var csvWriter = new CsvWriter(fileWriter, CultureInfo.InvariantCulture);

                    csvWriter.WriteRecords(transactions);

                    fileWriter.Close();

                    // var fileWriter2 = new StreamWriter("savingsaccount.csv");

                    // var csvWriter2 = new CsvWriter(fileWriter, CultureInfo.InvariantCulture);

                    // csvWriter.WriteRecords(savingsaccount);

                    // fileWriter.Close();

                    // var fileWriter3 = new StreamWriter("checkingaccount.csv");

                    // var csvWriter3 = new CsvWriter(fileWriter, CultureInfo.InvariantCulture);

                    // csvWriter.WriteRecords(checkingaccount);

                    // fileWriter.Close();



                }

                Console.WriteLine("... Have a nice day ...");
            }
        }
    }
}

