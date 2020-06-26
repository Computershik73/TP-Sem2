using System;
using System.Collections.Generic;
using System.Text;

namespace ZakusochnayaBusinessLogic.BindingModels
{
    public class CreateOrderBindingModel
    {
        public int BludoId { get; set; }
        public int Count { get; set; }
        public decimal Sum { get; set; }
    }
}
