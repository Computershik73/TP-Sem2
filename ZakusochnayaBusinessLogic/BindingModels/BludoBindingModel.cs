using ZakusochnayaBusinessLogic.BindingModels;
using System.Collections.Generic;

namespace ZakusochnayaBusinessLogic.Interfaces
{
    public class BludoBindingModel
    {
        public int? Id { get; set; }
        public string BludoName { get; set; }
        public decimal Price { get; set; }
        public Dictionary<int, (string, int)> BludoProducts { get; set; }
    }
}