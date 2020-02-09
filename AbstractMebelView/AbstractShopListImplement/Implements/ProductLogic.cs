using AbstractMebelBusinessLogic.BindingModels;
using AbstractMebelBusinessLogic.Interfaces;
using AbstractMebelBusinessLogic.ViewModels;
using AbstractShopListImplement.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractShopListImplement.Implements
{
    public class ProductLogic : IProductLogic
    {
        private readonly DataListSingleton source;
        public ProductLogic()
        {
            source = DataListSingleton.GetInstance();
        }
        public List<ProductViewModel> GetList()
        {
            List<ProductViewModel> result = new List<ProductViewModel>();
            for (int i = 0; i < source.Products.Count; ++i)
            {
                // требуется дополнительно получить список компонентов для изделия и их количество
            List<ProductMebelViewModel> productMebels = new
List<ProductMebelViewModel>();
                for (int j = 0; j < source.ProductMebels.Count; ++j)
                {
                    if (source.ProductMebels[j].ProductId == source.Products[i].Id)
                    {
                        string mebelName = string.Empty;
                        for (int k = 0; k < source.Mebels.Count; ++k)
                        {
                            if (source.ProductMebels[j].MebelId ==
                           source.Mebels[k].Id)
                            {
                                mebelName = source.Mebels[k].MebelName;
                                break;
                            }
                        }
                        productMebels.Add(new ProductMebelViewModel
                        {
                            Id = source.ProductMebels[j].Id,
                            ProductId = source.ProductMebels[j].ProductId,
                            MebelId = source.ProductMebels[j].MebelId,
                            MebelName = mebelName,
                            Count = source.ProductMebels[j].Count
                        });
                    }
                }
                result.Add(new ProductViewModel
                {
                    Id = source.Products[i].Id,
                    ProductName = source.Products[i].ProductName,
                    Price = source.Products[i].Price,
                    ProductMebels = productMebels
                });
            }
            return result;
        }
        public ProductViewModel GetElement(int id)
        {
            for (int i = 0; i < source.Products.Count; ++i)
            {
                // требуется дополнительно получить список компонентов для изделия и их количество
            List<ProductMebelViewModel> productMebels = new
List<ProductMebelViewModel>();
                for (int j = 0; j < source.ProductMebels.Count; ++j)
                {
                    if (source.ProductMebels[j].ProductId == source.Products[i].Id)
                    {
                        string mebelName = string.Empty;
                        for (int k = 0; k < source.Mebels.Count; ++k)
                        {
                            if (source.ProductMebels[j].MebelId ==
                           source.Mebels[k].Id)
                            {
                                mebelName = source.Mebels[k].MebelName;
                                break;
                            }
                        }
                        productMebels.Add(new ProductMebelViewModel
                        {
                            Id = source.ProductMebels[j].Id,
                            ProductId = source.ProductMebels[j].ProductId,
                            MebelId = source.ProductMebels[j].MebelId,
                            MebelName = mebelName,
                            Count = source.ProductMebels[j].Count
                        });
                    }
                }
                if (source.Products[i].Id == id)
                {
                    return new ProductViewModel
                    {
                        Id = source.Products[i].Id,
                        ProductName = source.Products[i].ProductName,
                        Price = source.Products[i].Price,
                        ProductMebels = productMebels
                    };
                }
            }
            throw new Exception("Элемент не найден");
        }
        public void AddElement(ProductBindingModel model)
        {
            int maxId = 0;
            for (int i = 0; i < source.Products.Count; ++i)
            {
                if (source.Products[i].Id > maxId)
                {
                    maxId = source.Products[i].Id;
                }
                if (source.Products[i].ProductName == model.ProductName)
                {
                    throw new Exception("Уже есть изделие с таким названием");
                }
            }
            source.Products.Add(new Product
            {
                Id = maxId + 1,
                ProductName = model.ProductName,
                Price = model.Price
            });
            // компоненты для изделия
            int maxPCId = 0;
            for (int i = 0; i < source.ProductMebels.Count; ++i)
            {
                if (source.ProductMebels[i].Id > maxPCId)
                {
                    maxPCId = source.ProductMebels[i].Id;
                }
            }
            // убираем дубли по компонентам
            for (int i = 0; i < model.ProductMebels.Count; ++i)
            {
                for (int j = 1; j < model.ProductMebels.Count; ++j)
                {
                    if (model.ProductMebels[i].MebelId ==
                    model.ProductMebels[j].MebelId)
                    {
                        model.ProductMebels[i].Count +=
                        model.ProductMebels[j].Count;
                        model.ProductMebels.RemoveAt(j--);
                    }
                }
            }
            // добавляем компоненты
            for (int i = 0; i < model.ProductMebels.Count; ++i)
            {
                source.ProductMebels.Add(new ProductMebel
                {
                    Id = ++maxPCId,
                    ProductId = maxId + 1,
                    MebelId = model.ProductMebels[i].MebelId,
                    Count = model.ProductMebels[i].Count
                });
            }
        }
        public void UpdElement(ProductBindingModel model)
        {
            int index = -1;
            for (int i = 0; i < source.Products.Count; ++i)
            {
                if (source.Products[i].Id == model.Id)
                {
                    index = i;
                }
                if (source.Products[i].ProductName == model.ProductName &&
                source.Products[i].Id != model.Id)
                {
                    throw new Exception("Уже есть изделие с таким названием");
                }
            }
            if (index == -1)
            {
                throw new Exception("Элемент не найден");
            }
            source.Products[index].ProductName = model.ProductName;
            source.Products[index].Price = model.Price;
            int maxPCId = 0;
            for (int i = 0; i < source.ProductMebels.Count; ++i)
            {
                if (source.ProductMebels[i].Id > maxPCId)
                {
                    maxPCId = source.ProductMebels[i].Id;
                }
            }
            // обновляем существуюущие компоненты
            for (int i = 0; i < source.ProductMebels.Count; ++i)
            {
                if (source.ProductMebels[i].ProductId == model.Id)
                {
                    bool flag = true;
                    for (int j = 0; j < model.ProductMebels.Count; ++j)
                    {
                        // если встретили, то изменяем количество
                        if (source.ProductMebels[i].Id ==
                        model.ProductMebels[j].Id)
                        {
                            source.ProductMebels[i].Count =
                           model.ProductMebels[j].Count;
                            flag = false;
                            break;
                        }
                    }
                    // если не встретили, то удаляем
                    if (flag)
                    {
                        source.ProductMebels.RemoveAt(i--);
                    }
                }
            }
            // новые записи
            for (int i = 0; i < model.ProductMebels.Count; ++i)
            {
                if (model.ProductMebels[i].Id == 0)
                {
                    // ищем дубли
                    for (int j = 0; j < source.ProductMebels.Count; ++j)
                    {
                        if (source.ProductMebels[j].ProductId == model.Id &&
                        source.ProductMebels[j].MebelId ==
                       model.ProductMebels[i].MebelId)
                        {
                            source.ProductMebels[j].Count +=
                           model.ProductMebels[i].Count;
                            model.ProductMebels[i].Id =
source.ProductMebels[j].Id;
                            break;
                        }
                    }
                    // если не нашли дубли, то новая запись
                    if (model.ProductMebels[i].Id == 0)
                    {
                        source.ProductMebels.Add(new ProductMebel
                        {
                            Id = ++maxPCId,
                            ProductId = model.Id,
                            MebelId = model.ProductMebels[i].MebelId,
                            Count = model.ProductMebels[i].Count
                        });
                    }
                }
            }
        }
        public void DelElement(int id)
        {
            // удаляем записи по компонентам при удалении изделия
            for (int i = 0; i < source.ProductMebels.Count; ++i)
            {
                if (source.ProductMebels[i].ProductId == id)
                {
                    source.ProductMebels.RemoveAt(i--);
                }
            }
            for (int i = 0; i < source.Products.Count; ++i)
            {
                if (source.Products[i].Id == id)
                {
                    source.Products.RemoveAt(i);
                    return;
                }
            }
            throw new Exception("Элемент не найден");
        }
    }
}
