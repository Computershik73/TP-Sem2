using ZakusochnayaBusinessLogic.BindingModels;
using ZakusochnayaBusinessLogic.ViewModels;
using System.Collections.Generic;


namespace ZakusochnayaBusinessLogic.Interfaces
{
    public interface IBludoLogic
    {
        List<BludoViewModel> Read(BludoBindingModel model);
        void CreateOrUpdate(BludoBindingModel model);
        void Delete(BludoBindingModel model);
    }
}
