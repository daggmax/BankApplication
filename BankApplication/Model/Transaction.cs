﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApplication
{
    /// <summary>
    /// Handles transaction information. 
    /// </summary>
    public class Transaction
    {
        public long AccountID { get; set; }
        public string Time { get; set; }
        public string TransactionType { get; set; }
        public decimal Amount { get; set; }
        public decimal NewBalance { get; set; }

        public Transaction(long accountID, string transactionType, decimal amount, decimal newBalance)
        {
            AccountID = accountID;
            TransactionType = transactionType;
            Amount = amount;
            NewBalance = newBalance;
            Time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

        }
        /// <summary>
        /// Properties made for GUI. 
        /// </summary>
        public string DisplayAccID { get { return $"Account ID: {AccountID}"; } }
        public string DisplayTime { get { return $"Time of transaction: {Time}"; } }
        public string DisplayType { get { return $"{TransactionType}"; } }
        public string DisplayAmount { get { return $"Amount: {Amount} SEK"; } }
        public string DisplayNewBalance { get { return $"Balance: {NewBalance} SEK"; } }
    }
}
