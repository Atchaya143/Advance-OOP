using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineFoodDelivery
{
    public enum OrderStatus{Default,Initiated,Ordered,Cancelled};
    public class OrderDetails
    {
        private static int s_orderID=3000;
        public string OrderID{get;set;}
        public string CustomerID{get;set;}
        public double TotalPrice{get;set;}
        public DateTime DateOfOrder{get;set;}
        public OrderStatus OrderStatus{get;set;}
        public OrderDetails(string customerID,double totalPrice,DateTime dateOfOrder,OrderStatus orderStatus)
        {
            s_orderID++;
            OrderID="OID"+s_orderID;
            CustomerID=customerID;
            TotalPrice=totalPrice;
            DateOfOrder=dateOfOrder;
            OrderStatus=orderStatus;
        }
        public OrderDetails(string order)
        {
            string [] values=order.Split(",");
            OrderID=values[0];
            s_orderID=int.Parse(values[0].Remove(0,3));
            CustomerID=values[1];
            TotalPrice=double.Parse(values[2]);
            DateOfOrder=DateTime.ParseExact(values[3],"dd/MM/yyyyy",null);
            OrderStatus=Enum.Parse<OrderStatus>(values[4]);
        }

    }
}