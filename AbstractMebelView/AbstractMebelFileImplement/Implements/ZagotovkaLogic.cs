using AbstractMebelBusinessLogic.BindingModels;
using AbstractMebelBusinessLogic.Interfaces;
using AbstractMebelBusinessLogic.ViewModels;
using AbstractShopListImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AbstractShopFileImplement.Implements
{
    public class ZagotovkaLogic : IZagotovkaLogic
    {
        private readonly FileDataListSingleton source;
        public ZagotovkaLogic()
        {
            source = FileDataListSingleton.GetInstance();
        }
        public void CreateOrUpdate(ZagotovkaBindingModel model)
        {
            Zagotovka element = source.Zagotovkas.FirstOrDefault(rec => rec.ZagotovkaName
           == model.ZagotovkaName && rec.Id != model.Id);
            if (element != null)
            {
                throw new Exception("Уже есть заготовка с таким названием");
            }
            if (model.Id.HasValue)
            {
                element = source.Zagotovkas.FirstOrDefault(rec => rec.Id == model.Id);
                if (element == null)
                {
                    throw new Exception("Элемент не найден");
                }
            }
            else
            {
                int maxId = source.Zagotovkas.Count > 0 ? source.Zagotovkas.Max(rec =>
               rec.Id) : 0;
                element = new Zagotovka { Id = maxId + 1 };
                source.Zagotovkas.Add(element);
            }
            element.ZagotovkaName = model.ZagotovkaName;
        }
        public void Delete(ZagotovkaBindingModel model)
        {
            Zagotovka element = source.Zagotovkas.FirstOrDefault(rec => rec.Id ==
           model.Id);
            if (element != null)
            {
                source.Zagotovkas.Remove(element);
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }
        public List<ZagotovkaViewModel> Read(ZagotovkaBindingModel model)
        {
            return source.Zagotovkas
            .Where(rec => model == null || rec.Id == model.Id)
            .Select(rec => new ZagotovkaViewModel
            {
                Id = rec.Id,
                ZagotovkaName = rec.ZagotovkaName
            })
            .ToList();
        }
    }
}
