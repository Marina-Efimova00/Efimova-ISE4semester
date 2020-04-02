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
    public class StorageLogic : IStorageLogic
    {
        private readonly FileDataListSingleton source;
        public StorageLogic()
        {
            source = FileDataListSingleton.GetInstance();
        }
        public List<StorageViewModel> GetList()
        {
            return source.Storages.Select(rec => new StorageViewModel
            {
                Id = rec.Id,
                StorageName = rec.StorageName,
                StorageZagotovkas = source.StorageZagotovkas.Where(z => z.StorageId == rec.Id).Select(x => new StorageZagotovkaViewModel
                {
                    Id = x.Id,
                    StorageId = x.StorageId,
                    ZagotovkaId = x.ZagotovkaId,
                    ZagotovkaName = source.Zagotovkas.FirstOrDefault(y => y.Id == x.ZagotovkaId)?.ZagotovkaName,
                    Count = x.Count
                }).ToList()
            })
                .ToList();
        }
        public StorageViewModel GetElement(int id)
        {
            var elem = source.Storages.FirstOrDefault(x => x.Id == id);
            if (elem == null)
            {
                throw new Exception("Элемент не найден");
            }
            else
            {
                return new StorageViewModel
                {
                    Id = id,
                    StorageName = elem.StorageName,
                    StorageZagotovkas = source.StorageZagotovkas.Where(z => z.StorageId == elem.Id).Select(x => new StorageZagotovkaViewModel
                    {
                        Id = x.Id,
                        StorageId = x.StorageId,
                        ZagotovkaId = x.ZagotovkaId,
                        ZagotovkaName = source.Zagotovkas.FirstOrDefault(y => y.Id == x.ZagotovkaId)?.ZagotovkaName,
                        Count = x.Count
                    }).ToList()
                };
            }
        }

        public void AddElement(StorageBindingModel model)
        {

            var elem = source.Storages.FirstOrDefault(x => x.StorageName == model.StorageName);
            if (elem != null)
            {
                throw new Exception("Уже есть склад с таким названием");
            }
            int maxId = source.Storages.Count > 0 ? source.Storages.Max(rec => rec.Id) : 0;
            source.Storages.Add(new Storage
            {
                Id = maxId + 1,
                StorageName = model.StorageName
            });
        }
        public void UpdElement(StorageBindingModel model)
        {
            var elem = source.Storages.FirstOrDefault(x => x.StorageName == model.StorageName && x.Id != model.Id);
            if (elem != null)
            {
                throw new Exception("Уже есть склад с таким названием");
            }
            var elemToUpdate = source.Storages.FirstOrDefault(x => x.Id == model.Id);
            if (elemToUpdate != null)
            {
                elemToUpdate.StorageName = model.StorageName;
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }
        public void DelElement(int id)
        {
            var elem = source.Storages.FirstOrDefault(x => x.Id == id);
            if (elem != null)
            {
                source.Storages.Remove(elem);
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }

        public void FillStorage(StorageZagotovkaBindingModel model)
        {
            var item = source.StorageZagotovkas.FirstOrDefault(x => x.ZagotovkaId == model.ZagotovkaId
                    && x.StorageId == model.StorageId);

            if (item != null)
            {
                item.Count += model.Count;
            }
            else
            {
                int maxId = source.StorageZagotovkas.Count > 0 ? source.StorageZagotovkas.Max(rec => rec.Id) : 0;
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
            var mebelZagotovkas = source.MebelZagotovkas.Where(x => x.MebelId == mebelId);
            if (mebelZagotovkas.Count() == 0)
                return false;
            foreach (var elem in mebelZagotovkas)
            {
                int count = source.StorageZagotovkas.FindAll(x => x.ZagotovkaId == elem.ZagotovkaId).Sum(rec => rec.Count);
                if (count < elem.Count * mebelsCount)
                    return false;
            }
            return true;
        }

        public void RemoveFromStorage(int mebelId, int mebelsCount)
        {
            var mebelZagotovkas = source.MebelZagotovkas.Where(x => x.MebelId == mebelId);
            if (mebelZagotovkas.Count() == 0) return;
            foreach (var elem in mebelZagotovkas)
            {
                int left = elem.Count * mebelsCount;
                var storageZagotovkas = source.StorageZagotovkas.FindAll(x => x.ZagotovkaId == elem.ZagotovkaId);
                foreach (var rec in storageZagotovkas)
                {
                    int toRemove = left > rec.Count ? rec.Count : left;
                    rec.Count -= toRemove;
                    left -= toRemove;
                    if (left == 0) break;
                }
            }
            return;
        }
    }
}
