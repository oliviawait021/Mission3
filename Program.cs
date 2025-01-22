// Olivia Fowler Mission 3 Project

using System.Runtime.InteropServices;
using Mission3;

// declare variables
int userInput = 0;
string foodName = null;
int foodCategory = 0;
int foodQuantity = 0;
string date = null;
var listOfFood = new List<FoodItem>(); // create list to store all of the food item instances
int loop = 1;
string input = "";
int removeVariable;
bool isValidDate = false;
bool isValidCategory = false;
bool isValidQuanitity = false;
bool isValidRemove = false;
bool isValidInput = false;
DateTime expirationDate = DateTime.Today;

// a few obejcts made to help test
FoodItem f1 = new FoodItem("Milk", 1, 10, new DateTime(2025, 2, 1));
FoodItem f2 = new FoodItem("Apples", 2, 50, new DateTime(2025, 1, 31));
FoodItem f3 = new FoodItem("Canned Beans", 3, 30, new DateTime(2027, 1, 1));
FoodItem f4 = new FoodItem("Bread", 4, 15, new DateTime(2025, 1, 25));
FoodItem f5 = new FoodItem("Chips", 5, 20, new DateTime(2025, 6, 15));

// add the obejcts to a new list
listOfFood.Add(f1);
listOfFood.Add(f2);
listOfFood.Add(f3);
listOfFood.Add(f4);
listOfFood.Add(f5);

// welcome user
Console.WriteLine("Hello! Welcome to the food bank's inventory system. ");

// make a loop that displays main menu until the user wishes to exit the program
while (loop == 1)
{
    // reset the main menu input
    isValidInput = false;
    
    while (!isValidInput)
    {
        // display navigation, and respond to input
        Console.WriteLine("\n What would you like to do? \n 1 - Add a Food Item \n 2 - Delete a Food Item \n 3 -" +
                          " Print List of Current Food Items \n 4 - Exit the Program");
        string input6 = Console.ReadLine();
        
        // error handle for the main menu input
        if (int.TryParse(input6, out userInput))
        {
            isValidInput = true;
        }
        else
        {
            Console.WriteLine("\n Invalid input! Try again...");
        }
    }

    // call the method from the Food Item Class that they selected
    // add item to list
    if (userInput == 1)
    {
        // get food info to create the item
        Console.WriteLine("What is the name of the food item?");
        foodName = Console.ReadLine();

        // error handle for the category
        while (!isValidCategory)
        {
            Console.WriteLine("What is the name of the food category?");
            Console.WriteLine(" 1 - Dairy \n 2 - Produce \n 3 - Canned Goods \n 4 - Baked Goods \n 5 - Other");
            string input2 = Console.ReadLine();
            
            // error handle for category numbers
            if (int.TryParse(input2, out foodCategory) && (foodCategory == 1 | foodCategory == 2 | foodCategory == 3 |
                                                           foodCategory == 4 | foodCategory == 5))
            {
                isValidCategory = true;
            }
            else
            {
                Console.WriteLine("\n Invalid food category! Try again...");
            } 
        }
        
        isValidCategory = false;

        // error handle for the quantity
        while (!isValidQuanitity)
        {
            Console.WriteLine("What is the quanitity of the food item?");
            string input3 = Console.ReadLine();
            
            
            if (int.TryParse(input3, out foodQuantity))
            {
                isValidQuanitity = true;
            }
            else
            {
                Console.WriteLine("\n Invalid food quanitity! Try again...");
            }
        }
        
        isValidQuanitity = false;

        // error handle for the valid date
        while (!isValidDate)
        {
            Console.WriteLine("Please enter a valid date (e.g., yyyy-MM-dd):");
            date = Console.ReadLine();
            
            // parse to the correct date data type
            if (DateTime.TryParse(date, out expirationDate))
            {
                isValidDate = true; 
                Console.WriteLine($"You entered a valid date: {expirationDate}");
            }
            else
            {
                Console.WriteLine("Error: Invalid date format. Try again!");
            }
        }
        
        isValidDate = false;

        // create new food Item
        FoodItem foodItem;
        foodItem = new FoodItem(foodName, foodCategory, foodQuantity, expirationDate);
        listOfFood.Add(foodItem);

        // send confirmation to user
        Console.WriteLine("\n" + foodItem.FoodCategory + " was added to the inventory.");
    }
    
    // remove certain item
    else if (userInput == 2)
    {
        int counter = 1;
        // display items so the user knows what item to delete
        foreach (var foodItem in listOfFood)
        {
            Console.WriteLine(counter + " - ");
            foodItem.DisplayCurrentItems();
            counter++;
        }

        // error handle for removing input that is incorrect
        while (!isValidRemove)
        {
            Console.WriteLine("Choose the food item from the entries above you would like to remove?");
            string input4 = Console.ReadLine();

            if (int.TryParse(input4, out removeVariable) && removeVariable >= 1 && removeVariable <= listOfFood.Count)
            {
                isValidRemove = true;
                // get the name of the item removed to display to the user
                string removeName = listOfFood[removeVariable - 1].FoodName;
        
                // remove item at the correct location
                listOfFood.Remove(listOfFood[removeVariable - 1]);
        
                // tell user it has been deleted
                Console.WriteLine(removeName + " has been removed from the inventory.");
            }
            else
            {
                Console.WriteLine("Error: Invalid food item number. Try again!");
            }
        }
        isValidRemove = false;
    }
    
    // display current items
    else if (userInput == 3)
    {
        // print out if there aren't any items in the inventory
        if (listOfFood.Count == 0)
        {
            Console.WriteLine("There are no items in the inventory.");
        }
        // display the food times with the DisplayCurrentItems method
        else
        {
            Console.WriteLine("Current Food Items \n ");
            foreach (var foodItem in listOfFood)
            {
                foodItem.DisplayCurrentItems();
            }
            // allow the display show until the user is ready to return to the main menu
            Console.WriteLine("Type 'y' to return to the main menu:");
            string input5 = Console.ReadLine();

            while (input5.ToLower() != "y")
            {
                Console.WriteLine("Invalid input. Type 'y' when you're ready to return to the main menu:");
                input5 = Console.ReadLine();
            }

            Console.WriteLine("Returning to Main Menu...");
        }
    }
    // exit program
    else if (userInput == 4)
    {
        // exit the program by closing the loop
        Console.WriteLine("Exiting program...");
        loop = 0;
    }
    else
    {
        Console.WriteLine("Invalid input! Try again...");
    }
}

// end program and thank user
Console.WriteLine("Thank you for accessing your inventory.");