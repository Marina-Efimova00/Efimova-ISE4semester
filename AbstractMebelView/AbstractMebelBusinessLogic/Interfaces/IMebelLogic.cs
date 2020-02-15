using System;
using System.Collections.Generic;
using System.Text;
using AbstractMebelBusinessLogic.BindingModels;
using AbstractMebelBusinessLogic.ViewModels;

namespace AbstractMebelBusinessLogic.Interfaces
{
    public interface IMebelLogic
    {
        List<MebelViewModel> GetList();
        MebelViewModel GetElement(int id);
        void AddElement(MebelBindingModel model);
        void UpdElement(MebelBindingModel model);
        void DelElement(int id);
    }
}
