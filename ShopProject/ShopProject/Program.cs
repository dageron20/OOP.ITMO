using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace ShopProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Product bread = new Product("bread");
            Product milk = new Product("milk");
            Product sugar = new Product("sugar");
            Product salt = new Product("salt");
            Product porridge = new Product("porridge");
            Product package = new Product("package");
            Product nails = new Product("nails");
            Product soap = new Product("soap");
            Product knife = new Product("knife");
            Product sausage = new Product("sausage");
            Store okey = new Store("O'key", "Pushkina 24");
            Store lenta = new Store("LENTA", "Nevskiy 1");
            Store metro = new Store("METRO", "Lenina 12");
            okey.AddProduct(bread, 50, 25);
            okey.AddProduct(milk, 20, 85);
            okey.AddProduct(sugar, 100, 15);
            okey.AddProduct(salt, 100, 20);
            okey.AddProduct(porridge, 100, 50);
            okey.AddProduct(package, 1000, 5);
            lenta.AddProduct(bread, 50, 40);
            lenta.AddProduct(milk, 20, 185);
            lenta.AddProduct(sugar, 10, 115);
            lenta.AddProduct(salt, 10, 120);
            lenta.AddProduct(porridge, 10, 150);
            lenta.AddProduct(package, 20, 15);
            lenta.AddProduct(soap, 10, 1000);
            metro.AddProduct(nails, 5, 110);
            metro.AddProduct(milk, 20, 1185);
            metro.AddProduct(sugar, 10, 1115);
            metro.AddProduct(salt, 10, 1120);
            metro.AddProduct(porridge, 10, 1150);
            metro.AddProduct(package, 20, 115);
            metro.AddProduct(knife, 10, 100);
            metro.AddProduct(bread, 100, 5);

            Console.WriteLine(Manager.manag.LowProduct(bread).Name);
            List<Product.ProductShop> ItemList = Manager.manag.Buy(100);
            foreach(var item in ItemList)
                Console.WriteLine(item.IDProduct + ":" + item.Name + " " + item.quantity);

            Product.ProductShop[] purchase = new Product.ProductShop[2];          
            purchase[0] = new Product.ProductShop(bread, 1);
            purchase[1] = new Product.ProductShop(milk, 1);
            Console.WriteLine("Выводит 6 задание");
            Console.WriteLine(metro.AllItemsProduct(purchase));

            Console.WriteLine("Выводит 7 задание");
            Console.WriteLine(Manager.manag.LowAllProducts(purchase).Name);
        }
    }
}
