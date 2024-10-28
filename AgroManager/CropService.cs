using System;

namespace AgroManager
{
    public class CropService
    {
        public void AddCrop(Farm farm, string fieldNumber, string? cropType, DateTime sowingDate, double areaInHectares)
        {
            Field? field = farm.FieldsList.Find(f => f.FieldNumber == fieldNumber);
            if (field == null) throw new ArgumentException("Pole o podanym numerze nie istnieje.");

            Crop newCrop = new Crop
            {
                FieldNumber = fieldNumber,
                CropType = cropType,
                SowingDate = sowingDate,
                AreaInHectares = areaInHectares
            };
            field.Crops.Add(newCrop);
        }

        public bool IsAreaValid(Farm farm, string? fieldNumber, double areaInHectares)
        {
            Field? field = farm.FieldsList.Find(f => f.FieldNumber == fieldNumber);
            return field != null && areaInHectares <= field.AreaInHectares;
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