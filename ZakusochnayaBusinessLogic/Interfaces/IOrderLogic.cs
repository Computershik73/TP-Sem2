using ZakusochnayaBusinessLogic.BindingModels;
using ZakusochnayaBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace ZakusochnayaBusinessLogic.Interfaces
{
    public interface IOrderLogic
    {
        List<OrderViewModel> Read(OrderBindingModel model);
        void CreateOrUpdate(OrderBindingModel model);
        void Delete(OrderBindingModel model);
    }
}
