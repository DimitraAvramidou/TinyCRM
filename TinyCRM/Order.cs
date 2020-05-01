using System;
using System.Collections.Generic;
using System.Text;
/// <summary>

namespace TinyCRM
{
    public class Order
    {
        public string OrderId { get; set; }
        public string DeliveryAddress { get; set; }
        public decimal TotalAmount { get; set; }
        public List<Product> ProductsToBuyList { get; set; }

        public Order(List<Product> pro)
        {
            ProductsToBuyList = new List<Product>();
            for(int i=0; i<pro.Count;i++)
            {
                ProductsToBuyList.Add(pro[i]);
            }
        }

        public decimal CountTotalAmount() 
        {
            for (int i = 0; i < ProductsToBuyList.Count; i++)
            {
                TotalAmount +=  ProductsToBuyList[i].Price;
            }
            return TotalAmount;
        }

        
    }

    
}
