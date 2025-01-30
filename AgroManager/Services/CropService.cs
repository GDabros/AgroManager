using AgroManager.Models;
using System;
using System.Linq;

namespace AgroManager.Services
{
    public class CropService
    {
        public void AddCrop(Farm farm, string fieldNumber, string? cropType, DateTime sowingDate, double areaInHectares)
        {
            Field? field = farm.FieldsList.Find(f => f.FieldNumber == fieldNumber);

            if (field == null)
            {
                Console.WriteLine($"Pole o numerze {fieldNumber} nie istnieje.");
                return;
            }

            if (areaInHectares > field.AreaInHectares)
            {
                Console.WriteLine($"Nie można dodać uprawy. Podana powierzchnia ({areaInHectares} ha) przekracza dostępną powierzchnię pola ({field.AreaInHectares} ha).");
                return;
            }

            // Tworzenie nowej uprawy
            Crop newCrop = new Crop
            {
                FieldNumber = fieldNumber,
                CropType = cropType,
                SowingDate = sowingDate,
                AreaInHectares = areaInHectares
            };

            field.Crops.Add(newCrop);
            Console.WriteLine($"Nowa uprawa ({cropType}) została dodana do pola {fieldNumber}.");
        }

        public void DisplayCropsInfo(Farm farm)
        {
            foreach (var field in farm.FieldsList)
            {
                Console.WriteLine($"Pole: {field.FieldNumber}");

                if (field.Crops.Any())
                {
                    Console.WriteLine("Uprawy:");
                    foreach (var crop in field.Crops)
                    {
                        Console.WriteLine($"- Rodzaj uprawy: {crop.CropType}, Data siewu: {crop.SowingDate:yyyy-MM-dd}, Obszar (ha): {crop.AreaInHectares}");
                    }
                }
                else
                {
                    Console.WriteLine("Brak upraw na tym polu.");
                }
            }
        }
    }
}
