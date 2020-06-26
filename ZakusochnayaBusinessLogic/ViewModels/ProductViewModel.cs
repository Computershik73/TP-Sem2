using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ZakusochnayaBusinessLogic.ViewModels
{
   public class ProductViewModel
    {
        public int Id { get; set; }
        [DisplayName("Название продукта")]
        public string ProductName { get; set; }
    }
}
