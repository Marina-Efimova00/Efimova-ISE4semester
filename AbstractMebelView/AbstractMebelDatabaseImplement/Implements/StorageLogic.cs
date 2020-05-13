using AbstractMebelBusinessLogic.BindingModels;
using AbstractMebelBusinessLogic.Interfaces;
using AbstractMebelBusinessLogic.ViewModels;
using AbstractMebelDatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AbstractMebelDatabaseImplement.Implements
{
    public class StorageLogic : IStorageLogic 
    {
        public List<StorageViewModel> GetList()
        {
            using (var context = new AbstractMebelDatabase())
            {
                return context.Storages
                .ToList()
               .Select(rec => new StorageViewModel
               {
                   Id = rec.Id,
                   StorageName = rec.StorageName,
                   StorageZagotovkas = context.StorageZagotovkas
                .Include(recSF => recSF.Zagotovka)
               .Where(recSF => recSF.StorageId == rec.Id).
               Select(x => new StorageZagotovkaViewModel
               {
                   Id = x.Id,
                   StorageId = x.StorageId,
                   ZagotovkaId = x.ZagotovkaId,
                   ZagotovkaName = context.Zagotovkas.FirstOrDefault(y => y.Id == x.ZagotovkaId).ZagotovkaName,
                   Count = x.Count
               })
               .ToList()
               })
            .ToList();
            }
        }

        public StorageViewModel GetElement(int id)
        {
            using (var context = new AbstractMebelDatabase())
            {
                var elem = context.Storages.FirstOrDefault(x => x.Id == id);
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
                        StorageZagotovkas = context.StorageZagotovkas
                .Include(recSF => recSF.Zagotovka)
               .Where(recSF => recSF.StorageId == elem.Id)
                        .Select(x => new StorageZagotovkaViewModel
                        {
                            Id = x.Id,
                            StorageId = x.StorageId,
                            ZagotovkaId = x.ZagotovkaId,
                            ZagotovkaName = context.Zagotovkas.FirstOrDefault(y => y.Id == x.ZagotovkaId).ZagotovkaName,
                            Count = x.Count
                        }).ToList()
                    };
                }
            }
        }

        public void AddElement(StorageBindingModel model)
        {
            using (var context = new AbstractMebelDatabase())
            {
                var elem = context.Storages.FirstOrDefault(x => x.StorageName == model.StorageName);
                if (elem != null)
                {
                    throw new Exception("Уже есть склад с таким названием");
                }
                var storage = new Storage();
                context.Storages.Add(storage);
                storage.StorageName = model.StorageName;
                context.SaveChanges();
            }
        }

        public void UpdElement(StorageBindingModel model)
        {
            using (var context = new AbstractMebelDatabase())
            {
                var elem = context.Storages.FirstOrDefault(x => x.StorageName == model.StorageName && x.Id != model.Id);
                if (elem != null)
                {
                    throw new Exception("Уже есть склад с таким названием");
                }
                var elemToUpdate = context.Storages.FirstOrDefault(x => x.Id == model.Id);
                if (elemToUpdate != null)
                {
                    elemToUpdate.StorageName = model.StorageName;
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            }
        }

        public void DelElement(StorageBindingModel model)
        {
            using (var context = new AbstractMebelDatabase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        context.StorageZagotovkas.RemoveRange(context.StorageZagotovkas.Where(rec => rec.StorageId == model.Id));
                        Storage element = context.Storages.FirstOrDefault(rec => rec.Id == model.Id);

                        if (element != null)
                        {
                            context.Storages.Remove(element);
                            context.SaveChanges();
                        }
                        else
                        {
                            throw new Exception("Элемент не найден");
                        }

                        transaction.Commit();
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        public void FillStorage(StorageZagotovkaBindingModel model)
        {
            using (var context = new AbstractMebelDatabase())
            {
                var item = context.StorageZagotovkas.FirstOrDefault(x => x.ZagotovkaId == model.ZagotovkaId
    && x.StorageId == model.StorageId);

                if (item != null)
                {
                    item.Count += model.Count;
                }
                else
                {
                    var elem = new StorageZagotovka();
                    context.StorageZagotovkas.Add(elem);
                    elem.StorageId = model.StorageId;
                    elem.ZagotovkaId = model.ZagotovkaId;
                    elem.Count = model.Count;
                }
                context.SaveChanges();
            }
        }

        public void RemoveFromStorage(int mebelId, int mebelsCount)
        {
            using (var context = new AbstractMebelDatabase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        var mebelZagotovkas = context.MebelZagotovkas.Where(x => x.MebelId == mebelId);
                        if (mebelZagotovkas.Count() == 0) return;
                        foreach (var elem in mebelZagotovkas)
                        {
                            int left = elem.Count * mebelsCount;
                            var storageZagotovkas = context.StorageZagotovkas.Where(x => x.ZagotovkaId == elem.ZagotovkaId);
                            int available = storageZagotovkas.Sum(x => x.Count);
                            if (available < left) throw new Exception("Недостаточно заготовок на складе");
                            foreach (var rec in storageZagotovkas)
                            {
                                int toRemove = left > rec.Count ? rec.Count : left;
                                rec.Count -= toRemove;
                                left -= toRemove;
                                if (left == 0) break;
                            }
                        }
                        context.SaveChanges();
                        transaction.Commit();
                        return;
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }
    }
}
