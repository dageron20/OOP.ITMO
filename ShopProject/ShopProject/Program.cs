using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace ShopProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Product bread = new Product("bread", 1);
            Product milk = new Product("milk", 2);
            Product sugar = new Product("sugar", 3);
            Product salt = new Product("salt", 4);
            Product porridge = new Product("porridge", 5);
            Product package = new Product("package", 6);
            Product nails = new Product("nails", 7);
            Product soap = new Product("soap", 8);
            Product knife = new Product("knife", 9);
            Product sausage = new Product("sausage", 10);
            Store okey = new Store("O'key", "Pushkina 24");
            Store lenta = new Store("LENTA", "Nevskiy 1");
            Store metro = new Store("METRO", "Lenina 12");
            okey.AddProduct(bread, 50, 25);
            okey.AddProduct(bread, 21, 25);
            okey.AddProduct(milk, 120, 85);
            okey.AddProduct(sugar, 100, 15);
            okey.AddProduct(salt, 100, 20);
            okey.AddProduct(porridge, 100, 50);
            okey.AddProduct(package, 1000, 5);
            lenta.AddProduct(bread, 50, 40);
            lenta.AddProduct(milk, 120, 185);
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
            metro.AddProduct(milk, 90, 0);

            Console.WriteLine(Manager.manag.LowProduct(bread).Name);
            List<ProductForShop> ItemList = Manager.manag.Buy(100);
            foreach(var item in ItemList)
                Console.WriteLine(item.IDProduct + ":" + item.Name + " " + item.quantity);

            ProductForShop[] purchase = new ProductForShop[2];          
            purchase[0] = new ProductForShop(bread, 1);
            purchase[1] = new ProductForShop(milk, 100);
            Console.WriteLine("Выводит 6 задание");
            Console.WriteLine(metro.AllItemsProductPrice(purchase));

            Console.WriteLine("Выводит 7 задание");
            Console.WriteLine(Manager.manag.LowAllProducts(purchase).Name);
        }
    }
}
