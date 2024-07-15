namespace Smart_Cart_App
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("****** Welcome to Smart Cart Application Mall ******\n");
            Thread.Sleep(700);
            ShoppingCart cart = new ShoppingCart();
            GroceryStore groceryStore = new GroceryStore();
            ClothingStore clothingStore = new ClothingStore();

            while (true)
            {
                Thread.Sleep(700);
                Console.WriteLine("1- Shop at Grocery Store");
                Console.WriteLine("2- Shop at Clothing Store");
                Console.WriteLine("3- Show Random Products from All Categories");
                Console.WriteLine("4- View Shopping Cart");
                Console.WriteLine("5- Checkout and Exit");


                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        cart.Shop(groceryStore);
                        break;
                    case "2":
                        cart.Shop(clothingStore);
                        break;
                    case "3":
                        cart.ShowRandomProducts();
                        break;
                    case "4":
                        cart.ViewCart();
                        break;
                    case "5":
                        cart.Checkout();
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        break;
                }
            }
        }
    }
}
