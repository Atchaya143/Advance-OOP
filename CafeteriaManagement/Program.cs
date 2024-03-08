using System;
namespace CafeteriaManagement;
class Program{
    public static void Main(string [] args)
    {
        FileHandling.Create();
        //Operations.DefaultData();
        FileHandling.ReadFromCSV();
        Operations.MainMenu();
        FileHandling.WriteToCSV();
    }
}
