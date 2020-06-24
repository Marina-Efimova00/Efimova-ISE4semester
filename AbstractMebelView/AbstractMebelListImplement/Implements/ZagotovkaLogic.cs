using AbstractMebelBusinessLogic.BindingModels;
using AbstractMebelBusinessLogic.Interfaces;
using AbstractMebelBusinessLogic.ViewModels;
using AbstractMebelListImplement.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractMebelListImplement.Implements
{
    public class ZagotovkaLogic : IZagotovkaLogic
    {
        private readonly DataListSingleton source;
        public ZagotovkaLogic()
        {
            source = DataListSingleton.GetInstance();
        }
        public void CreateOrUpdate(ZagotovkaBindingModel model)
        {
            Zagotovka tempZagotovka = model.Id.HasValue ? null : new Zagotovka
            {
                Id = 1
            };
            foreach (var zagotovka in source.Zagotovkas)
            {
                if (zagotovka.ZagotovkaName == model.ZagotovkaName && zagotovka.Id !=
               model.Id)
                {
                    throw new Exception("Уже есть заготовка с таким названием");
                }
                if (!model.Id.HasValue && zagotovka.Id >= tempZagotovka.Id)
                {
                    tempZagotovka.Id = zagotovka.Id + 1;
                }
                else if (model.Id.HasValue && zagotovka.Id == model.Id)
                {
                    tempZagotovka = zagotovka;
                }
            }
            if (model.Id.HasValue)
            {
                if (tempZagotovka == null)
                {
                    throw new Exception("Элемент не найден");
                }
                CreateModel(model, tempZagotovka);
            }
            else
            {
                source.Zagotovkas.Add(CreateModel(model, tempZagotovka));
            }
        }
        public void Delete(ZagotovkaBindingModel model)
        {
            for (int i = 0; i < source.Zagotovkas.Count; ++i)
            {
                if (source.Zagotovkas[i].Id == model.Id.Value)
                {
                    source.Zagotovkas.RemoveAt(i);
                    return;
                }
            }
            throw new Exception("Элемент не найден");
        }
        public List<ZagotovkaViewModel> Read(ZagotovkaBindingModel model)
        {
            List<ZagotovkaViewModel> result = new List<ZagotovkaViewModel>();
            foreach (var zagotovka in source.Zagotovkas)
            {
                if (model != null)
                {
                    if (zagotovka.Id == model.Id)
                    {
                        result.Add(CreateViewModel(zagotovka));
                        break;
                    }
                    continue;
                }
                result.Add(CreateViewModel(zagotovka));
            }
            return result;
        }
        private Zagotovka CreateModel(ZagotovkaBindingModel model, Zagotovka zagotovka)
        {
            zagotovka.ZagotovkaName = model.ZagotovkaName;
            return zagotovka;
        }
        private ZagotovkaViewModel CreateViewModel(Zagotovka zagotovka)
        {
            return new ZagotovkaViewModel
            {
                Id = zagotovka.Id,
                ZagotovkaName = zagotovka.ZagotovkaName
            };
        }
    }
}
