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
            List<MebelZagotovkaViewModel> mebelZagotovkas = new
List<MebelZagotovkaViewModel>();
                for (int j = 0; j < source.MebelZagotovkas.Count; ++j)
                {
                    if (source.MebelZagotovkas[j].MebelId == source.Mebels[i].Id)
                    {
                        string zagotovkaName = string.Empty;
                        for (int k = 0; k < source.Zagotovkas.Count; ++k)
                        {
                            if (source.MebelZagotovkas[j].ZagotovkaId ==
                           source.Zagotovkas[k].Id)
                            {
                                zagotovkaName = source.Zagotovkas[k].ZagotovkaName;
                                break;
                            }
                        }
                        mebelZagotovkas.Add(new MebelZagotovkaViewModel
                        {
                            Id = source.MebelZagotovkas[j].Id,
                            MebelId = source.MebelZagotovkas[j].MebelId,
                            ZagotovkaId = source.MebelZagotovkas[j].ZagotovkaId,
                            ZagotovkaName = zagotovkaName,
                            Count = source.MebelZagotovkas[j].Count
                        });
                    }
                }
                result.Add(new MebelViewModel
                {
                    Id = source.Mebels[i].Id,
                    MebelName = source.Mebels[i].MebelName,
                    Price = source.Mebels[i].Price,
                    MebelZagotovkas = mebelZagotovkas
                });
            }
            return result;
        }
        public MebelViewModel GetElement(int id)
        {
            for (int i = 0; i < source.Mebels.Count; ++i)
            {
            List<MebelZagotovkaViewModel> mebelZagotovkas = new
List<MebelZagotovkaViewModel>();
                for (int j = 0; j < source.MebelZagotovkas.Count; ++j)
                {
                    if (source.MebelZagotovkas[j].MebelId == source.Mebels[i].Id)
                    {
                        string zagotovkaName = string.Empty;
                        for (int k = 0; k < source.Zagotovkas.Count; ++k)
                        {
                            if (source.MebelZagotovkas[j].ZagotovkaId ==
                           source.Zagotovkas[k].Id)
                            {
                                zagotovkaName = source.Zagotovkas[k].ZagotovkaName;
                                break;
                            }
                        }
                        mebelZagotovkas.Add(new MebelZagotovkaViewModel
                        {
                            Id = source.MebelZagotovkas[j].Id,
                            MebelId = source.MebelZagotovkas[j].MebelId,
                            ZagotovkaId = source.MebelZagotovkas[j].ZagotovkaId,
                            ZagotovkaName = zagotovkaName,
                            Count = source.MebelZagotovkas[j].Count
                        });
                    }
                }
                if (source.Mebels[i].Id == id)
                {
                    return new MebelViewModel
                    {
                        Id = source.Mebels[i].Id,
                        MebelName = source.Mebels[i].MebelName,
                        Price = source.Mebels[i].Price,
                        MebelZagotovkas = mebelZagotovkas
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
                    throw new Exception("Уже есть мебель с таким названием");
                }
            }
            source.Mebels.Add(new Mebel
            {
                Id = maxId + 1,
                MebelName = model.MebelName,
                Price = model.Price
            });
            int maxPCId = 0;
            for (int i = 0; i < source.MebelZagotovkas.Count; ++i)
            {
                if (source.MebelZagotovkas[i].Id > maxPCId)
                {
                    maxPCId = source.MebelZagotovkas[i].Id;
                }
            }
            for (int i = 0; i < model.MebelZagotovkas.Count; ++i)
            {
                for (int j = 1; j < model.MebelZagotovkas.Count; ++j)
                {
                    if (model.MebelZagotovkas[i].ZagotovkaId ==
                    model.MebelZagotovkas[j].ZagotovkaId)
                    {
                        model.MebelZagotovkas[i].Count +=
                        model.MebelZagotovkas[j].Count;
                        model.MebelZagotovkas.RemoveAt(j--);
                    }
                }
            }
            for (int i = 0; i < model.MebelZagotovkas.Count; ++i)
            {
                source.MebelZagotovkas.Add(new MebelZagotovka
                {
                    Id = ++maxPCId,
                    MebelId = maxId + 1,
                    ZagotovkaId = model.MebelZagotovkas[i].ZagotovkaId,
                    Count = model.MebelZagotovkas[i].Count
                });
            }
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
                    throw new Exception("Уже есть мебель с таким названием");
                }
            }
            if (index == -1)
            {
                throw new Exception("Элемент не найден");
            }
            source.Mebels[index].MebelName = model.MebelName;
            source.Mebels[index].Price = model.Price;
            int maxPCId = 0;
            for (int i = 0; i < source.MebelZagotovkas.Count; ++i)
            {
                if (source.MebelZagotovkas[i].Id > maxPCId)
                {
                    maxPCId = source.MebelZagotovkas[i].Id;
                }
            }
            for (int i = 0; i < source.MebelZagotovkas.Count; ++i)
            {
                if (source.MebelZagotovkas[i].MebelId == model.Id)
                {
                    bool flag = true;
                    for (int j = 0; j < model.MebelZagotovkas.Count; ++j)
                    {
                        if (source.MebelZagotovkas[i].Id ==
                        model.MebelZagotovkas[j].Id)
                        {
                            source.MebelZagotovkas[i].Count =
                           model.MebelZagotovkas[j].Count;
                            flag = false;
                            break;
                        }
                    }
                    if (flag)
                    {
                        source.MebelZagotovkas.RemoveAt(i--);
                    }
                }
            }
            for (int i = 0; i < model.MebelZagotovkas.Count; ++i)
            {
                if (model.MebelZagotovkas[i].Id == 0)
                {
                    for (int j = 0; j < source.MebelZagotovkas.Count; ++j)
                    {
                        if (source.MebelZagotovkas[j].MebelId == model.Id &&
                        source.MebelZagotovkas[j].ZagotovkaId ==
                       model.MebelZagotovkas[i].MebelId)
                        {
                            source.MebelZagotovkas[j].Count +=
                           model.MebelZagotovkas[i].Count;
                            model.MebelZagotovkas[i].Id =
source.MebelZagotovkas[j].Id;
                            break;
                        }
                    }
                    if (model.MebelZagotovkas[i].Id == 0)
                    {
                        source.MebelZagotovkas.Add(new MebelZagotovka
                        {
                            Id = ++maxPCId,
                            MebelId = model.Id,
                            ZagotovkaId = model.MebelZagotovkas[i].ZagotovkaId,
                            Count = model.MebelZagotovkas[i].Count
                        });
                    }
                }
            }
        }
        public void DelElement(int id)
        {
            for (int i = 0; i < source.MebelZagotovkas.Count; ++i)
            {
                if (source.MebelZagotovkas[i].MebelId == id)
                {
                    source.MebelZagotovkas.RemoveAt(i--);
                }
            }
            for (int i = 0; i < source.Mebels.Count; ++i)
            {
                if (source.Mebels[i].Id == id)
                {
                    source.Mebels.RemoveAt(i);
                    return;
                }
            }
            throw new Exception("Элемент не найден");
        }
    }
}
