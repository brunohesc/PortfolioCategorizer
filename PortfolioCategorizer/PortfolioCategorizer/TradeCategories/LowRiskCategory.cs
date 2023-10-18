using BankCategoryIdentifier.Interfaces;
using BankCategoryIdentifier.Models;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace BankCategoryIdentifier.TradeCategories
{
    public class LowRiskCategory : ITradeCategory
    {
        public string CategoryName { get => "LOWRISK"; }

        public bool IsActive { get => true; }

        public bool ValidateCategory(ITrade trade)
        {
            return trade.Value < 1000000 && trade.ClientSector == ClientSector.Public;
        }
    }
}
