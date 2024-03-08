using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineFoodDelivery
{
    public class Operations
    {
        public static CustomList<CustomerDetails> customerList = new CustomList<CustomerDetails>();
        public static CustomList<FoodDetails> foodList = new CustomList<FoodDetails>();
        public static CustomList<OrderDetails> orderList = new CustomList<OrderDetails>();
        public static CustomList<ItemDetails> itemList = new CustomList<ItemDetails>();
        static CustomerDetails currentUser;


        public static void DefaultData()
        {
            CustomerDetails cust1 = new CustomerDetails("Ravi", "Ettaparajan", Gender.Male, "4567895678", new DateTime(1999, 11, 11), "ravi@gmail.com", "Chennai");
            CustomerDetails cust2 = new CustomerDetails("Baskaran", "Sethurajan", Gender.Male, "4356785678", new DateTime(1999, 11, 11), "baskaran@gmail.com", "Chennai");
            customerList.AddRange(new CustomList<CustomerDetails>() { cust1, cust2 });

            FoodDetails food1 = new FoodDetails("Chicken Briyani 1Kg", 100, 12);
            FoodDetails food2 = new FoodDetails("Mutton Briyani 1Kg", 150, 10);
            FoodDetails food3 = new FoodDetails("Veg Full Meals", 80, 30);
            FoodDetails food4 = new FoodDetails("Noodles", 100, 40);
            FoodDetails food5 = new FoodDetails("Dosa", 40, 40);
            FoodDetails food6 = new FoodDetails("Idly(2  Pieces)", 20, 50);
            FoodDetails food7 = new FoodDetails("Pongal", 40, 20);
            FoodDetails food8 = new FoodDetails("Vegetable Briyani", 80, 15);
            FoodDetails food9 = new FoodDetails("Lemon Rice", 50, 30);
            FoodDetails food10 = new FoodDetails("Veg Pulav", 120, 30);
            FoodDetails food11 = new FoodDetails("Chicken 65(200 Grams)", 75, 30);
            foodList.AddRange(new CustomList<FoodDetails>() { food1, food2, food3, food4, food5, food6, food7, food8, food9, food10, food11 });

            OrderDetails order1 = new OrderDetails("CID1001", 580, new DateTime(2022, 11, 26), OrderStatus.Ordered);
            OrderDetails order2 = new OrderDetails("CID1002", 870, new DateTime(2022, 11, 26), OrderStatus.Ordered);
            OrderDetails order3 = new OrderDetails("CID1001", 820, new DateTime(2022, 11, 26), OrderStatus.Cancelled);
            orderList.AddRange(new CustomList<OrderDetails>() { order1, order2, order3 });

            ItemDetails item1 = new ItemDetails("OID3001", "FID101", 2, 200);
            ItemDetails item2 = new ItemDetails("OID3001", "FID102", 2, 300);
            ItemDetails item3 = new ItemDetails("OID3001", "FID103", 1, 80);
            ItemDetails item4 = new ItemDetails("OID3002", "FID101", 1, 100);
            ItemDetails item5 = new ItemDetails("OID3002", "FID102", 4, 600);
            ItemDetails item6 = new ItemDetails("OID3002", "FID110", 1, 100);
            ItemDetails item7 = new ItemDetails("OID3002", "FID109", 1, 50);
            ItemDetails item8 = new ItemDetails("OID3003", "FID102", 2, 300);
            ItemDetails item9 = new ItemDetails("OID3003", "FID108", 4, 320);
            ItemDetails item10 = new ItemDetails("OID3001", "FID101", 2, 200);
            itemList.AddRange(new CustomList<ItemDetails>() { item1, item2, item3, item4, item5, item6, item7, item8, item9, item10 });
        }

        //Main Menu Method Starts
        public static void MainMenu()
        {
            bool mainFlag = true;
            do
            {
                Console.WriteLine("*******************Main Menu*******************");
                Console.WriteLine("1.Customer Registration\n2.Customer Login\n3.Exit");
                Console.Write("Enter Your Option: ");
                int mainOption = int.Parse(Console.ReadLine());
                switch (mainOption)
                {
                    case 1:
                        {
                            Registration();
                            break;
                        }
                    case 2:
                        {
                            Login();
                            break;
                        }
                    case 3:
                        {
                            mainFlag = false;
                            Console.WriteLine("Exited Successfully!");
                            break;
                        }
                }
            } while (mainFlag);
        }
        //Registration Method starts
        public static void Registration()
        {
            Console.WriteLine("************************Registration Page************************");
            Console.Write("Enter Your Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter Your Father Name: ");
            string fatherName = Console.ReadLine();
            Console.Write("Enter Your Gender(Female,Male,Transgender): ");
            Gender gender = Enum.Parse<Gender>(Console.ReadLine());
            Console.Write("Enter your Mobile Number: ");
            string mobileNumber = Console.ReadLine();
            Console.Write("Enter Your Date Of Birth(dd/MM/yyyy): ");
            DateTime dob = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);
            Console.Write("Enter Your Mail ID: ");
            string mailID = Console.ReadLine();
            Console.Write("Enter Your Location(City): ");
            string location = Console.ReadLine();
            //Creating object
            CustomerDetails obj1 = new CustomerDetails(name, fatherName, gender, mobileNumber, dob, mailID, location);
            customerList.Add(obj1);
            Console.WriteLine($"Customer Registration successful!\nYour Customer ID is: {obj1.CustomerID}");
        }

        //Login Method Starts
        public static void Login()
        {
            Console.WriteLine("****************Login Page*****************");
            Console.Write("Enter Your Customer ID: ");
            string custID1 = Console.ReadLine().ToUpper();
            Console.WriteLine("******************Login Page*******************");
            Console.Write("Enter Your User ID: ");
            string userID1 = Console.ReadLine().ToUpper();
            currentUser = BinarySearch(customerList, userID1);
            if (currentUser == null)
            {
                Console.WriteLine("Invalid User ID");
            }
            else
            {
                Console.WriteLine("Logged Successfully!");
                SubMenu();
            }
        }

        //SubMenu Method Starts
        public static void SubMenu()
        {
            bool subFlag = true;
            do
            {
                Console.WriteLine("**********Sub Menu***********");
                Console.WriteLine("1.Show Profile\n2.Order Food\n3.Cancel Order\n4.Modify Order\n5.Order History\n6.Recharge Wallet\n7.Show Wallet Balance\n8.Exit");
                Console.Write("Enter Your Option: ");
                int subOption = int.Parse(Console.ReadLine());
                switch (subOption)
                {
                    case 1:
                        {
                            ShowProfile();
                            break;
                        }
                    case 2:
                        {
                            OrderFood();
                            break;
                        }
                    case 3:
                        {
                            OrderCancel();
                            break;
                        }
                    case 4:
                        {
                            ModifyOrder();
                            break;
                        }
                    case 5:
                        {
                            ShowOrderDetails();
                            break;
                        }
                    case 6:
                        {
                            WalleteRecharge();
                            break;
                        }
                    case 7:
                        {
                            ShowBalance();
                            break;
                        }
                    case 8:
                        {
                            subFlag = false;
                            break;
                        }
                }
            } while (subFlag);
        }
        //Submenu method ends

        //Show Profile Method Starts
        public static void ShowProfile()
        {
            bool flag = true;
            Console.WriteLine("|Customer ID| |Name| |Father Name| |Gender| |Mobile Number| |Mail ID| |Date of Birth| |Location | ");
            foreach (CustomerDetails user in customerList)
            {
                if (currentUser.CustomerID.Equals(user.CustomerID))
                {
                    flag = false;
                    Console.WriteLine($"|{user.CustomerID}| |{user.Name}| |{user.FatherName}| |{user.Gender}| |{user.MobileNumber}| |{user.DOB}||{user.MailID}| |{user.Location}|");
                    break;
                }
            }
            if (flag)
            {
                Console.WriteLine("No Details Found!");
            }
        }
        //Order Food Method Starts
        public static void OrderFood()
        {
            CustomList<ItemDetails> temp = new CustomList<ItemDetails>();
            OrderDetails newOrder = new OrderDetails(currentUser.CustomerID, 0, DateTime.Now, OrderStatus.Initiated);
            string reply = "";
            do
            {
                //Showing Food List
                Console.WriteLine("|Food ID| |Food Name| |Price| |Available Quantity|");
                foreach (FoodDetails food in foodList)
                {
                    Console.WriteLine($"|{food.FoodID}| |{food.FoodName}| |{food.PricePerQuantity}| |{food.QuantityAvailable}|");
                }
                //Ask The User To pick Food ID and quantity
                Console.Write("Enter the Food ID to order: ");
                string foodID1 = Console.ReadLine().ToUpper();
                Console.Write("Enter the Quantity: ");
                int quantity1 = int.Parse(Console.ReadLine());
                bool flag = true;
                foreach (FoodDetails food in foodList)
                {
                    //Checking Food is available or not
                    if (food.FoodID.Equals(foodID1))
                    {
                        flag = false;
                        if (quantity1 <= food.QuantityAvailable)
                        {
                            food.QuantityAvailable -= quantity1;
                            double amount = quantity1 * food.PricePerQuantity;
                            ItemDetails newItem = new ItemDetails(newOrder.OrderID, food.FoodID, quantity1, amount);
                            temp.Add(newItem);
                        }
                        else
                        {
                            Console.WriteLine("Food is not available for the entered count");
                        }
                    }
                }
                if (flag)
                {
                    Console.WriteLine("Invalid Food ID, enter a valid one..");
                }


                Console.Write("Do You Want to Purcahse another product: ");
                reply = Console.ReadLine().ToLower();
            } while (reply == "yes");
            Console.Write("Do you want purchase the wish list(yes/no): ");
            string reply1 = Console.ReadLine().ToLower();
            bool flag1 = false;
            if (reply1 == "yes")
            {
                double totalPrice = 0;
                foreach (ItemDetails item in temp)
                {
                    totalPrice += item.PriceOfOrder;
                }
                do
                {
                    if (currentUser.WalletBalance >= totalPrice)
                    {
                        currentUser.DeductBalance(totalPrice);
                        itemList.AddRange(temp);
                        newOrder.TotalPrice = totalPrice;
                        newOrder.OrderStatus = OrderStatus.Ordered;
                        orderList.Add(newOrder);
                        System.Console.WriteLine("Ordered Successfully");
                        flag1 = true;
                    }
                    else
                    {
                        Console.WriteLine("Do You want to recharge your wallet(yes/no): ");
                        string answer = Console.ReadLine().ToLower();
                        if (answer == "yes")
                        {
                            Console.Write("Enter the amount to be recharged: ");
                            double price = double.Parse(Console.ReadLine());
                            currentUser.WalletRecharge(price);
                            flag1 = false;
                        }
                        else
                        {
                            foreach (FoodDetails food in foodList)
                            {
                                foreach (ItemDetails item in temp)
                                {
                                    if (item.FoodID == food.FoodID)
                                    {
                                        food.QuantityAvailable += item.PurchaseCount;
                                    }
                                }
                            }
                            System.Console.WriteLine("Order Cancelled due to insufficient Balance!");
                        }
                    }
                } while (!flag1);

            }
            else
            {
                foreach (FoodDetails food in foodList)
                {
                    foreach (ItemDetails item in temp)
                    {
                        if (item.FoodID == food.FoodID)
                        {
                            food.QuantityAvailable += item.PurchaseCount;
                        }
                    }
                }
                System.Console.WriteLine("Order Cancelled!");
            }
        }
        //Order Food Method Starts

        //Cancel Order Method Starts
        public static void OrderCancel()
        {
            bool flag = true;
            Console.WriteLine("|Order ID| |Customer ID| |Total Price| |Order Date|  |Order Status|");
            foreach (OrderDetails order in orderList)
            {
                if (currentUser.CustomerID.Equals(order.CustomerID) && order.OrderStatus == OrderStatus.Ordered)
                {
                    flag = false;
                    Console.WriteLine($"|{order.OrderID}| |{order.CustomerID}| |{order.TotalPrice}| |{order.DateOfOrder.ToString("dd/MM/yyyy")}| |{order.OrderStatus}|");
                }
            }
            Console.Write("Enter the Order ID to cancel order: ");
            string orderID1 = Console.ReadLine().ToUpper();
            foreach (OrderDetails order in orderList)
            {
                if (currentUser.CustomerID.Equals(order.CustomerID) && order.OrderStatus == OrderStatus.Ordered)
                {
                    if (order.OrderID.Equals(orderID1))
                    {
                        double amount = order.TotalPrice;
                        currentUser.WalletRecharge(amount);
                        order.TotalPrice -= amount;
                        order.OrderStatus = OrderStatus.Cancelled;
                        foreach (ItemDetails cart in itemList)
                        {
                            if (order.OrderID.Equals(cart.OrderID))
                            {
                                foreach (FoodDetails food in foodList)
                                {
                                    if (cart.FoodID.Equals(food.FoodID))
                                    {
                                        food.QuantityAvailable += cart.PurchaseCount;
                                        Console.WriteLine("Order Cancelled Successfully!");
                                        break;
                                    }
                                }
                            }
                        }

                    }
                    else
                    {
                        Console.WriteLine("Invalid Order ID,Enter a valid one.");
                        break;
                    }
                }
            }
            if (flag)
            {
                Console.WriteLine("No Order details found!..");
            }
        }
        //Modify Order Method Starts
        public static void ModifyOrder()
        {
            bool flag = true;
            Console.WriteLine("|Order ID| |Customer ID| |Total Price||Order Date|  |Order Status|");
            foreach (OrderDetails order in orderList)
            {
                if (currentUser.CustomerID.Equals(order.CustomerID) && order.OrderStatus == OrderStatus.Ordered)
                {
                    flag = false;
                    Console.WriteLine($"|{order.OrderID}||{order.CustomerID}| |{order.TotalPrice}| |{order.DateOfOrder.ToString("dd/MM/yyyy")}| |{order.TotalPrice}| |{order.OrderStatus}|");
                }
            }
            if (flag)
            {
                Console.WriteLine("No Order Details found");
            }
            else
            {
                Console.Write("Enter the Order ID to modify the order: ");
                string orderID1 = Console.ReadLine().ToUpper();
                bool flag1 = true;
                foreach (OrderDetails order in orderList)
                {
                    if (order.OrderID.Equals(orderID1))
                    {
                        flag1 = false;
                        if (currentUser.CustomerID.Equals(order.CustomerID) && order.OrderStatus == OrderStatus.Ordered)
                        {
                            Console.WriteLine("|Item ID| |Order ID| |Food ID| |Purchase Count| |PriceOfOrder|");
                            foreach (ItemDetails item in itemList)
                            {
                                if (item.OrderID.Equals(orderID1))
                                {
                                    Console.WriteLine($"|{item.ItemID}| |{item.OrderID}| |{item.FoodID}| |{item.PurchaseCount}| |{item.PriceOfOrder}|");
                                }
                            }
                            Console.Write("Enter the Item ID to modify: ");
                            string itemID1 = Console.ReadLine().ToUpper();
                            bool flag2 = true;
                            foreach (ItemDetails item in itemList)
                            {
                                if (item.ItemID.Equals(itemID1))
                                {
                                    flag2 = false;
                                    Console.Write("Enter the new Quantity to be modified: ");
                                    int quantity = int.Parse(Console.ReadLine());
                                    if (quantity < item.PurchaseCount)
                                    {
                                        int diff = item.PurchaseCount - quantity;
                                        foreach (FoodDetails food in foodList)
                                        {
                                            if (item.FoodID.Equals(food.FoodID))
                                            {
                                                food.QuantityAvailable += diff;
                                                item.PurchaseCount -= diff;
                                                double amount = diff * food.PricePerQuantity;
                                                currentUser.WalletRecharge(amount);
                                                order.TotalPrice -= amount;
                                                item.PriceOfOrder -= amount;
                                                Console.WriteLine("Order Modified  Successfully!");
                                                break;
                                            }
                                        }
                                    }
                                    else if (quantity > item.PurchaseCount)
                                    {
                                        int diff = quantity - item.PurchaseCount;
                                        foreach (FoodDetails food in foodList)
                                        {
                                            if (item.FoodID.Equals(food.FoodID))
                                            {
                                                food.QuantityAvailable -= diff;
                                                double amount = diff * food.PricePerQuantity;
                                                bool flagI = false;
                                                do
                                                {
                                                    if (currentUser.WalletBalance >= amount)
                                                    {
                                                        food.QuantityAvailable += diff;
                                                        item.PurchaseCount -= diff;
                                                        double amount1 = diff * food.PricePerQuantity;
                                                        currentUser.WalletRecharge(amount);
                                                        order.TotalPrice -= amount;
                                                        item.PriceOfOrder -= amount;
                                                        Console.WriteLine("Order Modified  Successfully!");
                                                        flagI = true;
                                                    }
                                                    else
                                                    {
                                                        System.Console.WriteLine("Insufficient Balance!\nDo you want to recharge(yes/no)");
                                                        string choice1 = Console.ReadLine().ToLower();
                                                        if (choice1 == "yes")
                                                        {

                                                            System.Console.WriteLine("enter the amount: ");
                                                            double amount2 = double.Parse(Console.ReadLine());
                                                            currentUser.WalletRecharge(amount2);
                                                        }
                                                        else
                                                        {
                                                            System.Console.WriteLine("Order Cancelled due to insufficient balance");
                                                        }

                                                    }
                                                } while (!flagI);
                                            }
                                        }
                                    }
                                }
                                break;
                            }
                            if (flag2)
                            {
                                Console.WriteLine("Invalid Item ID/ID not found!");
                            }
                        }

                    }
                    break;
                }
                if (flag1)
                {
                    System.Console.WriteLine("Invaild OrderId");
                }
            }

        }
        //Show Order Details
        public static void ShowOrderDetails()
        {
            bool flag = true;
            Console.WriteLine("|Order ID| |User ID| |Total Price| |Order Date|  |Order Status|");
            foreach (OrderDetails order in orderList)
            {
                if (currentUser.CustomerID.Equals(order.CustomerID))
                {
                    flag = false;
                    Console.WriteLine($"|{order.OrderID}| |{order.CustomerID}| |{order.TotalPrice}| |{order.DateOfOrder}|  |{order.OrderStatus}|");
                }
            }
            if (flag)
            {
                Console.WriteLine("No Order details found!..");
            }

        }
        public static void WalleteRecharge()
        {
            Console.WriteLine("Enter the amount to be recharged: ");
            double amount = double.Parse(Console.ReadLine());
            currentUser.WalletRecharge(amount);
            Console.WriteLine($"Your WalletBalance is: {currentUser.WalletBalance}");
        }
        //Wallet Recharge Method ends

        //Show Balance Method starts
        public static void ShowBalance()
        {
            Console.WriteLine($"Your Wallet Balance is: {currentUser.WalletBalance}");
        }
        //Bianry Search for login
        public static CustomerDetails BinarySearch(CustomList<CustomerDetails> usersList, string customerID)
        {
            int left = 0;
            int right = usersList.Count - 1;
            while (left <= right)
            {
                int middle = left + ((right - left) / 2);
                int result = customerID.CompareTo(usersList[middle].CustomerID);
                if (result == 0)
                {
                    return usersList[middle];
                }
                else if (result == -1)
                {
                    right = middle - 1;
                }
                else
                {
                    left = middle + 1;
                }
            }
            return null;
        }
    }
}
