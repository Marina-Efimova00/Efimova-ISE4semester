﻿using AbstractMebelBusinessLogic.BindingModels;
using AbstractMebelBusinessLogic.Interfaces;
using AbstractMebelBusinessLogic.ViewModels;
using AbstractMebelListImplement.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractMebelListImplement.Implements
{
    public class StorageLogic : IStorageLogic
    {
        private readonly DataListSingleton source;
        public StorageLogic()
        {
            source = DataListSingleton.GetInstance();
        }
        public List<StorageViewModel> GetList()
        {
            List<StorageViewModel> result = new List<StorageViewModel>();
            for (int i = 0; i < source.Storages.Count; ++i)
            {
                List<StorageZagotovkaViewModel> StorageZagotovkas = new
    List<StorageZagotovkaViewModel>();
                for (int j = 0; j < source.StorageZagotovkas.Count; ++j)
                {
                    if (source.StorageZagotovkas[j].StorageId == source.Storages[i].Id)
                    {
                        string ZagotovkaName = string.Empty;
                        for (int k = 0; k < source.Zagotovkas.Count; ++k)
                        {
                            if (source.StorageZagotovkas[j].ZagotovkaId ==
                           source.Zagotovkas[k].Id)
                            {
                                ZagotovkaName = source.Zagotovkas[k].ZagotovkaName;
                                break;
                            }
                        }
                        StorageZagotovkas.Add(new StorageZagotovkaViewModel
                        {
                            Id = source.StorageZagotovkas[j].Id,
                            StorageId = source.StorageZagotovkas[j].StorageId,
                            ZagotovkaId = source.StorageZagotovkas[j].ZagotovkaId,
                            ZagotovkaName = ZagotovkaName,
                            Count = source.StorageZagotovkas[j].Count
                        });
                    }
                }
                result.Add(new StorageViewModel
                {
                    Id = source.Storages[i].Id,
                    StorageName = source.Storages[i].StorageName,
                    StorageZagotovkas = StorageZagotovkas
                });
            }
            return result;
        }
        public StorageViewModel GetElement(int id)
        {
            for (int i = 0; i < source.Storages.Count; ++i)
            {
                List<StorageZagotovkaViewModel> StorageZagotovkas = new
    List<StorageZagotovkaViewModel>();
                for (int j = 0; j < source.StorageZagotovkas.Count; ++j)
                {
                    if (source.StorageZagotovkas[j].StorageId == source.Storages[i].Id)
                    {
                        string ZagotovkaName = string.Empty;
                        for (int k = 0; k < source.Zagotovkas.Count; ++k)
                        {
                            if (source.StorageZagotovkas[j].ZagotovkaId ==
                           source.Zagotovkas[k].Id)
                            {
                                ZagotovkaName = source.Zagotovkas[k].ZagotovkaName;
                                break;
                            }
                        }
                        StorageZagotovkas.Add(new StorageZagotovkaViewModel
                        {
                            Id = source.StorageZagotovkas[j].Id,
                            StorageId = source.StorageZagotovkas[j].StorageId,
                            ZagotovkaId = source.StorageZagotovkas[j].ZagotovkaId,
                            ZagotovkaName = ZagotovkaName,
                            Count = source.StorageZagotovkas[j].Count
                        });
                    }
                }
                if (source.Storages[i].Id == id)
                {
                    return new StorageViewModel
                    {
                        Id = source.Storages[i].Id,
                        StorageName = source.Storages[i].StorageName,
                        StorageZagotovkas = StorageZagotovkas
                    };
                }
            }
            throw new Exception("Элемент не найден");
        }
        public void AddElement(StorageBindingModel model)
        {
            int maxId = 0;
            for (int i = 0; i < source.Storages.Count; ++i)
            {
                if (source.Storages[i].Id > maxId)
                {
                    maxId = source.Storages[i].Id;
                }
                if (source.Storages[i].StorageName == model.StorageName)
                {
                    throw new Exception("Уже есть склад с таким названием");
                }
            }
            source.Storages.Add(new Storage
            {
                Id = maxId + 1,
                StorageName = model.StorageName
            });
        }
        public void UpdElement(StorageBindingModel model)
        {
            int index = -1;
            for (int i = 0; i < source.Storages.Count; ++i)
            {
                if (source.Storages[i].Id == model.Id)
                {
                    index = i;
                }
                if (source.Storages[i].StorageName == model.StorageName &&
                source.Storages[i].Id != model.Id)
                {
                    throw new Exception("Уже есть склад с таким названием");
                }
            }
            if (index == -1)
            {
                throw new Exception("Элемент не найден");
            }
            source.Storages[index].StorageName = model.StorageName;

        }
        public void DelElement(StorageBindingModel model)
        {
            for (int i = 0; i < source.StorageZagotovkas.Count; ++i)
            {
                if (source.StorageZagotovkas[i].StorageId == model.Id)
                {
                    source.StorageZagotovkas.RemoveAt(i--);
                }
            }
            for (int i = 0; i < source.Storages.Count; ++i)
            {
                if (source.Storages[i].Id == model.Id)
                {
                    source.Storages.RemoveAt(i);
                    return;
                }
            }
            throw new Exception("Элемент не найден");
        }

        public void FillStorage(StorageZagotovkaBindingModel model)
        {
            int foundItemIndex = -1;
            for (int i = 0; i < source.StorageZagotovkas.Count; ++i)
            {
                if (source.StorageZagotovkas[i].ZagotovkaId == model.ZagotovkaId
                    && source.StorageZagotovkas[i].StorageId == model.StorageId)
                {
                    foundItemIndex = i;
                    break;
                }
            }
            if (foundItemIndex != -1)
            {
                source.StorageZagotovkas[foundItemIndex].Count =
                    source.StorageZagotovkas[foundItemIndex].Count + model.Count;
            }
            else
            {
                int maxId = 0;
                for (int i = 0; i < source.StorageZagotovkas.Count; ++i)
                {
                    if (source.StorageZagotovkas[i].Id > maxId)
                    {
                        maxId = source.StorageZagotovkas[i].Id;
                    }
                }
                source.StorageZagotovkas.Add(new StorageZagotovka
                {
                    Id = maxId + 1,
                    StorageId = model.StorageId,
                    ZagotovkaId = model.ZagotovkaId,
                    Count = model.Count
                });
            }
        }

        public bool CheckZagotovkasAvailability(int mebelId, int mebelsCount)
        {
            throw new NotImplementedException();
        }

        public void RemoveFromStorage(int mebelId, int mebelsCount)
        {
            throw new NotImplementedException();
        }
    }
}
