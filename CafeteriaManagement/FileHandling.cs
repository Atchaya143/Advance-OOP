using System;
using System.IO;

namespace CafeteriaManagement
{
    public static class FileHandling
    {
        public static void Create()
        {
            //Create Folder
            if(!Directory.Exists("CafeteriaManagement"))
            {
                Console.WriteLine("Creating Folder...");
                Directory.CreateDirectory("CafeteriaManagement");
            }
            //Creating File
            if(!File.Exists("CafeteriaManagement/UserRegistration.csv"))
            {
                Console.WriteLine("Creating File...");
                File.Create("CafeteriaManagement/UserRegistration.csv").Close();
            }
            if(!File.Exists("CafeteriaManagement/FoodDetails.csv"))
            {
                Console.WriteLine("Creating File...");
                File.Create("CafeteriaManagement/FoodDetails.csv").Close();
            }
            if(!File.Exists("CafeteriaManagement/CartItems.csv"))
            {
                Console.WriteLine("Creating File...");
                File.Create("CafeteriaManagement/CartItems.csv").Close();
            }
            if(!File.Exists("CafeteriaManagement/OrderDetails.csv"))
            {
                Console.WriteLine("Creating File...");
                File.Create("CafeteriaManagement/OrderDetails.csv").Close();
            }
        }
        public static void WriteToCSV()
        {
            string [] users=new string[Operations.usersList.Count];
            for(int i=0;i<Operations.usersList.Count;i++)
            {
                users[i]=Operations.usersList[i].UserID+","+Operations.usersList[i].Name+","+Operations.usersList[i].FatherName+","+Operations.usersList[i].Gender+","+Operations.usersList[i].MobileNumber+","+Operations.usersList[i].MailID+","+Operations.usersList[i].WorkStationNumber+","+Operations.usersList[i].WalletBalance;
                
            }
            File.WriteAllLines("CafeteriaManagement/UserRegistration.csv",users);
            string [] foods=new string [Operations.foodList.Count];
            for(int i=0;i<Operations.foodList.Count;i++)
            {
                foods[i]=Operations.foodList[i].FoodID+","+Operations.foodList[i].FoodName+","+Operations.foodList[i].FoodPrice+","+Operations.foodList[i].AvailableQuantity;
            }
            File.WriteAllLines("CafeteriaManagement/FoodDetails.csv",foods);
            string [] carts=new string[Operations.cartList.Count];
            for(int i=0;i<Operations.cartList.Count;i++)
            {
                carts[i]=Operations.cartList[i].ItemID+","+Operations.cartList[i].OrderID+","+Operations.cartList[i].FoodID+","+Operations.cartList[i].OrderPrice+","+Operations.cartList[i].OrderQuantity;
            }
            File.WriteAllLines("CafeteriaManagement/CartItems.csv",carts);
            string [] orders=new string [Operations.orderList.Count];
            for(int i=0;i<Operations.orderList.Count;i++)
            {
                orders[i]=Operations.orderList[i].OrderID+","+Operations.orderList[i].UserID+","+Operations.orderList[i].OrderDate.ToString("dd/MM/yyyy")+","+Operations.orderList[i].TotalPrice+","+Operations.orderList[i].OrderStatus;
            }
            File.WriteAllLines("CafeteriaManagement/OrderDetails.csv",orders);
        }
        public static void ReadFromCSV()
        {
            string [] users=File.ReadAllLines("CafeteriaManagement/UserRegistration.csv");
            foreach(string user in users)
            {
                UserRegistration newObject=new UserRegistration(user);
                Operations.usersList.Add(newObject);
            }
            string [] foods=File.ReadAllLines("CafeteriaManagement/FoodDetails.csv");
            foreach(string food in foods)
            {
                FoodDetails newObject=new FoodDetails(food);
                Operations.foodList.Add(newObject);
            }
            string [] carts=File.ReadAllLines("CafeteriaManagement/CartItems.csv");
            foreach(string cart in carts)
            {
                CartItems newObject=new CartItems(cart);
                Operations.cartList.Add(newObject);

            }
            string [] orders=File.ReadAllLines("CafeteriaManagement/OrderDetails.csv");
            foreach(string order in orders)
            {
                OrderDetails newObject=new OrderDetails(order);
                Operations.orderList.Add(newObject);
            }
        }
    }
}