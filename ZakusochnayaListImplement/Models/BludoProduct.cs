using System;
using System.Collections.Generic;
using System.Text;

namespace ZakusochnayaListImplement.Models
{
    public class BludoProduct
    {
        public int Id { get; set; }
        public int BludoId { get; set; }
        public int ProductId { get; set; }
        public int Count { get; set; }
    }
}
