using AgroManager.Models;
using System;

namespace AgroManager.Services
{
    public class HarvestService
    {
        public void AddHarvest(Farm farm, string fieldNumber, DateTime harvestDate, double quantityInTons, double moisture, string? quality)
        {
            Field? field = farm.FieldsList.Find(f => f.FieldNumber == fieldNumber);
            if (field == null)
            {
                throw new ArgumentException("Pole o podanym numerze nie istnieje.");
            }

            if (!field.Crops.Any())
            {
                throw new ArgumentException("Na tym polu nie ma żadnej uprawy. Dodaj uprawę przed dodaniem zbioru.");
            }

            Crop selectedCrop = field.Crops[0];

            Harvest newHarvest = new Harvest
            {
                FieldNumber = fieldNumber,
                CropType = selectedCrop.CropType,
                HarvestDate = harvestDate,
                QuantityInTons = quantityInTons,
                Moisture = moisture,
                Quality = quality
            };

            field.Harvests.Add(newHarvest);
            field.Crops.Clear();
        }

        public void DisplayHarvestsInfo(Farm farm)
        {
            foreach (var field in farm.FieldsList)
            {
                Console.WriteLine($"Pole: {field.FieldNumber}");
                if (field.Harvests.Any())
                {
                    Console.WriteLine("Zbiory:");
                    foreach (var harvest in field.Harvests)
                    {
                        Console.WriteLine($"- Rodzaj uprawy: {harvest.CropType}, Data zbioru: {harvest.HarvestDate:yyyy-MM-dd}, Ilość (tony): {harvest.QuantityInTons}, Wilgotność (%): {harvest.Moisture}, Jakość: {harvest.Quality}");
                    }
                }
                else
                {
                    Console.WriteLine("Brak zbiorów z tego pola.");
                }
            }
        }
    }
}