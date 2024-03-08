using System;
namespace OnlineFoodDelivery;
class Program{
    public static void Main(string [] args)
    {
        FileHandling.Create();
        // Operations.DefaultData();
        FileHandling.ReadFromCSV();
        Operations.MainMenu();
        FileHandling.WriteToCSV();
    }
}
