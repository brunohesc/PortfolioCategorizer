using System;
using System.Collections.Generic;
using System.Text;

namespace BankCategoryIdentifier.Interfaces
{
    public interface ITradeCategorizer
    {
        List<string> CategorizePortfolio(List<ITrade> portfolio);
    }
}
