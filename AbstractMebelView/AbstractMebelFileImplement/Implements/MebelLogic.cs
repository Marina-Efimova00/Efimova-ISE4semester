using AbstractMebelBusinessLogic.BindingModels;
using AbstractMebelBusinessLogic.Interfaces;
using AbstractMebelBusinessLogic.ViewModels;
using AbstractMebelListImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AbstractMebelFileImplement.Implements
{
    public class MebelLogic : IMebelLogic
    {
        private readonly FileDataListSingleton source;
        public MebelLogic()
        {
            source = FileDataListSingleton.GetInstance();
        }
        public void CreateOrUpdate(MebelBindingModel model)
        {
            Mebel element = source.Mebels.FirstOrDefault(rec => rec.MebelName ==
           model.MebelName && rec.Id != model.Id);
            if (element != null)
            {
                throw new Exception("Уже есть мебель с таким названием");
            }
            if (model.Id.HasValue)
            {
                element = source.Mebels.FirstOrDefault(rec => rec.Id == model.Id);
                if (element == null)
                {
                    throw new Exception("Элемент не найден");
                }
            }
            else
            {
                int maxId = source.Mebels.Count > 0 ? source.Mebels.Max(rec =>
               rec.Id) : 0;
                element = new Mebel { Id = maxId + 1 };
                source.Mebels.Add(element);
            }
            element.MebelName = model.MebelName;
            element.Price = model.Price;
            source.MebelZagotovkas.RemoveAll(rec => rec.MebelId == model.Id &&
           !model.MebelZagotovkas.ContainsKey(rec.ZagotovkaId));
            var updateZagotovkas = source.MebelZagotovkas.Where(rec => rec.MebelId ==
           model.Id && model.MebelZagotovkas.ContainsKey(rec.ZagotovkaId));
            foreach (var updateZagotovka in updateZagotovkas)
            {
                updateZagotovka.Count =
               model.MebelZagotovkas[updateZagotovka.ZagotovkaId].Item2;
                model.MebelZagotovkas.Remove(updateZagotovka.ZagotovkaId);
            }
            int maxPCId = source.MebelZagotovkas.Count > 0 ?
           source.MebelZagotovkas.Max(rec => rec.Id) : 0;
            foreach (var mz in model.MebelZagotovkas)
            {
                source.MebelZagotovkas.Add(new MebelZagotovka
                {
                    Id = ++maxPCId,
                    MebelId = element.Id,
                    ZagotovkaId = mz.Key,
                    Count = mz.Value.Item2
                });
            }
        }
        public void Delete(MebelBindingModel model)
        {
            source.MebelZagotovkas.RemoveAll(rec => rec.MebelId == model.Id);
            Mebel element = source.Mebels.FirstOrDefault(rec => rec.Id == model.Id);
            if (element != null)
            {
                source.Mebels.Remove(element);
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }
        public List<MebelViewModel> Read(MebelBindingModel model)
        {
            return source.Mebels
            .Where(rec => model == null || rec.Id == model.Id)
            .Select(rec => new MebelViewModel
            {
                Id = rec.Id,
                MebelName = rec.MebelName,
                Price = rec.Price,
                MebelZagotovkas = source.MebelZagotovkas
            .Where(recPC => recPC.MebelId == rec.Id)
           .ToDictionary(recPC => recPC.MebelId, recPC =>
            (source.Zagotovkas.FirstOrDefault(recC => recC.Id ==
           recPC.ZagotovkaId)?.ZagotovkaName, recPC.Count))
            })
            .ToList();
        }
    }
}
