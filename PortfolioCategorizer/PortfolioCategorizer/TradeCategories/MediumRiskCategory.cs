using BankCategoryIdentifier.Interfaces;
using BankCategoryIdentifier.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankCategoryIdentifier.TradeCategories
{
    public class MediumRiskCategory : ITradeCategory
    {
        public string CategoryName { get => "MEDIUMRISK"; }

        public bool IsActive { get => true; }

        public bool ValidateCategory(ITrade trade)
        {
            return trade.Value > 1000000 && trade.ClientSector == ClientSector.Public;
        }
    }
}
