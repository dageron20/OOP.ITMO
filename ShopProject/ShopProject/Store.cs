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
        public Product(string name)
        {
            Name = name;
        }
        public class ProductShop : Product
        {           
            public int price { get; set; }
            public int quantity { get; set; }
            static int IDProduct_ = 1;
            public int IDProduct;
            public ProductShop(Product product, int quantity, int price) : base(product.Name)
            {
                if (price < 0)
                    throw new IncorrectDataValue("Incorrectly set price");
                this.price = price;
                if (quantity < 0)
                    throw new IncorrectDataValue("Incorrectly set quantity");
                this.quantity = quantity;
                IDProduct = IDProduct_;
                IDProduct_++;
            }
            public ProductShop(Product product, int quantity) : base(product.Name) // перегрузка для метода "дешавая партия"
            {
                if (price < 0)
                    throw new IncorrectDataValue("Incorrectly set price");
                this.price = price;
                if (quantity < 0)
                    throw new IncorrectDataValue("Incorrectly set quantity");
                this.quantity = quantity;               
            }
        }
    }
    public class Store
    {
        static int IDStore_ = 1;
        int IDStore;
        public string Name;
        string Address;
        public List<Product.ProductShop> products;
        
        public Store(string name, string address)
        {
            this.Name = name;
            this.Address = address;
            this.IDStore = IDStore_;
            IDStore_++;           
            products = new List<Product.ProductShop>();
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
                }
            }
            Product.ProductShop newProduct = new Product.ProductShop(product, quantity, price);
            products.Add(newProduct);
        }
        public List<Product.ProductShop> Buy(int wallet)
        {
            List<Product.ProductShop> ListTryBuy = new List<Product.ProductShop>();
            foreach(var item in products)
            {
                if (item.price <= wallet)
                {
                    Product.ProductShop ProductNow = new Product.ProductShop(item, item.quantity, item.price);
                    ListTryBuy.Add(ProductNow);
                    ListTryBuy[ListTryBuy.Count - 1].quantity = wallet / item.price;
                }
            }
            return ListTryBuy;
        }
        public int itemProduct(Product product, int quantity)
        {
            int allPrice = 0;
            foreach(var item in products)
            {
                if (item.quantity >= quantity)
                {
                    int price = item.price;
                    allPrice = quantity * price;
                    return allPrice;
                }
            }
            return 0;
        }
        public int AllItemsProduct(Product.ProductShop[] ListItems)
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
        public Product.ProductShop DefineProduct(string name)
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
                Product.ProductShop current = item.DefineProduct(product.Name);
                if ((current != null) && (current.price < min))
                {
                    min = current.price;
                    answer = item;
                }
            }
            return answer;
        }
        public List<Product.ProductShop> Buy(int summ)
        {
            List<Product.ProductShop> ItemsList = new List<Product.ProductShop>();
            foreach(var item in Stores)
            {
                ItemsList.AddRange(item.Buy(summ));
            }
            return ItemsList;
        }
        public Store LowAllProducts(Product.ProductShop[] purchase)
        {
            Store answer = null;
            int minPrice = int.MaxValue;
            foreach(var item in Stores)
            {
                int purchasePrice = item.AllItemsProduct(purchase);
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