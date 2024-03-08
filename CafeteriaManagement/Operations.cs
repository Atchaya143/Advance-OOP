using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading.Tasks;

namespace CafeteriaManagement
{
    public static class Operations
    {
        //List creation for User Registration class
        public static CustomList<UserRegistration> usersList = new CustomList<UserRegistration>();

        //List Creation for Food Details class
        public static CustomList<FoodDetails> foodList = new CustomList<FoodDetails>();
        //List Creation for Order Details class
        public static CustomList<OrderDetails> orderList = new CustomList<OrderDetails>();
        //List Creation for CartItems class
        public static CustomList<CartItems> cartList = new CustomList<CartItems>();
        //Global Object Creation
        static UserRegistration currentUser;

        //Default Data Method Starts
        public static void DefaultData()
        {
            /*
            UserID	UserName	FatherName	MobileNumber	MailID	Gender	WorkStationNumber	Balance
            SF1001	Ravichandran	Ettapparajan	8857777575	ravi@gmail.com
            Male	WS101	400
            SF1002	Baskaran	Sethurajan	9577747744	baskaran@gmail.com	Male	WS105	500
            */
            UserRegistration user1 = new UserRegistration("Ravichandran", "Ettaparajan", Gender.Male, "576564587", "ravi@gmail.com", "WS101");
            UserRegistration user2 = new UserRegistration("Baskaran", "Sethurajan", Gender.Male, "576674587", "baskaran@gmail.com", "WS105");
            usersList.AddRange(new CustomList<UserRegistration>() { user1, user2 });
            /*
            FoodID	FoodName	Price	AvailableQuantity
            FID101	Coffee	20	100
            FID102	Tea	15	100
            FID103	Biscuit	10	100
            FID104	Juice	50	100
            FID105	Puff	40	100
            FID106	Milk	10	100
            FID107	Popcorn	20	20
            */
            FoodDetails food1 = new FoodDetails("Coffee", 20, 100);
            FoodDetails food2 = new FoodDetails("Tea", 15, 100);
            FoodDetails food3 = new FoodDetails("Biscuit", 10, 100);
            FoodDetails food4 = new FoodDetails("Juice", 50, 100);
            FoodDetails food5 = new FoodDetails("Puff", 40, 100);
            FoodDetails food6 = new FoodDetails("Milk", 10, 100);
            FoodDetails food7 = new FoodDetails("Popcorn", 20, 20);
            foodList.AddRange(new CustomList<FoodDetails>() { food1, food2, food3, food4, food5, food6, food7 });
            /*
            ItemID	OrderID	FoodID	OrderPrice	OrderQuantity
            ITID101	OID1001	FID101	20	1
            ITID102	OID1001	FID103	10	1
            ITID103	OID1001	FID105	40	1
            ITID104	OID1002	FID103	10	1
            ITID105	OID1002	FID104	50	1
            ITID106	OID1002	FID105	40	1
            */
            CartItems cart1 = new CartItems("OID1001", "FID101", 20, 1);
            CartItems cart2 = new CartItems("OID1001", "FID103", 10, 1);
            CartItems cart3 = new CartItems("OID1001", "FID105", 40, 1);
            CartItems cart4 = new CartItems("OID1002", "FID103", 10, 1);
            CartItems cart5 = new CartItems("OID1002", "FID104", 50, 1);
            CartItems cart6 = new CartItems("OID1002", "FID105", 40, 1);
            cartList.AddRange(new CustomList<CartItems>() { cart1, cart2, cart3, cart4, cart5, cart6 });
            /*
            OrderID	UserID	OrderDate	TotalPrice	OrderStatus
            OID1001	SF1001	15/06/2022	70	Ordered
            OID1002	SF1002	15/06/2022	100	Ordered
            */
            OrderDetails order1 = new OrderDetails("SF1001", new DateTime(2022, 06, 15), 70, OrderStatus.Ordered);
            OrderDetails order2 = new OrderDetails("SF1002", new DateTime(2022, 06, 15), 100, OrderStatus.Ordered);
            orderList.AddRange(new CustomList<OrderDetails>() { order1, order2 });
        }

        //Main Menu Method starts
        public static void MainMenu()
        {
            bool mainFlag = true;
            do
            {
                Console.WriteLine("***************Main Menu******************");
                Console.WriteLine("1.User Registration\n2.User Login\n3.Exit");
                Console.Write("Enter Your Choice: ");
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
                            Console.WriteLine("Exites  Successfully!");
                            mainFlag = false;
                            break;
                        }
                }
            } while (mainFlag);
        }
        //Main menthod ends

        //Registration method starts
        public static void Registration()
        {
            Console.WriteLine("*****************Registration Page*****************");
            Console.Write("Enter Your Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter Your Father Name: ");
            string fatherName = Console.ReadLine();
            Console.Write("Enter Your Gender: ");
            Gender gender = Enum.Parse<Gender>(Console.ReadLine());
            Console.Write("Enter Your Mobile Number: ");
            string mobileNumber = Console.ReadLine();
            Console.Write("Enter Your Mail ID: ");
            string mailID = Console.ReadLine();
            Console.Write("Enter Work Station Number: ");
            string workStationNumber = Console.ReadLine();
            UserRegistration obj1 = new UserRegistration(name, fatherName, gender, mobileNumber, mailID, workStationNumber);
            usersList.Add(obj1);
            Console.WriteLine($"Registration was completed successfully!\nYour User ID is: {obj1.UserID}");
        }
        //Registration Method ends

        //Login Method starts
        public static void Login()
        {

            Console.WriteLine("******************Login Page*******************");
            Console.Write("Enter Your User ID: ");
            string userID1 = Console.ReadLine().ToUpper();
            currentUser = BinarySearch(usersList, userID1);
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
        //Login Method Ends

        //Sub Menu Method Starts
        public static void SubMenu()
        {
            bool subFlag = true;
            do
            {
                Console.WriteLine("***************Sub Menu*****************");
                Console.WriteLine("1.Show My Profile\n2.Food Order\n3.Modify Order\n4.Cancel Order\n5.Order History\n6.Wallet Recharge\n7.Show Wallet Balance\n8.Exit");
                Console.Write("Enter Your Option: ");
                int subOption = int.Parse(Console.ReadLine());
                switch (subOption)
                {
                    case 1:
                        {
                            ShowMyProfile();
                            break;
                        }
                    case 2:
                        {
                            FoodOrder();
                            break;
                        }
                    case 3:
                        {
                            ModifyOrder();
                            break;
                        }
                    case 4:
                        {
                            CancelOrder();
                            break;
                        }
                    case 5:
                        {
                            OrderHistory();
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
        //Submenu Method Ends

        //Show My Profile Method Starts
        public static void ShowMyProfile()
        {
            bool flag = true;
            Console.WriteLine("|User ID| |Name| |Father Name| |Gender| |Mobile Number| |Mail ID| |Work Station Number| ");
            foreach (UserRegistration user in usersList)
            {
                if (currentUser.UserID.Equals(user.UserID))
                {
                    flag = false;
                    Console.WriteLine($"|{user.UserID}| |{user.Name}| |{user.FatherName}| |{user.Gender}| |{user.MobileNumber}| |{user.MailID}| |{user.WorkStationNumber}|");
                    break;
                }
            }
            if (flag)
            {
                Console.WriteLine("No Details Found!");
            }
        }
        //Show My Profile Method Ends

        //Food Order Method Starts
        public static void FoodOrder()
        {
            //creating cartItemList Creation
            CustomList<CartItems> temp = new CustomList<CartItems>();
            OrderDetails newOrder = new OrderDetails(currentUser.UserID, DateTime.Now, 0, OrderStatus.Initiated);

            string reply = "";
            do
            {


                //Showing Food List
                Console.WriteLine("|Food ID| |Food Name| |Price| |Available Quantity|");
                foreach (FoodDetails food in foodList)
                {
                    Console.WriteLine($"|{food.FoodID}| |{food.FoodName}| |{food.FoodPrice}| |{food.AvailableQuantity}|");
                }

                //Creating Object for Order Class


                //Ask The User To pick Food ID and quantity
                Console.Write("Enter the Food ID to order: ");
                string foodID1 = Console.ReadLine().ToUpper();
                Console.Write("Enter the Quantity: ");
                int quantity1 = int.Parse(Console.ReadLine());
                //Checking the foodID and available count
                bool flag = true;
                foreach (FoodDetails food in foodList)
                {
                    if (foodID1.Equals(food.FoodID))
                    {
                        flag = false;
                        if (food.AvailableQuantity > quantity1)
                        {

                            double price = quantity1 * food.FoodPrice;
                            food.AvailableQuantity -= quantity1;
                            CartItems newCart = new CartItems(newOrder.OrderID, food.FoodID, price, quantity1);
                            temp.Add(newCart);

                        }
                        else
                        {
                            Console.WriteLine("Food is not available for the selected quantity");

                        }
                        break;
                    }

                }
                if (flag)
                {
                    Console.WriteLine("Invalid Food ID, enter a valid one.");
                }
                //Asking the user to order food for another time
                Console.Write("Do you want to pick another product(yes/no): ");
                reply = Console.ReadLine().ToLower();
            } while (reply == "yes");
            Console.Write("Do you want purchase the wish list(yes/no): ");
            string reply1 = Console.ReadLine().ToLower();
            bool flag1 = false;
            if (reply1 == "yes")
            {
                do
                {
                    double amount = 0;
                    foreach (CartItems item in temp)
                    {
                        amount += item.OrderPrice;
                    }
                    if (amount <= currentUser.WalletBalance)
                    {
                        flag1 = true;
                        currentUser.DeductAmount(amount);
                        cartList.AddRange(temp);
                        newOrder.TotalPrice = amount;
                        newOrder.OrderStatus = OrderStatus.Ordered;
                        orderList.Add(newOrder);
                        System.Console.WriteLine("Ordered Successfully");
                    }
                    else
                    {

                        System.Console.WriteLine("Insufficient Balance!\nDo you want to recharge(yes/no)");
                        string choice1 = Console.ReadLine().ToLower();
                        if (choice1 == "yes")
                        {
                            System.Console.Write("enter the amount: ");
                            double amount1 = double.Parse(Console.ReadLine());
                            currentUser.WalletRecharge(amount1);
                            flag1 = false;
                        }
                        else
                        {
                            foreach (FoodDetails food in foodList)
                            {
                                foreach (CartItems item in temp)
                                {
                                    if (item.FoodID == food.FoodID)
                                    {
                                        food.AvailableQuantity += item.OrderQuantity;
                                    }
                                }
                            }
                            System.Console.WriteLine("Order Cancelled due to insufficient balance");
                        }

                    }
                } while (!flag1);
            }
            else
            {
                foreach (FoodDetails food in foodList)
                {
                    foreach (CartItems item in temp)
                    {
                        if (item.FoodID == food.FoodID)
                        {
                            food.AvailableQuantity += item.OrderQuantity;
                        }
                    }
                }
                System.Console.WriteLine("Order Cancelled!");
            }
        }
        //Modify Order Method Starts
        public static void ModifyOrder()
        {

            bool flag = true;
            Console.WriteLine("|Order ID| |User ID| |Order Date| |Total Price| |Order Status|");
            foreach (OrderDetails order in orderList)
            {
                if (currentUser.UserID.Equals(order.UserID) && order.OrderStatus == OrderStatus.Ordered)
                {
                    flag = false;
                    Console.WriteLine($"|{order.OrderID}||{order.UserID}| |{order.OrderDate.ToString("dd/MM/yyyy")}| |{order.TotalPrice}| |{order.OrderStatus}|");
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
                foreach (OrderDetails order in orderList)
                {
                    if (currentUser.UserID.Equals(order.UserID) && order.OrderStatus == OrderStatus.Ordered)
                    {

                        if (order.OrderID.Equals(orderID1))
                        {
                            Console.WriteLine("|Item ID| |Order ID| |Food ID| |Order Price| |Order Quantity|");
                            foreach (CartItems cart in cartList)
                            {
                                if (cart.OrderID.Equals(order.OrderID))
                                {
                                    Console.WriteLine($"|{cart.ItemID}| |{cart.OrderID}| |{cart.FoodID}| |{cart.OrderPrice}| |{cart.OrderQuantity}");

                                }
                            }
                            Console.Write("Enter the item ID: ");
                            string itemID1 = Console.ReadLine().ToUpper();
                            foreach (CartItems cart in cartList)
                            {
                                if (cart.ItemID == itemID1)
                                {
                                    Console.Write("Enter the Quantity: ");
                                    int newQuantity = int.Parse(Console.ReadLine());
                                    if (newQuantity < cart.OrderQuantity)
                                    {
                                        int diff = cart.OrderQuantity - newQuantity;
                                        foreach (FoodDetails food in foodList)
                                        {
                                            if (cart.FoodID.Equals(food.FoodID))
                                            {
                                                food.AvailableQuantity += diff;
                                                cart.OrderQuantity -= diff;
                                                double amount = diff * food.FoodPrice;
                                                currentUser.WalletRecharge(amount);
                                                order.TotalPrice -= amount;
                                                cart.OrderPrice -= amount;
                                                Console.WriteLine("Order Modified  Successfully!");
                                                break;
                                            }
                                        }
                                    }
                                    else if (newQuantity > cart.OrderQuantity)
                                    {
                                        int diff = newQuantity - cart.OrderQuantity;
                                        foreach (FoodDetails food in foodList)
                                        {

                                            if (cart.FoodID.Equals(food.FoodID))
                                            {
                                                food.AvailableQuantity -= diff;
                                                double amount = diff * food.FoodPrice;
                                                bool flag2 = false;
                                                do
                                                {
                                                    if (currentUser.WalletBalance >= amount)
                                                    {
                                                        food.AvailableQuantity -= diff;
                                                        cart.OrderQuantity += diff;
                                                        double amount1 = diff * food.FoodPrice;
                                                        currentUser.DeductAmount(amount1);
                                                        order.TotalPrice += amount1;
                                                        cart.OrderPrice += amount1;
                                                        Console.WriteLine("Order Modified  Successfully!");
                                                        flag2 = true;
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
                                                } while (!flag2);
                                            }
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("You already entered the same quantity!..");
                                    }
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid ID,please enter a valid one");
                        }

                    }
                }
            }
        }
        //Modify Method ends
        //Cancel Order Method Starts
        public static void CancelOrder()
        {
            bool flag = true;
            Console.WriteLine("|Order ID| |User ID| |Order Date| |Total Price| |Order Status|");
            foreach (OrderDetails order in orderList)
            {
                if (currentUser.UserID.Equals(order.UserID) && order.OrderStatus == OrderStatus.Ordered)
                {
                    flag = false;
                    Console.WriteLine($"|{order.OrderID}| |{order.UserID}| |{order.OrderDate}| |{order.TotalPrice}| |{order.OrderStatus}|");
                }
            }
            Console.Write("Enter the Order ID to cancel order: ");
            string orderID1 = Console.ReadLine().ToUpper();
            bool flag1=true;
            foreach (OrderDetails order in orderList)
            {
                if (currentUser.UserID.Equals(order.UserID) && order.OrderStatus == OrderStatus.Ordered)
                {
                    flag1=false;
                    
                    if (order.OrderID.Equals(orderID1))
                    {
                        double amount = order.TotalPrice;
                        currentUser.WalletRecharge(amount);
                        order.TotalPrice -= amount;
                        order.OrderStatus = OrderStatus.Cancelled;
                        foreach (CartItems cart in cartList)
                        {
                            if (order.OrderID.Equals(cart.OrderID))
                            {
                                foreach (FoodDetails food in foodList)
                                {
                                    if (cart.FoodID.Equals(food.FoodID))
                                    {
                                        food.AvailableQuantity += cart.OrderQuantity;
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
                    break;
                }
                if(flag1)
                {
                    Console.WriteLine("Invalid ID/Status");
                }
            }
            if (flag)
            {
                Console.WriteLine("No Order details found!..");
            }
        }
        //Cancel Order Method ends
        //Show Order History Method Starts
        public static void OrderHistory()
        {
            bool flag = true;
            Console.WriteLine("|Order ID| |User ID| |Order Date| |Total Price| |Order Status|");
            foreach (OrderDetails order in orderList)
            {
                if (currentUser.UserID.Equals(order.UserID))
                {
                    flag = false;
                    Console.WriteLine($"|{order.OrderID}| |{order.UserID}| |{order.OrderDate}| |{order.TotalPrice}| |{order.OrderStatus}|");
                }
            }
            if (flag)
            {
                Console.WriteLine("No Order details found!..");
            }
        }
        //Order History Method ends
        //Wallet Recharge Method Starts
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
        //show balance method ends

        //Binary Search Method Starts
        public static UserRegistration BinarySearch(CustomList<UserRegistration> usersList, string userID)
        {
            int left = 0;
            int right = usersList.Count - 1;
            while (left <= right)
            {
                int middle = left + ((right - left) / 2);
                int result = userID.CompareTo(usersList[middle].UserID);
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