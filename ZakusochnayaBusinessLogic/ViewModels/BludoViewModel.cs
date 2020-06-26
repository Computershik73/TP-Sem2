using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ZakusochnayaBusinessLogic.ViewModels
{
    public class BludoViewModel
    {
        public int Id { get; set; }
        [DisplayName("Название блюда")]
        public string BludoName { get; set; }
        [DisplayName("Цена")]
        public decimal Price { get; set; }
        public Dictionary<int, (string, int)> BludoProducts { get; set; }
    }
}
