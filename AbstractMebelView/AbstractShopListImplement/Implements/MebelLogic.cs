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
        public List<MebelViewModel> GetList()
        {
            List<MebelViewModel> result = new List<MebelViewModel>();
            for (int i = 0; i < source.Mebels.Count; ++i)
            {
                result.Add(new MebelViewModel
                {
                    Id = source.Mebels[i].Id,
                    MebelName = source.Mebels[i].MebelName
                });
            }
            return result;
        }
        public MebelViewModel GetElement(int id)
        {
            for (int i = 0; i < source.Mebels.Count; ++i)
            {
                if (source.Mebels[i].Id == id)
                {
                    return new MebelViewModel
                    {
                        Id = source.Mebels[i].Id,
                        MebelName = source.Mebels[i].MebelName
                    };
                }
            }
            throw new Exception("Элемент не найден");
        }
        public void AddElement(MebelBindingModel model)
        {
            int maxId = 0;
            for (int i = 0; i < source.Mebels.Count; ++i)
            {
                if (source.Mebels[i].Id > maxId)
                {
                    maxId = source.Mebels[i].Id;
                }
                if (source.Mebels[i].MebelName == model.MebelName)
                {
                    throw new Exception("Уже есть компонент с таким названием");
                }
            }
            source.Mebels.Add(new Mebel
            {
                Id = maxId + 1,
                MebelName = model.MebelName
            });
        }
        public void UpdElement(MebelBindingModel model)
        {
            int index = -1;
            for (int i = 0; i < source.Mebels.Count; ++i)
            {
                if (source.Mebels[i].Id == model.Id)
                {
                    index = i;
                }
                if (source.Mebels[i].MebelName == model.MebelName &&
               source.Mebels[i].Id != model.Id)
                {
                    throw new Exception("Уже есть компонент с таким названием");
                }
            }
            if (index == -1)
            {
                throw new Exception("Элемент не найден");
            }
            source.Mebels[index].MebelName = model.MebelName;
        }
        public void DelElement(int id)
        {
            for (int i = 0; i < source.Mebels.Count; ++i)
            {
                if (source.Mebels[i].Id == id)
                {
                    source.Mebels.RemoveAt(i);
                }
            }
            throw new Exception("Элемент не найден");
        }
    }
}
