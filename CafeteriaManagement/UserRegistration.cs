using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CafeteriaManagement
{
    public class UserRegistration:PersonalInfo,IBalance
    {
        /*
        UserDetails Class: 
        UserDetails class should inherit IBalance & PersonalDetails.
        UserDetails class should have below properties and methods.
        Properties:
        •	UserID (Auto Incremented – SF1001)
        •	WorkStationNumber
        •	Field: _balance
        •	Read only property: WalletBalance.
        Methods:
        •	WalletRecharge, DeductAmount
        */
        private static int s_userID=1000;
        public string UserID{get;set;}
        public string WorkStationNumber{get;set;}
        private double _balance;
        public double WalletBalance{get{return _balance;}}
        public UserRegistration(string name,string fatherName,Gender gender,string mobileNumber,string mailID,string workStationNumber)
        :base( name, fatherName, gender, mobileNumber,mailID)
        {
            s_userID++;
            UserID="SF"+s_userID;
            // Name=name;
            // FatherName=fatherName;
            // Gender=gender;
            // MobileNumber=mobileNumber;
            // MailID=mailID;
            WorkStationNumber=workStationNumber;
        }
        public void WalletRecharge(double amount)
        {
            _balance+=amount;
        }
        public  void DeductAmount(double amount)
        {
            _balance-=amount;
        }
        public UserRegistration(string user)
        {
            string [] values=user.Split(",");
            UserID=values[0];
            s_userID=int.Parse(values[0].Remove(0,2));
            Name=values[1];
            FatherName=values[2];
            Gender=Enum.Parse<Gender>(values[3]);
            MobileNumber=values[4];
            MailID=values[5];
            WorkStationNumber=values[6];
            _balance=double.Parse(values[7]);
        }
        
    }
}