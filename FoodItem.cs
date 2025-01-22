namespace Mission3;

public class FoodItem
{
    // declare class vairables
    public string FoodName;
    public string FoodCategory;
    public int Quantity;
    public DateTime ExpirationDate;
    private string[] Categories = new string[] {"Dairy", "Produce", "Canned Goods", "Baked Goods", "Other" };
    
    // constructor that creates a new food time with the information passed in
    public FoodItem(string foodName, int foodCategory, int quantity, DateTime expirationDate)
    {
        FoodName = foodName;
        FoodCategory = Categories[foodCategory -1];
        Quantity = quantity;
        ExpirationDate = expirationDate;
    }

    // method used to display the current items in a format that can be easily read
    public void DisplayCurrentItems()
    { 
        Console.WriteLine(" Food Name: " + FoodName + "\n Food Category: " + FoodCategory + "\n Quantity: " + Quantity + "\n Expiration Date: " + ExpirationDate + "\n");
    }
}