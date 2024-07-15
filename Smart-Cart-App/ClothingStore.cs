using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart_Cart_App
{
    public class ClothingStore
    {
        private List<Product> products;
        private ProductGenerator generator;

        public ClothingStore()
        {
            generator = new ProductGenerator();
            products = generator.GenerateClothingProducts();
        }

        public List<Product> DisplayProducts()
        {
            return new List<Product>(products);
        }

        public void AddToCart(Product product, ShoppingCart cart)
        {
            cart.AddItem(product);
        }
    }
}
