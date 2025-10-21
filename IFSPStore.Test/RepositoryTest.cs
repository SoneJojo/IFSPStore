using IFSPStore.Domain.Entities;
using IFSPStore.Repository.Context;
using System.Text.Json;

namespace IFSPStore.Test
{
    [TestClass]
    public sealed class RepositoryTest
    {
        [TestMethod]
        public void TestCategory()
        {
            using (var context = new IFSPStoreContext())
            {
                Console.WriteLine("Connected!");

                var category1 = new Category(1, "Carnes", "");
                var category2 = new Category(2, "Bebidas", "");
                var category3 = new Category(3, "Doces", "");

                context.Categories.Add(category1);
                context.Categories.Add(category2);
                context.Categories.Add(category3);
                context.SaveChanges();
                Console.WriteLine("Insert Done!");
            }
            using (var context = new IFSPStoreContext())
            {
                foreach (var cat in context.Categories)
                {
                    Console.WriteLine(JsonSerializer.Serialize(cat));
                }
                Console.WriteLine("List Done!");
            }
        }

        [TestMethod]
        public void TestProduct()
        {
            var context = new IFSPStoreContext();
            var _categoryRepository = new Repository.Repository.BaseRepository<Category>(context);
            var _productRepository = new Repository.Repository.BaseRepository<Product>(context);

            var category1 = new Category();
            category1.Name = "Enlatados";
            category1.Description = "Produtos enlatados em geral";
            _categoryRepository.Insert(category1);
            var category2 = new Category();
            category2.Name = "Saudaveis";
            category2.Description = "Produtos para quem se preocupa com a saude";
            _categoryRepository.Insert(category2);

            var prod1 = new Product();
            prod1.Name = "Sardinha";
            prod1.Price = 10.55M;
            prod1.Quantity = 50;
            prod1.SalesUnit = "Lata";
            prod1.PurchaseDate = DateTime.Now;
            prod1.Category = category1;
            _productRepository.Insert(prod1);
            var prod2 = new Product();
            prod2.Name = "Whey";
            prod2.Price = 155.55M;
            prod2.Quantity = 60;
            prod2.SalesUnit = "Pote";
            prod2.PurchaseDate = DateTime.Now;
            prod2.Category = category2;
            _productRepository.Insert(prod2);
        }
    }
}
