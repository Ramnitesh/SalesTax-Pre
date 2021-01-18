using Makkajai_SalesTax.Models;
using System;
using System.Collections.Generic;

namespace Makkajai_SalesTax
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a number of different type of item :");
            int numberOfdifferentItem = Convert.ToInt32(Console.ReadLine());
            List<MSalesItem> mSalesItems = new List<MSalesItem>();
            Console.WriteLine("Please read instructions :");
            Console.WriteLine("Item type can be Book or Food or Medical or Other.");
            for (int i = 0; i < numberOfdifferentItem; i++)
            {
                int id = i + 1;
                Console.WriteLine("Item(" + id + ") Details :");

                Console.WriteLine("Enter Item(" + id + ") Name = ");
                string ItemName = Console.ReadLine();
                
                Console.WriteLine("Enter Item(" + id + ") type = ");
                string ItemType = Console.ReadLine();
                
                Console.WriteLine("Enter Item(" + id + ") Price = ");
                string Price = Console.ReadLine();
                
                Console.WriteLine("Enter Item(" + id + ") is imported then 1 or 0 = ");
                int IsImported = Convert.ToInt32(Console.ReadLine());
                
                Console.WriteLine("Enter quantity of this item(" + id + ") = ");
                int NumberOfItem = Convert.ToInt32(Console.ReadLine());
                mSalesItems.Add(new MSalesItem
                {
                    ItemId = id,
                    ItemName = ItemName,
                    ItemType = ItemType,
                    Price = Price,
                    IsImported = Convert.ToBoolean(IsImported),
                    NumberOfItem = NumberOfItem
                });
            }
            Console.WriteLine("Input: ");
            for (int i = 0; i < numberOfdifferentItem; i++)
            {
                Console.WriteLine(mSalesItems[i].NumberOfItem + " " + mSalesItems[i].ItemName + " at " + Convert.ToDecimal(mSalesItems[i].Price));
            }
            decimal TotalTax = 0;
            decimal Total = 0;
            Console.WriteLine("Output: ");
            for (int i = 0; i < numberOfdifferentItem; i++)
            {
                decimal itemTaxPrice = 0;
                if (mSalesItems[i].ItemType.ToLower() == "food" || mSalesItems[i].ItemType.ToLower() == "book" || mSalesItems[i].ItemType.ToLower() == "medical")
                {
                    decimal WithoutcellingVal = (Convert.ToDecimal(mSalesItems[i].Price) * (mSalesItems[i].IsImported == true ? 5 : 0) * mSalesItems[i].NumberOfItem) / 100;
                    itemTaxPrice = Math.Ceiling(WithoutcellingVal * 20) / 20;
                }
                else
                {
                    decimal WithoutcellingVal = (Convert.ToDecimal(mSalesItems[i].Price) * (10 + (mSalesItems[i].IsImported == true ? 5 : 0)) * mSalesItems[i].NumberOfItem) /100;
                    itemTaxPrice = Math.Ceiling(WithoutcellingVal * 20) / 20;
                }
                TotalTax =TotalTax + itemTaxPrice;
                Total = Total + Convert.ToDecimal(mSalesItems[i].Price) + itemTaxPrice;
                Console.WriteLine(mSalesItems[i].ItemType + " type : " + mSalesItems[i].NumberOfItem + (mSalesItems[i].IsImported == true ? " imported " : " ") + mSalesItems[i].ItemName + ": " + Math.Round((Double)(Convert.ToDecimal(mSalesItems[i].Price) + itemTaxPrice), 2));
            }
            Console.WriteLine("Sales Taxes: " + TotalTax);
            Console.WriteLine("Total: " + Total);
        }
    }
}
