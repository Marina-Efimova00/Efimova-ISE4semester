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
    public class MebelLogic: IMebelLogic
    {
        public void CreateOrUpdate(MebelBindingModel model)
        {
            using (var context = new AbstractMebelDatabase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        Mebel element = context.Mebels.FirstOrDefault(rec =>
                       rec.MebelName == model.MebelName && rec.Id != model.Id);
                        if (element != null)
                        {
                            throw new Exception("Уже есть мебель с таким названием");
                        }
                        if (model.Id.HasValue)
                        {
                            element = context.Mebels.FirstOrDefault(rec => rec.Id == model.Id);
                            if (element == null)
                            {
                                throw new Exception("Элемент не найден");
                            }
                        }
                        else
                        {
                            element = new Mebel();
                            context.Mebels.Add(element);
                        }
                        element.MebelName = model.MebelName;
                        element.Price = model.Price;
                        context.SaveChanges();
                        if (model.Id.HasValue)
                        {
                            var mebelZagotovkas = context.MebelZagotovkas.Where(rec
                           => rec.MebelId == model.Id.Value).ToList();
                            // удалили те, которых нет в модели
                            context.MebelZagotovkas.RemoveRange(mebelZagotovkas.Where(rec =>
                            !model.MebelZagotovkas.ContainsKey(rec.MebelId)).ToList());
                            context.SaveChanges();
                            // обновили количество у существующих записей
                            foreach (var updateZagotovka in mebelZagotovkas)
                            {
                                updateZagotovka.Count =
                               model.MebelZagotovkas[updateZagotovka.ZagotovkaId].Item2;

                                model.MebelZagotovkas.Remove(updateZagotovka.MebelId);
                            }
                            context.SaveChanges();
                        }
                        // добавили новые
                        foreach (var mz in model.MebelZagotovkas)
                        {
                            context.MebelZagotovkas.Add(new MebelZagotovka
                            {
                                MebelId = element.Id,
                                ZagotovkaId = mz.Key,
                                Count = mz.Value.Item2
                            });
                            context.SaveChanges();
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
        public void Delete(MebelBindingModel model)
        {
            using (var context = new AbstractMebelDatabase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        // удаяем записи по заготовкам при удалении изделия
                        context.MebelZagotovkas.RemoveRange(context.MebelZagotovkas.Where(rec =>
                        rec.MebelId == model.Id));
                        Mebel element = context.Mebels.FirstOrDefault(rec => rec.Id == model.Id);
                        if (element != null)
                        {
                            context.Mebels.Remove(element);
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
        public List<MebelViewModel> Read(MebelBindingModel model)
        {
            using (var context = new AbstractMebelDatabase())
            {
                return context.Mebels
                .Where(rec => model == null || rec.Id == model.Id)
                .ToList()
               .Select(rec => new MebelViewModel
               {
                   Id = rec.Id,
                   MebelName = rec.MebelName,
                   Price = rec.Price,
                   MebelZagotovkas = context.MebelZagotovkas
                .Include(recPC => recPC.Zagotovka)
               .Where(recPC => recPC.MebelId == rec.Id)
               .ToDictionary(recPC => recPC.ZagotovkaId, recPC =>
                (recPC.Zagotovka?.ZagotovkaName, recPC.Count))
               })
               .ToList();
            }
        }
    }
}