﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BankApplication
{
    /// <summary>
    /// Handles all logic for customer.
    /// </summary>
    public static class CustomerLogic
    {
        /// <summary>
        /// A list with the banks existing customers. 
        /// </summary>
        public static ObservableCollection<Customer> Customers { get; set; } = new ObservableCollection<Customer>  
            {
            new Customer(8409039567, "Lars-Åke Cederlund"),
            new Customer(7812230654, "Florence Liljedahl"),
            new Customer(7112151688, "Henrietta Malmborg"),
            new Customer(9204021234, "Veronica Smedberg-Bolander"),
            new Customer(9301200938, "Maj Sahlén"),
            new Customer(9912020873, "Carl-Johan Sterner"),
            };
        /// <summary>
        /// Makes sure the new customers social security number is unique. 
        /// </summary>
        public static bool CustomerExists (long ssn) 
        {
            foreach (Customer customer in Customers)
            {
                if (customer.SSN == ssn)
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Adds new customer. 
        /// </summary>
  
        public static bool AddCustomer(string name, long ssn)  
        {
            //Makes sure the social security number doesn't already exist. 
            if (CustomerExists(ssn)) 
            {
                return false;
            }
            else
            {
                //Only allows letters and spaces in the name box. 
                Regex regexLetters = new Regex(@"^[a-öA-Ö ]+$");     
                MatchCollection matches = regexLetters.Matches(name);

                //Only allows numbers in the social security box. 
                Regex regexNumbers = new Regex(@"^[0-9]+$");       
                MatchCollection matches2 = regexNumbers.Matches(ssn.ToString());
                if (matches.Count > 0 && matches2.Count > 0 && ssn.ToString().Length == 10 && name != "")
                {
                    Customers.Add(new Customer(ssn, name));
                    return true;
                }
                return false;
            }
        }
        /// <summary>
        /// Changes the name of a customer.
        /// </summary>
        public static bool ChangeCustomerName(Customer customer, string name) 
        {
            try
            {
                //Only allows letters in the name box. 
                Regex regex = new Regex(@"^[a-öA-Ö ]+$");        
                MatchCollection matches = regex.Matches(name);
                if (matches.Count > 0)
                {
                    customer.Name = name;
                    return true;
                }
            }
            catch (Exception) { }            
            return false;
        }

        /// <summary>
        /// Sets a password that is required to login on Startpage. 
        /// </summary>
        public static bool Login(string username, string password) 
        {
            string input = "admin";
            if (username == input && password == input)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Prints the account information upon removal.
        /// </summary>
        public static string RemoveCustomer(Customer customer) 
        {
            string removedCustomer = "Accounts removed: \n";

            try
            {
                foreach (var item in customer.Accounts)
                {
                    removedCustomer += AccountLogic.PrintAccountInfo(item) + "\n";
                }
                Customers.Remove(customer);
            }
            catch (Exception) { }
            return removedCustomer;
        }  
    }
}