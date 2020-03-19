using AbstractMebelBusinessLogic.BindingModels;
using AbstractMebelBusinessLogic.Interfaces;
using AbstractMebelBusinessLogic.ViewModels;
using AbstractShopListImplement.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractShopListImplement.Implements
{
    public class MebelLogic : IMebelLogic
    {
        private readonly DataListSingleton source;
        public MebelLogic()
        {
            source = DataListSingleton.GetInstance();
        }
        public void CreateOrUpdate(MebelBindingModel model)
        {
            Mebel tempMebel = model.Id.HasValue ? null : new Mebel { Id = 1 };
            foreach (var mebel in source.Mebels)
            {
                if (mebel.MebelName == model.MebelName && mebel.Id != model.Id)
                {
                    throw new Exception("Уже есть мебель с таким названием");
                }
                if (!model.Id.HasValue && mebel.Id >= tempMebel.Id)
                {
                    tempMebel.Id = mebel.Id + 1;
                }
                else if (model.Id.HasValue && mebel.Id == model.Id)
                {
                    tempMebel = mebel;
                }
            }
            if (model.Id.HasValue)
            {
                if (tempMebel == null)
                {
                    throw new Exception("Элемент не найден");
                }
                CreateModel(model, tempMebel);
            }
            else
            {
                source.Mebels.Add(CreateModel(model, tempMebel));
            }
        }
        public void Delete(MebelBindingModel model)
        {
            for (int i = 0; i < source.MebelZagotovkas.Count; ++i)
            {
                if (source.MebelZagotovkas[i].MebelId == model.Id)
                {
                    source.MebelZagotovkas.RemoveAt(i--);
                }
            }
            for (int i = 0; i < source.Mebels.Count; ++i)
            {
                if (source.Mebels[i].Id == model.Id)
                {
                    source.Mebels.RemoveAt(i);
                    return;
                }
            }
            throw new Exception("Элемент не найден");
        }
        private Mebel CreateModel(MebelBindingModel model, Mebel mebel)
        {
            mebel.MebelName = model.MebelName;
            mebel.Price = model.Price;
            int maxPCId = 0;
            for (int i = 0; i < source.MebelZagotovkas.Count; ++i)
            {
                if (source.MebelZagotovkas[i].Id > maxPCId)
                {
                    maxPCId = source.MebelZagotovkas[i].Id;
                }
                if (source.MebelZagotovkas[i].MebelId == mebel.Id)
                {
                    if
                    (model.MebelZagotovkas.ContainsKey(source.MebelZagotovkas[i].ZagotovkaId))
                    {
                        source.MebelZagotovkas[i].Count =
                        model.MebelZagotovkas[source.MebelZagotovkas[i].ZagotovkaId].Item2;
                        model.MebelZagotovkas.Remove(source.MebelZagotovkas[i].ZagotovkaId);
                    }
                    else
                    {
                        source.MebelZagotovkas.RemoveAt(i--);
                    }
                }
            }
            foreach (var pc in model.MebelZagotovkas)
            {
                source.MebelZagotovkas.Add(new MebelZagotovka
                {
                    Id = ++maxPCId,
                    MebelId = mebel.Id,
                    ZagotovkaId = pc.Key,
                    Count = pc.Value.Item2
                });
            }
            return mebel;
        }
        public List<MebelViewModel> Read(MebelBindingModel model)
        {
            List<MebelViewModel> result = new List<MebelViewModel>();
            foreach (var zagotovka in source.Mebels)
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
        private MebelViewModel CreateViewModel(Mebel mebel)
        {
            Dictionary<int, (string, int)> mebelZagotovkas = new Dictionary<int,
   (string, int)>();
            foreach (var pc in source.MebelZagotovkas)
            {
                if (pc.MebelId == mebel.Id)
                {
                    string zagotovkaName = string.Empty;
                    foreach (var zagotovka in source.Zagotovkas)
                    {
                        if (pc.ZagotovkaId == zagotovka.Id)
                        {
                            zagotovkaName = zagotovka.ZagotovkaName;
                            break;
                        }
                    }
                    mebelZagotovkas.Add(pc.ZagotovkaId, (zagotovkaName, pc.Count));
                }
            }
            return new MebelViewModel
            {
                Id = mebel.Id,
                MebelName = mebel.MebelName,
                Price = mebel.Price,
                MebelZagotovkas = mebelZagotovkas
            };
        }
    }
}


