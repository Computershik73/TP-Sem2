using ZakusochnayaBusinessLogic.BindingModels;
using ZakusochnayaBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace ZakusochnayaBusinessLogic.Interfaces
{
    public interface IProductLogic
    {
        List<ProductViewModel> Read(ProductBindingModel model);
        void CreateOrUpdate(ProductBindingModel model);
        void Delete(ProductBindingModel model);
    }
}
