using AbstractMebelBusinessLogic.BindingModels;
using AbstractMebelBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractMebelBusinessLogic.Interfaces
{
    public interface IClientLogic
    {
        List<ClientViewModel> Read(ClientBindingModel model);
        void CreateOrUpdate(ClientBindingModel model);
        void Delete(ClientBindingModel model);
    }
}
