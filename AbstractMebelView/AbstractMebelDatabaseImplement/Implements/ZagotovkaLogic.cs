using AbstractMebelBusinessLogic.BindingModels;
using AbstractMebelBusinessLogic.Interfaces;
using AbstractMebelBusinessLogic.ViewModels;
using AbstractMebelDatabaseImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AbstractMebelDatabaseImplement.Implements
{
    public class ZagotovkaLogic : IZagotovkaLogic
    {
        public void CreateOrUpdate(ZagotovkaBindingModel model)
        {
            using (var context = new AbstractMebelDatabase())
            {
                Zagotovka element = context.Zagotovkas.FirstOrDefault(rec =>
 rec.ZagotovkaName == model.ZagotovkaName && rec.Id != model.Id);
                if (element != null)
                {
                    throw new Exception("Уже есть заготовка с таким названием");
                }
                if (model.Id.HasValue)
                {
                    element = context.Zagotovkas.FirstOrDefault(rec => rec.Id ==
                   model.Id);
                    if (element == null)
                    {
                        throw new Exception("Элемент не найден");
                    }
                }
                else
                {
                    element = new Zagotovka();
                    context.Zagotovkas.Add(element);
                }
                element.ZagotovkaName = model.ZagotovkaName;
                context.SaveChanges();
            }
        }
        public void Delete(ZagotovkaBindingModel model)
        {
            using (var context = new AbstractMebelDatabase())
            {
                Zagotovka element = context.Zagotovkas.FirstOrDefault(rec => rec.Id ==
               model.Id);
                if (element != null)
                {
                    context.Zagotovkas.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            }
        }
        public List<ZagotovkaViewModel> Read(ZagotovkaBindingModel model)
        {
            using (var context = new AbstractMebelDatabase())
            {
                return context.Zagotovkas
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
}
