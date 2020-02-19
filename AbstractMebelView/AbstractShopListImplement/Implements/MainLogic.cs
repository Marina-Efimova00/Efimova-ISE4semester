using AbstractMebelBusinessLogic.BindingModels;
using AbstractMebelBusinessLogic.Enums;
using AbstractMebelBusinessLogic.Interfaces;
using AbstractMebelBusinessLogic.ViewModels;
using AbstractShopListImplement.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractShopListImplement.Implements
{
    public class MainLogic : IMainLogic
    {
        private readonly DataListSingleton source;
        public MainLogic()
        {
            source = DataListSingleton.GetInstance();
        }
        public List<OrderViewModel> GetOrders()
        {
            List<OrderViewModel> result = new List<OrderViewModel>();
            for (int i = 0; i < source.Orders.Count; ++i)
            {
                string mebelName = string.Empty;
                for (int j = 0; j < source.Mebels.Count; ++j)
                {
                    if (source.Mebels[j].Id == source.Orders[i].MebelId)
                    {
                        mebelName = source.Mebels[j].MebelName;
                        break;
                    }
                }
                result.Add(new OrderViewModel
                {
                    Id = source.Orders[i].Id,
                    MebelId = source.Orders[i].MebelId,
                    MebelName = mebelName,
                    Count = source.Orders[i].Count,
                    Sum = source.Orders[i].Sum,
                    DateCreate = source.Orders[i].DateCreate,
                    DateImplement = source.Orders[i].DateImplement,
                    Status = source.Orders[i].Status
                });
            }
            return result;
        }
        public void CreateOrder(OrderBindingModel model)
        {
            int maxId = 0;
            for (int i = 0; i < source.Orders.Count; ++i)
            {
                if (source.Orders[i].Id > maxId)
                {
                    maxId = source.Orders[i].Id;
                }
            }
            source.Orders.Add(new Order
            {
                Id = maxId + 1,
                MebelId = model.MebelId,
                DateCreate = DateTime.Now,
                Count = model.Count,
                Sum = model.Sum,
                Status = OrderStatus.Принят
            });
        }
        public void TakeOrderInWork(OrderBindingModel model)
        {
            int index = -1;
            for (int i = 0; i < source.Orders.Count; ++i)
            {
                if (source.Orders[i].Id == model.Id)
                {
                    index = i;
                    break;
                }
            }
            if (index == -1)
            {
                throw new Exception("Элемент не найден");
            }
            if (source.Orders[index].Status != OrderStatus.Принят)
            {
                throw new Exception("Заказ не в статусе \"Принят\"");
            }
            source.Orders[index].DateImplement = DateTime.Now;
            source.Orders[index].Status = OrderStatus.Выполняется;
        }
        public void FinishOrder(OrderBindingModel model)
        {
            int index = -1;
            for (int i = 0; i < source.Orders.Count; ++i)
            {
                if (source.Orders[i].Id == model.Id)
                {
                    index = i;
                    break;
                }
            }
            if (index == -1)
            {
                throw new Exception("Элемент не найден");
            }
            if (source.Orders[index].Status != OrderStatus.Выполняется)
            {
                throw new Exception("Заказ не в статусе \"Выполняется\"");
            }
            source.Orders[index].Status = OrderStatus.Готов;
        }
        public void PayOrder(OrderBindingModel model)
        {
            int index = -1;
            for (int i = 0; i < source.Orders.Count; ++i)
            {
                if (source.Orders[i].Id == model.Id)
                {
                    index = i;
                    break;
                }
            }
            if (index == -1)
            {
                throw new Exception("Элемент не найден");
            }
            if (source.Orders[index].Status != OrderStatus.Готов)
            {
                throw new Exception("Заказ не в статусе \"Готов\"");
            }
            source.Orders[index].Status = OrderStatus.Оплачен;
        }
        public void FillStorage(StorageZagotovkaBindingModel model)
        {
            int index = -1;
            for (int i = 0; i < source.Storages.Count; ++i)
            {
                if (source.Storages[i].Id == model.StorageId)
                {
                    index = i;
                    break;
                }
            }
            if (index == -1)
            {
                throw new Exception("Склад не найден");
            }

            index = -1;
            for (int i = 0; i < source.Zagotovkas.Count; ++i)
            {
                if (source.Zagotovkas[i].Id == model.ZagotovkaId)
                {
                    index = i;
                    break;
                }
            }
            if (index == -1)
            {
                throw new Exception("Заготовка не найден");
            }

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
    }
}
