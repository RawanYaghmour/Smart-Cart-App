using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart_Cart_App
{
    public class ShoppingCart
    {
        private List<Product> items;
        private ProductGenerator productGenerator;

        public ShoppingCart()
        {
            items = new List<Product>();
            productGenerator = new ProductGenerator();
        }

        public void AddItem(Product product)
        {
            items.Add(product);
        }

        public void RemoveItem(Product product)
        {
            items.Remove(product);
        }

        public List<Product> ViewItems()
        {
            return new List<Product>(items);
        }

        public decimal CalculateTotalCost()
        {
            return items.Sum(item => item.GetPrice());
        }

        public void Shop(object store)
        {
            List<Product> products = null;

            if (store is GroceryStore groceryStore)
            {
                products = groceryStore.DisplayProducts();
            }
            else if (store is ClothingStore clothingStore)
            {
                products = clothingStore.DisplayProducts();
            }
            

            if (products != null)
            {
                SelectProduct(products, store);
            }
        }

        private void SelectProduct(List<Product> products, object store)
        {
            for (int i = 0; i < products.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {products[i].Name} - {products[i].Price:C} ({products[i].Category}) ");
            }
            Console.WriteLine("0. Back to main menu");

            Console.WriteLine("Select a product to add in your cart:");
            int productIndex = int.Parse(Console.ReadLine()) - 1;

            if (productIndex == -1)
            {
                return;
            }

            if (productIndex >= 0 && productIndex < products.Count)
            {
                if (store is GroceryStore groceryStore)
                {
                    groceryStore.AddToCart(products[productIndex], this);
                }
                else if (store is ClothingStore clothingStore)
                {
                    clothingStore.AddToCart(products[productIndex], this);
                }
                

                Console.WriteLine($"{products[productIndex].Name} has been added to your cart.");
            }
            else
            {
                Console.WriteLine("Invalid selection. Try again.");
            }
        }

        public void ViewCart()
        {
            List<Product> items = ViewItems();
            if (items.Count == 0)
            {
                Console.WriteLine("Your cart is empty.");
                return;
            }

            Console.WriteLine("Items in your cart:");
            for (int i = 0; i < items.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {items[i].Name} - {items[i].Price:C} ({items[i].Category}) - Price: {items[i].GetPrice():C}");
            }

            Console.WriteLine($"Total Cost: {CalculateTotalCost():C}");

            Console.WriteLine("Do you want to remove an item from your cart? (yes/no)");
            string response = Console.ReadLine().ToLower();
            if (response == "yes")
            {
                Console.WriteLine("0. Back to main menu");
                Console.WriteLine("Select an item to remove:");
                int itemIndex = int.Parse(Console.ReadLine()) - 1;
                if (itemIndex == -1)
                {
                    return;
                }
                if (itemIndex >= 0 && itemIndex < items.Count)
                {
                    RemoveItem(items[itemIndex]);
                    Console.WriteLine($"{items[itemIndex].Name} has been removed from your cart.");
                }
                else
                {
                    Console.WriteLine("Invalid selection. Try again.");
                }
            }
        }

        public void ShowRandomProducts()
        {
            List<Product> randomProducts = productGenerator.GenerateRandomProducts();

            Console.WriteLine("Random products from all categories:");
            for (int i = 0; i < randomProducts.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {randomProducts[i].Name} - {randomProducts[i].Price:C} ({randomProducts[i].Category}) ");
            }
            Console.WriteLine("0. Back to main menu");

            Console.WriteLine("Select a product to add to your cart:");
            int productIndex = int.Parse(Console.ReadLine()) - 1;

            if (productIndex == -1)
            {
                return;
            }

            if (productIndex >= 0 && productIndex < randomProducts.Count)
            {
                AddItem(randomProducts[productIndex]);
                Console.WriteLine($"{randomProducts[productIndex].Name} has been added to your cart.");
            }
            else
            {
                Console.WriteLine("Invalid selection. Try again.");
            }
        }

        public void Checkout()
        {
            Console.Clear();
            List<Product> items = ViewItems();
            if (items.Count == 0)
            {
                Console.WriteLine("Your cart is empty.");
                return;
            }

            Console.WriteLine("----- Invoice -----");
            Console.WriteLine($"{"Item",-20} {"Category",-15} {"Price",-10} {"Total",-10}");
            Console.WriteLine(new string('-', 65));

            decimal totalCost = 0;
            foreach (var item in items)
            {
                string itemName = item.Name;
                string itemCategory = item.Category.ToString();
                string itemPrice = item.Price.ToString("C");
                string itemDiscount = item.ToString() + "%";
                string itemTotal = item.GetPrice().ToString("C");

                Console.WriteLine($"{itemName,-20} {itemCategory,-15} {itemPrice,-10}  {itemTotal,-10}");
                totalCost += item.GetPrice();
            }

            Console.WriteLine(new string('-', 65));
            Console.WriteLine($"{"Total Cost",-55} {totalCost:C}");
            Console.WriteLine(new string('-', 65));
            Console.WriteLine("\nThank you for shopping in my Smart Cart Applivation");
        }
    }
}
