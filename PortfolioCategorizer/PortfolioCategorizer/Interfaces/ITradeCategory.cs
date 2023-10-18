using System;
using System.Collections.Generic;
using System.Text;

namespace BankCategoryIdentifier.Interfaces
{
    public interface ITradeCategory
    {
        string CategoryName { get; }
        bool ValidateCategory(ITrade trade);
        bool IsActive { get; }
    }
}
