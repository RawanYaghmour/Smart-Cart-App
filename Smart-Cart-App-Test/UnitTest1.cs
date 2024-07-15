using Smart_Cart_App;

namespace Smart_Cart_App_Test
{
    public class UnitTest1
    {
        [Fact]
        public void AddItem()
        {
            var cart = new ShoppingCart();
            var product = new Product { Name = "Apple", Price = 10.0m, Category = ProductCategory.Food };

            cart.AddItem(product);

            Assert.Single(cart.ViewItems());
        }

        [Fact]
        public void RemoveItem()
        {
            var cart = new ShoppingCart();
            var product = new Product { Name = "Apple", Price = 10.0m, Category = ProductCategory.Food };
            cart.AddItem(product);

            cart.RemoveItem(product);

            Assert.Empty(cart.ViewItems());
        }

        [Fact]
        public void CalculateTotalCost()
        {
            var cart = new ShoppingCart();
            var product1 = new Product { Name = "Apple", Price = 10.0m, Category = ProductCategory.Food };
            var product2 = new Product { Name = "Jacket", Price = 20.0m, Category = ProductCategory.Clothing };

            cart.AddItem(product1);
            cart.AddItem(product2);

            decimal total = cart.CalculateTotalCost();

            Assert.Equal(30.0m, total);
        }
    }
}