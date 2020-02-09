using AbstractShopListImplement.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractShopListImplement
{
    public class DataListSingleton
    {
        private static DataListSingleton instance;
        public List<Mebel> Mebels { get; set; }
        public List<Order> Orders { get; set; }
        public List<Product> Products { get; set; }
        public List<ProductMebel> ProductMebels { get; set; }
        private DataListSingleton()
        {
            Mebels = new List<Mebel>();
            Orders = new List<Order>();
            Products = new List<Product>();
            ProductMebels = new List<ProductMebel>();
        }
        public static DataListSingleton GetInstance()
        {
            if (instance == null)
            {
                instance = new DataListSingleton();
            }
            return instance;
        }
    }
}
