﻿using AbstractMebelBusinessLogic.BindingModels;
using AbstractMebelBusinessLogic.Interfaces;
using AbstractMebelBusinessLogic.ViewModels;
using AbstractMebelListImplement.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractMebelListImplement.Implements
{
    public class OrderLogic : IOrderLogic
    {
        private readonly DataListSingleton source;
        public OrderLogic()
        {
            source = DataListSingleton.GetInstance();
        }
        public void CreateOrUpdate(OrderBindingModel model)
        {
            Order tempOrder = model.Id.HasValue ? null : new Order
            {
                Id = 1
            };
            foreach (var Order in source.Orders)
            {
                if (!model.Id.HasValue && Order.Id >= tempOrder.Id)
                {
                    tempOrder.Id = Order.Id + 1;
                }
                else if (model.Id.HasValue && Order.Id == model.Id)
                {
                    tempOrder = Order;
                }
            }
            if (model.Id.HasValue)
            {
                if (tempOrder == null)
                {
                    throw new Exception("Элемент не найден");
                }
                CreateModel(model, tempOrder);
            }
            else
            {
                source.Orders.Add(CreateModel(model, tempOrder));
            }
        }
        public void Delete(OrderBindingModel model)
        {
            for (int i = 0; i < source.Orders.Count; ++i)
            {
                if (source.Orders[i].Id == model.Id.Value)
                {
                    source.Orders.RemoveAt(i);
                    return;
                }
            }
            throw new Exception("Элемент не найден");
        }
        public List<OrderViewModel> Read(OrderBindingModel model)
        {
            List<OrderViewModel> result = new List<OrderViewModel>();
            foreach (var Order in source.Orders)
            {
                if (model != null)
                {
                    if (Order.Id == model.Id)
                    {
                        result.Add(CreateViewModel(Order));
                        break;
                    }
                    continue;
                }
                result.Add(CreateViewModel(Order));
            }
            return result;
        }
        private Order CreateModel(OrderBindingModel model, Order Order)
        {
            Order.MebelId = model.MebelId == 0 ? Order.MebelId : model.MebelId;
            Order.Count = model.Count;
            Order.Sum = model.Sum;
            Order.Status = model.Status;
            Order.DateCreate = model.DateCreate;
            Order.DateImplement = model.DateImplement;
            return Order;
        }
        private OrderViewModel CreateViewModel(Order Order)
        {
            string MebelName = "";
            for (int j = 0; j < source.Mebels.Count; ++j)
            {
                if (source.Mebels[j].Id == Order.MebelId)
                {
                    MebelName = source.Mebels[j].MebelName;
                    break;
                }
            }
            return new OrderViewModel
            {
                Id = Order.Id,
                MebelName = MebelName,
                Count = Order.Count,
                Sum = Order.Sum,
                Status = Order.Status,
                DateCreate = Order.DateCreate,
                DateImplement = Order.DateImplement
            };
        }
    }
}
