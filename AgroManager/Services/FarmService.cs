using AgroManager.Models;
using System;

namespace AgroManager
{
    public class FarmService
    {
        public void CreateFarm(Farm farm, string farmName, string location)
        {
            farm.FarmName = farmName;
            farm.Location = location;
        }

        public void DisplayFarmInfo(Farm farm)
        {
            Console.WriteLine($"Nazwa gospodarstwa: {farm.FarmName}");
            Console.WriteLine($"Lokalizacja: {farm.Location}");
            Console.WriteLine($"Liczba pól: {farm.FieldsList.Count}");
            Console.WriteLine($"Hektary łącznie: {farm.FieldsList.Sum(field => field.AreaInHectares)}");
        }

        public void EditFarmName(Farm farm, string newFarmName)
        {
            farm.FarmName = newFarmName;
        }

        public void EditFarmLocation(Farm farm, string newLocation)
        {
            farm.Location = newLocation;
        }
    }
}