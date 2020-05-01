using System;
using System.Collections;
using System.Text;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace TinyCRM
{
     class Program
    {
        static void Main(string[] args)
        {
            List<string> ProductListFromFile = new List<string>();
            List<string> IdCodes = new List<string>(); 
            List<Product> list = new List<Product>();
            var rand = new Random();
   
            foreach (var Line in File.ReadLines("products.csv"))
            {
                string[] value;
                var count = IdCodes.Count;
                ProductListFromFile.Add(Line);

                value = Line.Split(';');
                var ProductCode = value[0];

                var IsDublicate = IdCodes.SingleOrDefault(prod => prod.Equals(ProductCode));
                if(IsDublicate != null)
                {
                    continue;
                }
               
                IdCodes.Add(ProductCode);
 
                list.Add(new Product());
                list[count].ProductId = ProductCode;
                list[count].Name = value[1];
                list[count].Description = value[2];
                var item = new decimal(rand.NextDouble() * 100);
                list[count].Price = Math.Round(item, 2);               
            }
            
            
            
            //var check = customer1.IsValidVatNumber(customer1.VatNumber);
            //if (check == true)
            //{
            //    Console.WriteLine("valid ID");

            //}
            //else
            //{
            //    Console.WriteLine("not valid ID");
            //}
           
            //var ckeck_for_email = customer1.IsValidEmail(customer1.Email);
            //if (ckeck_for_email == true)
            //{
            //    Console.WriteLine("valid Email");

            //}
            //else
            //{
            //    Console.WriteLine("not valid Email");
            //}

           
            
            List<Product> RandomList = new List<Product>();
            List<Customer> CustomerList = new List<Customer>();
            List<string> MostSold = new List<string>();
            List<decimal> Amounts = new List<decimal>();
            Random rnd = new Random();
            decimal MaxPay = 0.0M;
            string BestCustomerName=null;
            string BestCustomerSurname = null;

            for (int y = 0; y < 2; y++)
            {
                CustomerList.Add(new Customer());

                Console.WriteLine("Please,enter your First Name");
                CustomerList[y].FirstName = Console.ReadLine();
                Console.WriteLine("Please,enter your Last Name");
                CustomerList[y].LastName = Console.ReadLine();

                for (int i = 0; i < 10; i++)
                {
                    string s = IdCodes[rnd.Next(IdCodes.Count)];
                    foreach (var id in list)
                    {
                        if (s.Equals(id.ProductId))
                        {
                            RandomList.Add(id);
                            MostSold.Add(id.ProductId);
                        }
                    }
                }
                CustomerList[y].MakeAnOrder(RandomList);
                var Pay = CustomerList[y].CountOrdersTotalAmount();
                if (Pay > MaxPay)
                {
                    MaxPay = Pay;
                    BestCustomerName = CustomerList[y].FirstName;
                    BestCustomerSurname = CustomerList[y].LastName;
                }
                RandomList.Clear();
               // Console.WriteLine(Pay);
            }
            if (!string.IsNullOrEmpty(BestCustomerName))
            {
                Console.WriteLine($"The most valuable Customer is: {BestCustomerName} {BestCustomerSurname}");
            }
            
        }

        
    }
}
