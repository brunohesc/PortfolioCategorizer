using BankCategoryIdentifier.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace BankCategoryIdentifier
{
    public class TradeCategorizer : ITradeCategorizer
    {
        private readonly List<ITradeCategory> _activeCategories = new List<ITradeCategory>();

        public TradeCategorizer() 
        {
            // I don't normally use reflection due to performance concerns but it felt appropriate to use it here since you then won't have to touch this class when 
            // adding/changing/deleting categories and rules. Besides, this is only going to run once on startup

            IEnumerable<Type> typesThatImplementITradeCategory = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(assembly => assembly.GetTypes())
                .Where(type => typeof(ITradeCategory).IsAssignableFrom(type) && !type.IsInterface);

            foreach (Type tradeCategoryType in typesThatImplementITradeCategory)
            {
                try
                {
                    var category = Activator.CreateInstance(tradeCategoryType);

                    if (category != null && (category as ITradeCategory).IsActive)
                        _activeCategories.Add((ITradeCategory)category);
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Error obtaining configs for category rule {tradeCategoryType.Name}: {ex.Message}");
                    Console.ResetColor();
                }

            }
        }

        /// <summary>
        /// Iterates through all implementations of ITradeCategory and returns the name of the first category for which the rule applies to the trade
        /// </summary>
        /// <param name="trade"></param>
        /// <returns></returns>
        private string GetTradeCategory(ITrade trade)
        {
            foreach(var category in _activeCategories)
            {
                try
                {
                    if (trade != null && category.ValidateCategory(trade))
                        return category.CategoryName;
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Error validating trade category rule for category {category.CategoryName} for trade {System.Text.Json.JsonSerializer.Serialize(trade)}: {ex.Message}");
                    Console.ResetColor();
                }
            }

            return string.Empty; // the spec doesn't say what to do if no category rules apply
        }

        public List<string> CategorizePortfolio(List<ITrade> portfolio)
        {
            List<string> result = new List<string>();
            foreach (ITrade trade in portfolio)
            {
                result.Add(GetTradeCategory(trade));
            }

            return result;
        }
    }
}
