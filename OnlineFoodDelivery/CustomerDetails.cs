using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineFoodDelivery
{
    public class CustomerDetails:PersonalDetails,IBalance
    {
     private double _balance;
     private static int s_customerID=1000;
     public string CustomerID{get;set;}
     public double WalletBalance{get{return _balance;}}
     public CustomerDetails(string name,string fatherName,Gender gender,string mobileNumber,DateTime dob,string mailID,string location)
     :base(name,fatherName,gender,mobileNumber,dob,mailID,location)
     {
        s_customerID++;
        CustomerID="CID"+s_customerID;
     }  
     public CustomerDetails(string customer)
     {
      string [] values=customer.Split(",");
      CustomerID=values[0];
      s_customerID=int.Parse(values[0].Remove(0,3));
      Name=values[1];
      FatherName=values[2];
      Gender=Enum.Parse<Gender>(values[3]);
      MobileNumber=values[4];
      DOB=DateTime.ParseExact(values[5],"dd/MM/yyyy",null);
      MailID=values[6];
      Location=values[7];
     }
     public void WalletRecharge(double amount)
     {
        _balance+=amount;
     } 
     public void DeductBalance(double amount)
     {
        _balance-=amount;
     }
    }
}