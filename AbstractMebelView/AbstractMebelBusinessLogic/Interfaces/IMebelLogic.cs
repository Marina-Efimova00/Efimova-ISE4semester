using System;
using System.Collections.Generic;
using System.Text;
using AbstractMebelBusinessLogic.BindingModels;
using AbstractMebelBusinessLogic.ViewModels;

namespace AbstractMebelBusinessLogic.Interfaces
{
    public interface IMebelLogic
    {
        List<MebelViewModel> Read(MebelBindingModel model);
        void CreateOrUpdate(MebelBindingModel model);
        void Delete(MebelBindingModel model);
    }
}
