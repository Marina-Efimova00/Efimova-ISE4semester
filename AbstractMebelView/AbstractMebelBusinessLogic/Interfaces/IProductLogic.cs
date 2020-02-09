using System;
using System.Collections.Generic;
using System.Text;
using AbstractMebelBusinessLogic.BindingModels;
using AbstractMebelBusinessLogic.ViewModels;

namespace AbstractMebelBusinessLogic.Interfaces
{
    public interface IProductLogic
    {
        List<ProductViewModel> GetList();
        ProductViewModel GetElement(int id);
        void AddElement(ProductBindingModel model);
        void UpdElement(ProductBindingModel model);
        void DelElement(int id);
    }
}
