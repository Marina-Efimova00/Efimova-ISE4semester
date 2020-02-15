using AbstractMebelBusinessLogic.BindingModels;
using AbstractMebelBusinessLogic.Interfaces;
using AbstractMebelBusinessLogic.ViewModels;
using AbstractShopListImplement.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractShopListImplement.Implements
{
    public class ZagotovkaLogic : IZagotovkaLogic
    {
        private readonly DataListSingleton source;
        public ZagotovkaLogic()
        {
            source = DataListSingleton.GetInstance();
        }
        public List<ZagotovkaViewModel> GetList()
        {
            List<ZagotovkaViewModel> result = new List<ZagotovkaViewModel>();
            for (int i = 0; i < source.Zagotovkas.Count; ++i)
            {
                result.Add(new ZagotovkaViewModel
                {
                    Id = source.Zagotovkas[i].Id,
                    ZagotovkaName = source.Zagotovkas[i].ZagotovkaName
                });
            }
            return result;
        }
        public ZagotovkaViewModel GetElement(int id)
        {
            for (int i = 0; i < source.Zagotovkas.Count; ++i)
            {
                if (source.Zagotovkas[i].Id == id)
                {
                    return new ZagotovkaViewModel
                    {
                        Id = source.Zagotovkas[i].Id,
                        ZagotovkaName = source.Zagotovkas[i].ZagotovkaName
                    };
                }
            }
            throw new Exception("Элемент не найден");
        }
        public void AddElement(ZagotovkaBindingModel model)
        {
            int maxId = 0;
            for (int i = 0; i < source.Zagotovkas.Count; ++i)
            {
                if (source.Zagotovkas[i].Id > maxId)
                {
                    maxId = source.Zagotovkas[i].Id;
                }
                if (source.Zagotovkas[i].ZagotovkaName == model.ZagotovkaName)
                {
                    throw new Exception("Уже есть заготовка с таким названием");
                }
            }
            source.Zagotovkas.Add(new Zagotovka
            {
                Id = maxId + 1,
                ZagotovkaName = model.ZagotovkaName
            });
        }
        public void UpdElement(ZagotovkaBindingModel model)
        {
            int index = -1;
            for (int i = 0; i < source.Zagotovkas.Count; ++i)
            {
                if (source.Zagotovkas[i].Id == model.Id)
                {
                    index = i;
                }
                if (source.Zagotovkas[i].ZagotovkaName == model.ZagotovkaName &&
               source.Zagotovkas[i].Id != model.Id)
                {
                    throw new Exception("Уже есть заготовка с таким названием");
                }
            }
            if (index == -1)
            {
                throw new Exception("Элемент не найден");
            }
            source.Zagotovkas[index].ZagotovkaName = model.ZagotovkaName;
        }
        public void DelElement(int id)
        {
            for (int i = 0; i < source.Zagotovkas.Count; ++i)
            {
                if (source.Zagotovkas[i].Id == id)
                {
                    source.Zagotovkas.RemoveAt(i);
                }
            }
            throw new Exception("Элемент не найден");
        }
    }
}
