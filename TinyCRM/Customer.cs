using System;
using System.Collections.Generic;
using System.Text;
/// <summary>
/// Summary description for Class1
/// </summary>
/// 
namespace TinyCRM
{
	public class Customer
    {
        public string CustomerId { get; set; }
        public string Email {get; set;}
        public string VatNumber { get; set; }
        public string Phone { get; set; }
        public decimal TotalGross { get; private set; }
        public DateTime Created { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string IsActive { get; set; }
        public int Age { get; set; }

        public List<Order> OrderList { get; set; }

        
        public Customer()
        {
            OrderList = new List<Order>();
            //if (!IsValidVatNumber(vatNumber))
            //{
            //    throw new Exception("Invalid VatNumber");
            //}
            //VatNumber = vatNumber;
            Created = DateTime.Now;
        }
        
        public bool IsAdult()
        {
            return Age > 18;
        }

        public bool IsHighValuedCustomer()
        {
            return TotalGross > 10000M;
        }

        public void SetPhone(string phone)
        {
            Phone = phone;
        }

        public bool IsValidVatNumber(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return false;
            }

            id = id.Trim();

            if (id.Length != 9)
            {
                return false;
            }

            if (!int.TryParse(id, out int number))
            {
                return false;
            }

            return true;
        }

        public  bool IsValidEmail(string email)
        {
            if (!string.IsNullOrEmpty(email))
            {
                email = email.Trim();
                if (email.Contains("@"))
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            return false;

        }

        public void MakeAnOrder(List<Product> productlist)
        {
            var order = new Order(productlist);
            OrderList.Add(order);
        }

        public decimal CountOrdersTotalAmount()
        {
            decimal CountAmountOfOrder=0.0M;
            for (int i = 0; i < OrderList.Count; i++)
            {
                CountAmountOfOrder = OrderList[i].CountTotalAmount();
            }
            return CountAmountOfOrder;
        }


    }

}

