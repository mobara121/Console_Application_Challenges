using Gold_Badge_Console_App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_RamenCafe_Console
{
    class ProgramUI
    {
        //Repositoryをcallするためにfieldを作成
        private MenuRepository _itemRepo = new MenuRepository();

        public void Run()
        {
            AddItemList();
            Organize();
        }

        private void Organize()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                // Display options
                Console.WriteLine("Select an organizing option\n" +
                    "1. Create New Item\n" +
                    "2. View All Item\n" +
                    "3. View Item By Number\n" +
                    "4. Update Existing Item\n" +
                    "5. Delete Existing Item\n" +
                    "6. Exit"
                    );

                //Get Owner's input
                string input = Console.ReadLine();

                // Evaluate Owner's input and act accordingly
                switch (input)
                {
                    case "1":
                        CreateItem();
                        break;
                    case "2":
                        ViewAllItem();
                        break;
                    case "3":
                        ViewItemByNumber();
                        break;
                    case "4":
                        UpdateItem();
                        break;
                    case "5":
                        DeleteItem();
                        break;
                    case "6":
                        Console.WriteLine("Good-bye");
                        keepRunning = false;
                        break;

                    default:
                        Console.WriteLine("Please enter valid number");
                        break;
                }
                Console.WriteLine("Please press any ket to continue");

                Console.ReadKey();

                Console.Clear();
            }
        }

        private void CreateItem()
        {
            Console.Clear();

            Menu newItem = new Menu();

            //Number
            Console.WriteLine("Enter the Item No. :");
            string numberAsString = Console.ReadLine();
            newItem.Number = int.Parse(numberAsString);

            //Name
            Console.WriteLine("Enter the Item Name :");
            newItem.Name = Console.ReadLine();

            //Description
            Console.WriteLine("Enter the Item Description :");
            newItem.Description = Console.ReadLine();

            //Price
            Console.WriteLine("Enter the Item Price :");
            string priceAsString = Console.ReadLine();
            newItem.Price = double.Parse(priceAsString);

            //ListOfIngredient
            Console.WriteLine("Enter the Soup Taste of the Item :\n" +
                "1. Pork Bone\n" +
                "2. Miso\n" +
                "3. Soy sauce\n" +
                "4. Salt\n" +
                "5. Kimchi"
                );
            string ingredientAsString = Console.ReadLine();
            int ingredientInt = int.Parse(ingredientAsString);
            newItem.TypeOfIngredient = (IngredientType)ingredientInt;

            _itemRepo.AddItemToMenu(newItem);

        }
        
        private void ViewAllItem()
        {
            Console.Clear();
            List<Menu> listOfItem = _itemRepo.GetMenus();
            foreach (Menu item in listOfItem)
            {
                Console.WriteLine($"Item Number: {item.Number}\n" +
                    $"Item Name: {item.Name}\n" +
                    $"Description: {item.Description}\n" +
                    $"Price: {item.Price}\n" +
                    $"Soup taste: {item.TypeOfIngredient}"
                    );
            }

        }
        
        private void ViewItemByNumber()
        {
            Console.Clear();

            //Owner to enter an item number
            Console.WriteLine("Enter the item number you'd like to see");

            //Get the owner's input
            string numberAsString = Console.ReadLine();
            int number = int.Parse(numberAsString);

            //Find the item by that number
            Menu item = _itemRepo.GetItemByNumber(number);

            //Display said item if it isn't null
            if (item != null)
            {
                Console.WriteLine($"Item Number: {item.Number}\n" +
                    $"Item Name: {item.Name}\n" +
                    $"Description: {item.Description}\n" +
                    $"Price: {item.Price}\n" +
                    $"Soup taste: {item.TypeOfIngredient}"
                    );
            }
            else
            {
                Console.WriteLine("No item found by that number");
            }

        }
        
        private void UpdateItem()
        {
            //Display all item
            ViewAllItem();

            //Ask for the item number tp update
            Console.WriteLine("Enter the item number you'd like to update");

            //Get that number
            string oldNumberAsString = Console.ReadLine();
            int oldNumber = int.Parse(oldNumberAsString);

            //To build a new object
            Console.Clear();

            Menu newItem = new Menu();

            //Number
            Console.WriteLine("Enter the Number");
            string numberAsString = Console.ReadLine();
            newItem.Number = int.Parse(numberAsString);
            //Name
            Console.WriteLine("Enter the Name");
            newItem.Name = Console.ReadLine();

            //Description
            Console.WriteLine("Enter the Description");
            newItem.Description = Console.ReadLine();

            //Price
            Console.WriteLine("Enter the Price");
            string priceAsString = Console.ReadLine();
            newItem.Price = double.Parse(priceAsString);

            //Ingredient
            Console.WriteLine("Enter the soup type:\n" +
                "1. Pork Bone\n" +
                "2. Miso\n" +
                "3. Soy sauce\n" +
                "4. Salt\n" +
                "5. Kimchi"
                );
            string ingredientAsString = Console.ReadLine();
            int ingredientAsInt = int.Parse(ingredientAsString);
            newItem.TypeOfIngredient = (IngredientType)ingredientAsInt;

            // To verify the update worked
            bool wasUpdated = _itemRepo.UpdateExistingItem(oldNumber, newItem);
            if (wasUpdated)
            {
                Console.WriteLine("Sucessfully updated!");
            }
            else
            {
                Console.WriteLine("Couldn't be updated.");
            }

        }
        
        private void DeleteItem()
        {
            Console.Clear();

            ViewAllItem();

            // Get the number they want to remove
            Console.WriteLine("Enter the item number you'd like to remove");
            string input = Console.ReadLine();
            int inputAsInteger = int.Parse(input);
            // Call the delete method
            bool wasDeleted = _itemRepo.RemoveItemFromList(inputAsInteger);

            //if the item was deleted...
            if (wasDeleted)
            {
                Console.WriteLine("The item was sucessfully deleted");
            }
            else
            {
                Console.WriteLine();
            }

        }

        //To Add sample of item
        private void AddItemList()
        {
            Menu Tonkotsu = new Menu(1, "Tonkotsu", "Rich flavour of pork-bone stock", 10.5, IngredientType.Pork_Bone);
            Menu Shoyu = new Menu(2, "Shoyu", "harmony of soy sauce and umami flavour", 9.5, IngredientType.Soy_sauce);
            Menu Spicy_Shoyu = new Menu(3, "Spicy-Shoyu", "Spices worked well with soy sauce", 9.5, IngredientType.Soy_sauce);

            _itemRepo.AddItemToMenu(Tonkotsu);
            _itemRepo.AddItemToMenu(Shoyu);
            _itemRepo.AddItemToMenu(Spicy_Shoyu);

        }
        

        

        

    }

}
