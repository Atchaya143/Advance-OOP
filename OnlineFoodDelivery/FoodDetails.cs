using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineFoodDelivery
{
    public class FoodDetails
    {
        private static int s_foodID=100;
        public string FoodID{get;set;}
        public string FoodName{get;set;}
        public double PricePerQuantity{get;set;}
        public int QuantityAvailable{get;set;}
        public FoodDetails(string foodName,double pricePerQuantity,int quantityAvailable)
        {
            s_foodID++;
            FoodID="FID"+s_foodID;
            FoodName=foodName;
            PricePerQuantity=pricePerQuantity;
            QuantityAvailable=quantityAvailable;
        }
        public FoodDetails(string food)
        {
            string [] values=food.Split(",");
            FoodID=values[0];
            s_foodID=int.Parse(values[0].Remove(0,3));
            FoodName=values[1];
            PricePerQuantity=double.Parse(values[2]);
            QuantityAvailable=int.Parse(values[3]);
        }
    }
}