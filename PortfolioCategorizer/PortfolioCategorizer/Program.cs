using BankCategoryIdentifier.Interfaces;
using BankCategoryIdentifier.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace BankCategoryIdentifier
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Add categories and their rules by adding classes that implement ITradeCategory, such as the ones in the TradeCategories folder ---->
            //Change the category rule by changing the ValidateCategory method
            //Remove them by either deleting the class or setting IsActve to false
            //No other action is required, the TradeCategorizer class will take it from there

            TradeCategorizer categorizer = new TradeCategorizer();

            List<ITrade> portfolio = new List<ITrade>
            {
                new Trade { Value = 2000000, ClientSector = ClientSector.Private },
                new Trade { Value = 400000, ClientSector = ClientSector.Public },
                new Trade { Value = 500000, ClientSector = ClientSector.Public },
                new Trade { Value = 3000000, ClientSector = ClientSector.Public }
            };

            List<string> tradeCategories = categorizer.CategorizePortfolio(portfolio);

            Console.WriteLine(System.Text.Json.JsonSerializer.Serialize(tradeCategories));
            Console.ReadLine();
        }


    }
}
