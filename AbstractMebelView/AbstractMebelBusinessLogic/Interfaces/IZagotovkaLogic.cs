using System;
using System.Collections.Generic;
using System.Text;
using AbstractMebelBusinessLogic.ViewModels;
using AbstractMebelBusinessLogic.BindingModels;

namespace AbstractMebelBusinessLogic.Interfaces
{
    public interface IZagotovkaLogic
    {
        List<ZagotovkaViewModel> Read(ZagotovkaBindingModel model);
        void CreateOrUpdate(ZagotovkaBindingModel model);
        void Delete(ZagotovkaBindingModel model);
    }
}
