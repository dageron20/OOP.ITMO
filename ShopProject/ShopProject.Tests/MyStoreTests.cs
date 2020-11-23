using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
namespace ShopProject.Tests
{
    [TestClass]
    public class MyStoreTests
    {
        [TestMethod]
        public void TestAddStore()
        {
            Store okey = new Store("O'key", "Nevskiy 1");
            Store expected = Manager.manag.Stores[0];
            Store actual = okey;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        /*public void TestTryBuy()
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
            List<Product.ProductShop> expected = Manager.manag.Buy(100);
            List<Product.ProductShop> actual = new List<Product.ProductShop>();
            actual.Add(new Product.ProductShop(bread, 4 , 25));
            actual.Add(new Product.ProductShop(milk, 1, 85));
            actual.Add(new Product.ProductShop(sugar, 6, 15));
            actual.Add(new Product.ProductShop(salt, 5, 20));
            actual.Add(new Product.ProductShop(porridge, 2, 50));
            actual.Add(new Product.ProductShop(package, 20, 5));
            actual.Add(new Product.ProductShop(bread, 2, 50));
            actual.Add(new Product.ProductShop(package, 6, 15));
            actual.Add(new Product.ProductShop(knife, 1, 100));
            actual.Add(new Product.ProductShop(bread, 20, 5));
            Assert.AreEqual(expected, actual);
        }*/


    }
}
