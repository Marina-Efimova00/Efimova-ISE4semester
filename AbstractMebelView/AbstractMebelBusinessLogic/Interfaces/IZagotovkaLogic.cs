using System;
using System.Collections.Generic;
using System.Text;
using AbstractMebelBusinessLogic.ViewModels;
using AbstractMebelBusinessLogic.BindingModels;

namespace AbstractMebelBusinessLogic.Interfaces
{
    public interface IZagotovkaLogic
    {
        List<ZagotovkaViewModel> GetList();
        ZagotovkaViewModel GetElement(int id);
        void AddElement(ZagotovkaBindingModel model);
        void UpdElement(ZagotovkaBindingModel model);
        void DelElement(int id);
    }
}
