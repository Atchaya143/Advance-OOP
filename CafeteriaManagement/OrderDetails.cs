using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CafeteriaManagement
{
    public enum OrderStatus{Default,Initiated,Ordered,Cancelled}
    public class OrderDetails
    {
        /*
        •	OrderID (Auto – OID1001)
        •	UserID
        •	OrderDate
        •	TotalPrice
        •	OrderStatus – (Default, Initiated, Ordered, Cancelled)
        */
        private static int s_orderID=1000;
        public string OrderID{get;set;}
        public string UserID{get;set;}
        public DateTime OrderDate{get;set;}
        public double TotalPrice{get;set;}
        public OrderStatus OrderStatus{get;set;}
        public OrderDetails(string userID,DateTime orderDate,double totalPrice,OrderStatus orderStatus)
        {
            s_orderID++;
            OrderID="OID"+s_orderID;
            UserID=userID;
            OrderDate=orderDate;
            TotalPrice=totalPrice;
            OrderStatus=orderStatus;
        }
        public OrderDetails(string order)
        {
            string [] values=order.Split(",");
            OrderID=values[0];
            s_orderID=int.Parse(values[0].Remove(0,3));
            UserID=values[1];
            OrderDate=DateTime.ParseExact(values[2],"dd/MM/yyyy",null);
            TotalPrice=double.Parse(values[3]);
            OrderStatus=Enum.Parse<OrderStatus>(values[4]);
        }
    }
}