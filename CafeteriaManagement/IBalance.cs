using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CafeteriaManagement
{
    public interface IBalance
    {
        /*
        Properties: WalletBalance
        Method: WalletRecharge, DeductAmount
        */
       
         double WalletBalance{get;}
         void WalletRecharge(double amount);
         void DeductAmount(double amount);
    }
}