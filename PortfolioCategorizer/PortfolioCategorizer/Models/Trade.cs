using BankCategoryIdentifier.Interfaces;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace BankCategoryIdentifier.Models
{
    public class Trade : ITrade
    {
        public double Value { get; set; }
        public string ClientSector { get; set; }
    }

    public static class ClientSector
    {
        public static string Public = "Public";
        public static string Private = "Private";
    }
}
