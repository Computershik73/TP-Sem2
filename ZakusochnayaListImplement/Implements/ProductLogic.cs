using ZakusochnayaBusinessLogic.BindingModels;
using ZakusochnayaBusinessLogic.Interfaces;
using ZakusochnayaBusinessLogic.ViewModels;
using ZakusochnayaListImplement.Models;
using System;
using System.Collections.Generic;


namespace ZakusochnayaListImplement.Implements
{
    public class ProductLogic : IProductLogic
    {
        private readonly DataListSingleton source;
        public ProductLogic()
        {
            source = DataListSingleton.GetInstance();
        }
        public void CreateOrUpdate(ProductBindingModel model)
        {
            Product tempProduct = model.Id.HasValue ? null : new Product
            {
                Id = 1
            };
            foreach (var product in source.Products)
            {
                if (product.ProductName == model.ProductName && product.Id !=
               model.Id)
                {
                    throw new Exception("Уже есть продукт с таким названием");
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
                source.Products.Add(CreateModel(model, tempProduct));
            }
        }
        public void Delete(ProductBindingModel model)
        {
            for (int i = 0; i < source.Products.Count; ++i)
            {
                if (source.Products[i].Id == model.Id.Value)
                {
                    source.Products.RemoveAt(i);
                    return;
                }
            }
            throw new Exception("Элемент не найден");
        }
        public List<ProductViewModel> Read(ProductBindingModel model)
        {
            List<ProductViewModel> result = new List<ProductViewModel>();
            foreach (var product in source.Products)
            {
                if (model != null)
                {
                    if (product.Id == model.Id)
                    {
                        result.Add(CreateViewModel(product));
                        break;
                    }
                    continue;
                }
                result.Add(CreateViewModel(product));
            }
            return result;
        }
        private Product CreateModel(ProductBindingModel model, Product product)
        {
            product.ProductName = model.ProductName;
            return product;
        }
        private ProductViewModel CreateViewModel(Product product)
        {
            return new ProductViewModel
            {
             Id = product.Id,
             ProductName = product.ProductName
            };
        }
    }
}
