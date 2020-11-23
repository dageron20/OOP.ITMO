using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.Loader;
using System.Text;
using static ShopProject.StoreExeptions;

namespace ShopProject
{
    public class Product
    {
      
        public string Name;
        public int IDProduct;
        public Product(string name, int idProduct)
        {
            Name = name;
            IDProduct = idProduct;
        }
    }

    public class ProductForShop : Product
    {
        public int price { get; set; }
        public int quantity { get; set; }

        public ProductForShop(Product product, int quantity, int price) : base(product.Name, product.IDProduct)
        {
            if (price < 0)
                throw new IncorrectDataValue("Incorrectly set price");
            this.price = price;
            if (quantity < 0)
                throw new IncorrectDataValue("Incorrectly set quantity");
            this.quantity = quantity;
        }
        public ProductForShop(Product product, int quantity) : base(product.Name, product.IDProduct) // перегрузка для метода "дешавая партия"
        {
            if (price < 0)
                throw new IncorrectDataValue("Incorrectly set price");
            this.price = price;
            if (quantity < 0)
                throw new IncorrectDataValue("Incorrectly set quantity");
            this.quantity = quantity;
        }
    }



    public class Store
    {
        static int IDStore_ = 1;
        int IDStore;
        public string Name;
        string Address;
        public List<ProductForShop> products;
        
        public Store(string name, string address)
        {
            this.Name = name;
            this.Address = address;
            this.IDStore = IDStore_;
            IDStore_++;           
            products = new List<ProductForShop>();
            Manager.manag.AddStore(this);
        }       
        public void AddProduct(Product product, int quantity, int price)
        {
            foreach(var item in products)
            {
                if (item.Name == product.Name)
                {
                    item.price += price;
                    item.quantity += quantity;
                    return;
                }
            }           
            ProductForShop newProduct = new ProductForShop(product, quantity, price);
            products.Add(newProduct);
        }
        public List<ProductForShop> Buy(int wallet)
        {
            List<ProductForShop> ListTryBuy = new List<ProductForShop>();
            foreach(var item in products)
            {
                if (item.price <= wallet)
                {
                    ProductForShop ProductNow = new ProductForShop(item, item.quantity, item.price);
                    ListTryBuy.Add(ProductNow);
                    ListTryBuy[ListTryBuy.Count - 1].quantity = wallet / item.price;
                }
            }
            return ListTryBuy;
        }
        public int AllItemsProductPrice(ProductForShop[] ListItems)
        {
            int allPrice = 0;
            foreach(var Iitem in ListItems)
            {
                foreach(var Jitem in products)
                {
                    if (Jitem.Name == Iitem.Name)
                    {
                        if (Jitem.quantity >= Iitem.quantity)
                        {
                            allPrice += Iitem.quantity * Jitem.price;
                        }
                        else
                        {
                            throw new OutOfStock("Product is empty");
                        }
                    }
                }
            }
            return allPrice;
        }
        public ProductForShop DefineProduct(string name)
        {
            foreach(var item in products)
            {
                if(item.Name == name)
                {
                    return item;
                }
            }
            return null;
        }
    }
    public class Manager
    {
        public static Manager manag = new Manager();
        public List<Store> Stores;

        public Manager()
        {
            Stores = new List<Store>();
        }
        public void AddStore(Store store)
        {
            Stores.Add(store);
        }
        public Store LowProduct(Product product)
        {
            int min = int.MaxValue;
            Store answer = null;
            foreach(var item in Stores)
            {
                ProductForShop current = item.DefineProduct(product.Name);
                if ((current != null) && (current.price < min))
                {
                    min = current.price;
                    answer = item;
                }
            }
            return answer;
        }
        public List<ProductForShop> Buy(int summ)
        {
            List<ProductForShop> ItemsList = new List<ProductForShop>();
            foreach(var item in Stores)
            {
                ItemsList.AddRange(item.Buy(summ));
            }
            return ItemsList;
        }
        public Store LowAllProducts(ProductForShop[] purchase)
        {
            Store answer = null;
            int minPrice = int.MaxValue;
            foreach(var item in Stores)
            {
                int purchasePrice = item.AllItemsProductPrice(purchase);
                if (purchasePrice < minPrice)
                {
                    minPrice = purchasePrice;
                    answer = item;
                }
            }
            return answer;
        }
    }
}