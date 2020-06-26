using ZakusochnayaBusinessLogic.BindingModels;
using ZakusochnayaBusinessLogic.Interfaces;
using ZakusochnayaBusinessLogic.ViewModels;
using ZakusochnayaListImplement.Models;
using System;
using System.Collections.Generic;

namespace ZakusochnayaListImplement.Implements
{
    public class BludoLogic : IBludoLogic
    {
        private readonly DataListSingleton source;
        public BludoLogic()
        {
            source = DataListSingleton.GetInstance();
        }
        public void CreateOrUpdate(BludoBindingModel model)
        {
            Bludo tempProduct = model.Id.HasValue ? null : new Bludo { Id = 1 };
            foreach (var product in source.Bludos)
            {
                if (product.BludoName == model.BludoName && product.Id != model.Id)
                {
                    throw new Exception("Уже есть блюдо с таким названием");
                }
                if (!model.Id.HasValue && product.Id >= tempProduct.Id)
                {
                    tempProduct.Id = product.Id + 1;
                }
                else if (model.Id.HasValue && product.Id == model.Id)
                {
                    tempProduct = product;
                }
            }
            if (model.Id.HasValue)
            {
            if (tempProduct == null)
                {
                    throw new Exception("Элемент не найден");
                }
                CreateModel(model, tempProduct);
            }
            else
            {
                source.Bludos.Add(CreateModel(model, tempProduct));
            }
        }
        public void Delete(BludoBindingModel model)
        {
            // удаляем записи по компонентам при удалении изделия
            for (int i = 0; i < source.BludoProducts.Count; ++i)
            {
                if (source.BludoProducts[i].BludoId == model.Id)
                {
                    source.BludoProducts.RemoveAt(i--);
                }
            }
            for (int i = 0; i < source.Bludos.Count; ++i)
            {
                if (source.Bludos[i].Id == model.Id)
                {
                    source.Bludos.RemoveAt(i);
                    return;
                }
            }
            throw new Exception("Элемент не найден");
        }
        private Bludo CreateModel(BludoBindingModel model, Bludo bludo)
        {
            bludo.BludoName = model.BludoName;
            bludo.Price = model.Price;
            int maxPCId = 0;
            for (int i = 0; i < source.BludoProducts.Count; ++i)
            {
                if (source.BludoProducts[i].Id > maxPCId)
                {
                    maxPCId = source.BludoProducts[i].Id;
                }
                if (source.BludoProducts[i].BludoId == bludo.Id)
                {
                    if
                    (model.BludoProducts.ContainsKey(source.BludoProducts[i].ProductId))
                    {
                        source.BludoProducts[i].Count =
                        model.BludoProducts[source.BludoProducts[i].ProductId].Item2;
                    
model.BludoProducts.Remove(source.BludoProducts[i].ProductId);
                    }
                    else
                    {
                        source.BludoProducts.RemoveAt(i--);
                     }
                }
            }
            foreach (var pc in model.BludoProducts)
            {
                source.BludoProducts.Add(new BludoProduct
                {
                    Id = ++maxPCId,
                    BludoId = bludo.Id,
                    ProductId = pc.Key,
                    Count = pc.Value.Item2
                });
            }
            return bludo;
        }
        public List<BludoViewModel> Read(BludoBindingModel model)
        {
            List<BludoViewModel> result = new List<BludoViewModel>();
            foreach (var bludo in source.Bludos)
            {
                if (model != null)
                {
                    if (bludo.Id == model.Id)
                    {
                        result.Add(CreateViewModel(bludo));
                        break;
                    }
                    continue;
                }
                result.Add(CreateViewModel(bludo));
            }
            return result;
        }
        private BludoViewModel CreateViewModel(Bludo bludo)
        {
        Dictionary<int, (string, int)> bludoProducts = new Dictionary<int,
(string, int)>();
            foreach (var bp in source.BludoProducts)
            {
                if (bp.BludoId == bludo.Id)
                {
                    string productName = string.Empty;
                    foreach (var product in source.Products)
                    {
                        if (bp.ProductId == product.Id)
                        {
                            productName = product.ProductName;
                            break;
                        }
                    }
                    bludoProducts.Add(bp.ProductId, (productName, bp.Count));
                }
            }
            return new BludoViewModel
            {
                Id = bludo.Id,
                BludoName = bludo.BludoName,
                Price = bludo.Price,
                BludoProducts = bludoProducts
            };
        }
    }
}
