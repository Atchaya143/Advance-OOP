using System;
using System.IO;

namespace OnlineFoodDelivery
{
    public static class FileHandling
    {
       public static void Create()
       {
        //Folder
        if(!Directory.Exists("OnlineFoodDelivery"))
        {
            System.Console.WriteLine("Creating Folder...");
            Directory.CreateDirectory("OnlineFoodDelivery");
        }
        //File
        if(!File.Exists("OnlineFoodDelivery/CustomerDetails.csv"))
        {
            System.Console.WriteLine("Creating File...");
            File.Create("OnlineFoodDelivery/CustomerDetails.csv").Close();
        }
        if(!File.Exists("OnlineFoodDelivery/FoodDetails.csv"))
        {
            System.Console.WriteLine("Creating File....");
            File.Create("OnlineFoodDelivery/FoodDetails.csv").Close();
        }
        if(!File.Exists("OnlineFoodDelivery/ItemDetails.csv"))
        {
            System.Console.WriteLine("Creating File...");
            File.Create("OnlineFoodDelivery/ItemDetails.csv").Close();
        }
        if(!File.Exists("OnlineFoodDelivery/OrderDetails.csv"))
        {
            System.Console.WriteLine("Creating File....");
            File.Create("OnlineFoodDelivery/OrderDetails.csv").Close();
        }
       } 
       //Write To Csv Method Starts
       public static void WriteToCSV()
       {
        string [] customers=new string[Operations.customerList.Count];
        for(int i=0;i<Operations.customerList.Count;i++)
        {
            customers[i]=Operations.customerList[i].Name+","+Operations.customerList[i].FatherName+","+Operations.customerList[i].Gender+","+Operations.customerList[i].MobileNumber+","+Operations.customerList[i].DOB+","+Operations.customerList[i].MailID+","+Operations.customerList[i].Location;
        }
        File.WriteAllLines("OnlineFoodDelivery/CustomerDetails.csv",customers);
        string [] foods=new string[Operations.foodList.Count];
        for(int i=0;i<Operations.foodList.Count;i++)
        {
            foods[i]=Operations.foodList[i].FoodID+","+Operations.foodList[i].FoodName+","+Operations.foodList[i].PricePerQuantity+","+Operations.foodList[i].QuantityAvailable;
        }
        File.WriteAllLines("OnlineFoodDelivery/FoodDetails.csv",foods);
        string [] items=new string[Operations.itemList.Count];
        for(int i=0;i<Operations.itemList.Count;i++)
        {
            items[i]=Operations.itemList[i].ItemID+","+Operations.itemList[i].OrderID+","+Operations.itemList[i].FoodID+","+Operations.itemList[i].PurchaseCount+","+Operations.itemList[i].PriceOfOrder;
        }
        File.WriteAllLines("OnlineFoodDelivery/ItemDetails.csv",items);
        string [] orders=new string[Operations.orderList.Count];
        for(int i=0;i<Operations.orderList.Count;i++)
        {
            orders[i]=Operations.orderList[i].OrderID+","+Operations.orderList[i].CustomerID+","+Operations.orderList[i].TotalPrice+","+Operations.orderList[i].DateOfOrder+","+Operations.orderList[i].OrderStatus;
        }
        File.WriteAllLines("OnlineFoodDelivery/OrderDetails.csv",orders);

       }
       //ReadFromCSV Method Starts
       public static void ReadFromCSV()
       {
        string [] customers=File.ReadAllLines("OrderFoodDelivery/CustomerDetails.csv");
        foreach(string customer in customers)
        {
            CustomerDetails newObject=new CustomerDetails(customer);
            Operations.customerList.Add(newObject);
        }
        string [] foods=File.ReadAllLines("OnlineFoodDelivery/FoodDetails.csv");
        foreach(string food in foods)
        {
            FoodDetails newObject=new FoodDetails(food);
            Operations.foodList.Add(newObject);
        }
        string [] items=File.ReadAllLines("OnlineFoodDelivery/ItemDetails.csv");
        foreach(string item in items)
        {
            ItemDetails newObject=new ItemDetails(item);
            Operations.itemList.Add(newObject);
        }
        string [] orders=File.ReadAllLines("OnlineFoodDelivery/OrderDetails.csv");
        foreach(string order in orders)
        {
            OrderDetails newObject=new OrderDetails(order);
            Operations.orderList.Add(newObject);
        }
       }
    }
}