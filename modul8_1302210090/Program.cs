using modul8_1302210090;
using System;
using System.Collections.Generic;
using System.Configuration;

class Program
{
    static void Main(string[] args)
    {

        BankTransferConfig config = BankTransferConfig.LoadFromFile("bank_transfer_config.json");

        if (config.Language == "en")
        {
            Console.WriteLine("Please insert the amount of money to transfer:");
        }
        else if (config.Language == "id")
        {
            Console.WriteLine("Masukkan jumlah uang yang akan di-transfer:");
        }

        decimal amount = Convert.ToDecimal(Console.ReadLine());

        decimal fee;
        if (amount < config.TransferThreshold)
        {
            fee = config.TransferLowFee;
        }
        else
        {
            fee = config.TransferHighFee;
        }
        Console.WriteLine("Available transfer methods:");
        foreach (string method in config.TransferMethods)
        {
            Console.WriteLine(method);
        }
        Console.WriteLine("Confirmation:");
        if (config.Language == "en")
        {
            Console.WriteLine("Are you sure you want to transfer {0:C}?", amount);
        }
        else if (config.Language == "id")
        {
            Console.WriteLine("Apakah Anda yakin ingin mentransfer {0:C}?", amount);
        }
        Console.WriteLine("Transfer fee: {0:C}", fee);
    }
}
