// See https://aka.ms/new-console-template for more information
using System;
using DigitalWallet.Core; // using namespace;

namespace DigitalWalletApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string appName = WalletInfo.GetAppName(); //static method
            Console.WriteLine(appName);
        }
    }
}

