using AbstractMebelListImplement.Models;
using System;
using System.Collections.Generic;
using System.Text;



namespace AbstractMebelListImplement
{
    public class DataListSingleton
    {
        private static DataListSingleton instance;
        public List<Zagotovka> Zagotovkas { get; set; }
        public List<Order> Orders { get; set; }
        public List<Mebel> Mebels { get; set; }
        public List<MebelZagotovka> MebelZagotovkas { get; set; }
        public List<Client> Clients { get; set; }
        public List<Implementer> Implementers { get; set; }
        private DataListSingleton()
        {
            Zagotovkas = new List<Zagotovka>();
            Orders = new List<Order>();
            Mebels = new List<Mebel>();
            MebelZagotovkas = new List<MebelZagotovka>();
            Clients = new List<Client>();
            Implementers = new List<Implementer>();
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
