using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineFoodDelivery
{
    public enum Gender{Select,Male,Female,Transgender}
    public class PersonalDetails
    {
        public string Name{get;set;}
        public  string FatherName{get;set;}
        public Gender Gender{get;set;}
        public string MobileNumber{get;set;}
        public DateTime DOB{get;set;}
        public string MailID{get;set;}
        public string Location{get;set;}

        public PersonalDetails()
        {

        }
        public PersonalDetails(string name,string fatherName,Gender gender,string mobileNumber,DateTime dob,string mailID,string location)
        {
            Name=name;
            FatherName=fatherName;
            Gender=gender;
            MobileNumber=mobileNumber;
            DOB=dob;
            MailID=mailID;
            Location=location;
        }

    }
}