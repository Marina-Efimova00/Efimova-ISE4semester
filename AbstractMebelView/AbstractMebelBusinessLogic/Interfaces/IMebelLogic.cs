using System;
using System.Collections.Generic;
using System.Text;
using AbstractMebelBusinessLogic.ViewModels;
using AbstractMebelBusinessLogic.BindingModels;

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
