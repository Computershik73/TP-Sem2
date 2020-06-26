using System;
using System.Collections.Generic;
using System.Text;

namespace ZakusochnayaListImplement.Models
{
    public class DataListSingleton
    {
        private static DataListSingleton instance;
        public List<Product> Products { get; set; }
        public List<Order> Orders { get; set; }
        public List<Bludo> Bludos { get; set; }
        public List<BludoProduct> BludoProducts { get; set; }
        private DataListSingleton()
        {
            Products = new List<Product>();
            Orders = new List<Order>();
            Bludos = new List<Bludo>();
            BludoProducts = new List<BludoProduct>();
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
