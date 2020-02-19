using AbstractShopListImplement.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractShopListImplement
{
    public class DataListSingleton
    {
        private static DataListSingleton instance;
        public List<Zagotovka> Zagotovkas { get; set; }
        public List<Order> Orders { get; set; }
        public List<Mebel> Mebels { get; set; }
        public List<MebelZagotovka> MebelZagotovkas { get; set; }
        public List<Storage> Storages { get; set; }
        public List<StorageZagotovka> StorageZagotovkas { get; set; }
        private DataListSingleton()
        {
            Zagotovkas = new List<Zagotovka>();
            Orders = new List<Order>();
            Mebels = new List<Mebel>();
            MebelZagotovkas = new List<MebelZagotovka>();
            Storages = new List<Storage>();
            StorageZagotovkas = new List<StorageZagotovka>();
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
