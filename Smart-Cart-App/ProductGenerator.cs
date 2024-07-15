using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart_Cart_App
{
    public class ProductGenerator
    {
        private List<Product> allProducts;

        public ProductGenerator()
        {
            allProducts = new List<Product>
        {
            
                                         // Clothing Products
            new Product { Name = "T-Shirt", Price = 15.0m, Category = ProductCategory.Clothing },
            new Product { Name = "Jeans", Price = 35.0m, Category = ProductCategory.Clothing },
            new Product { Name = "Skirt", Price = 45.0m, Category = ProductCategory.Clothing },
            new Product { Name = "Sneakers", Price = 50.0m, Category = ProductCategory.Clothing },
            new Product { Name = "Cap", Price = 12.0m, Category = ProductCategory.Clothing },
            new Product { Name = "Tights", Price = 8.0m, Category = ProductCategory.Clothing },
            new Product { Name = "Coat", Price = 70.0m, Category = ProductCategory.Clothing },
            new Product { Name = "Mittens", Price = 7.0m, Category = ProductCategory.Clothing },
            new Product { Name = "Beanie", Price = 10.0m, Category = ProductCategory.Clothing },    
            new Product { Name = "Tie", Price = 25.0m, Category = ProductCategory.Clothing },

                                            // Food Products
            new Product { Name = "Orange", Price = 0.6m, Category = ProductCategory.Food },
            new Product { Name = "Grapes", Price = 2.0m, Category = ProductCategory.Food },
            new Product { Name = "Rice", Price = 1.5m, Category = ProductCategory.Food },
            new Product { Name = "Butter", Price = 1.8m, Category = ProductCategory.Food },
            new Product { Name = "Yogurt", Price = 0.9m, Category = ProductCategory.Food },
            new Product { Name = "Turkey", Price = 4.5m, Category = ProductCategory.Food },
            new Product { Name = "Pork", Price = 6.0m, Category = ProductCategory.Food },
            new Product { Name = "Salmon", Price = 8.0m, Category = ProductCategory.Food },
            new Product { Name = "Cereal", Price = 2.0m, Category = ProductCategory.Food },
            new Product { Name = "Butter", Price = 2.5m, Category = ProductCategory.Food },


                                          // Electronics Products           
            new Product { Name = "Laptop", Price = 1000.0m, Category = ProductCategory.Electronics },
            new Product { Name = "Smartphone", Price = 800.0m, Category = ProductCategory.Electronics },
            new Product { Name = "Tablet", Price = 600.0m, Category = ProductCategory.Electronics },
            new Product { Name = "Smartwatch", Price = 200.0m, Category = ProductCategory.Electronics },
            new Product { Name = "Headphones", Price = 100.0m, Category = ProductCategory.Electronics },
            new Product { Name = "Speaker", Price = 150.0m, Category = ProductCategory.Electronics },
            new Product { Name = "Camera", Price = 500.0m, Category = ProductCategory.Electronics },
            new Product { Name = "Printer", Price = 120.0m, Category = ProductCategory.Electronics },
            new Product { Name = "Mouse", Price = 20.0m, Category = ProductCategory.Electronics },
            new Product { Name = "Keyboard", Price = 30.0m, Category = ProductCategory.Electronics },
        };
        }

        public List<Product> GenerateRandomProducts()
        {
            Random random = new Random();
            List<Product> randomProducts = new List<Product>();

            List<Product> shuffledProducts = allProducts.OrderBy(x => random.Next()).ToList();

            for (int i = 0; i < 10 && i < shuffledProducts.Count; i++)
            {
                randomProducts.Add(shuffledProducts[i]);
            }

            return randomProducts;
        }

        public List<Product> GenerateFoodProducts()
        {
            return allProducts.Where(p => p.Category == ProductCategory.Food).Take(10).ToList();
        }

        public List<Product> GenerateClothingProducts()
        {
            return allProducts.Where(p => p.Category == ProductCategory.Clothing).Take(10).ToList();
        }

        public List<Product> GenerateElectronicsProducts()
        {
            return allProducts.Where(p => p.Category == ProductCategory.Electronics).Take(10).ToList();
        }
    }
}
