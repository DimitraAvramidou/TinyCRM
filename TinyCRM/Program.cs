using System;
using System.Collections;
using System.Text;
using System.IO;
using System.Collections.Generic;

namespace TinyCRM
{
     class Program
    {
        static void Main(string[] args)
        {
            ArrayList ProductList = new ArrayList();
            ArrayList IdCodes = new ArrayList();
            List<Product> list = new List<Product>();
            var rand = new Random();
            foreach (var Line in File.ReadLines("C:/Users/Dimitra/TinyCRM/TinyCRM/products.csv"))
            {
                var count = IdCodes.Count;
                ProductList.Add(Line);
                var flag = false;
                foreach (var Id in IdCodes)
                {
                    if (Line.Split(';')[0].Equals(Id))
                    {
                        flag = true;
                        break;
                    }
                }
                if (flag==false) 
                {
                    IdCodes.Add(Line.Split(';')[0]);
 
                    list.Add(new Product());
                    list[count].ProductId = Line.Split(';')[0];
                    list[count].Name = Line.Split(';')[1];
                    list[count].Description = Line.Split(';')[2];
                    var item = new decimal(rand.NextDouble());
                    list[count].Price = Math.Round(item, 2);
                    Console.WriteLine(list[count].Name + " " + list[count].Price);
                }
                
            }
            
            
            var dimitra = new Customer("123456789");
            dimitra.Email = "dimitra@gmail.com";
            dimitra.VatNumber = "123456789";
            var check = dimitra.IsValidVatNumber(dimitra.VatNumber);
            if (check == true)
            {
                Console.WriteLine("valid ID");

            }
            else
            {
                Console.WriteLine("not valid ID");
            }
           
            var ckeck_for_email = dimitra.IsValidEmail(dimitra.Email);
            if (ckeck_for_email == true)
            {
                Console.WriteLine("valid Email");

            }
            else
            {
                Console.WriteLine("not valid Email");
            }

           
        }
        
    }
}
