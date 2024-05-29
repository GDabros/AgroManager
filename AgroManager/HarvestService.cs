using System;
using System.Linq;

namespace AgroManager
{
    public class HarvestService
    {
        public void AddHarvest(Farm farm)
        {
            Console.WriteLine("Dodaj nowy zbiór:");
            Console.Write("Numer pola: ");
            string? fieldNumber = Console.ReadLine();
            Field? field = farm.FieldsList.Find(f => f.FieldNumber == fieldNumber);

            if (field == null)
            {
                Console.WriteLine("Pole o podanym numerze nie istnieje.");
                return;
            }

            if (!field.Crops.Any())
            {
                Console.WriteLine("Na tym polu nie ma żadnej uprawy. Dodaj uprawę przed dodaniem zbioru.");
                return;
            }

            Crop selectedCrop = field.Crops[0];
            Console.Write("Data zbioru (RRRR-MM-DD): ");
            if (!DateTime.TryParse(Console.ReadLine(), out DateTime harvestDate))
            {
                Console.WriteLine("Niepoprawny format daty.");
                return;
            }
            Console.Write("Ilość zbioru w tonach: ");
            if (!double.TryParse(Console.ReadLine(), out double quantityInTons))
            {
                Console.WriteLine("Niepoprawny format ilości.");
                return;
            }
            Console.Write("Wilgotność zbioru (%): ");
            if (!double.TryParse(Console.ReadLine(), out double moisture))
            {
                Console.WriteLine("Niepoprawny format wilgotności.");
                return;
            }
            Console.Write("Jakość zbioru: ");
            string? quality = Console.ReadLine();

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

            Console.WriteLine("Nowy zbiór został dodany pomyślnie.");
            Console.WriteLine("Pole gotowe na nową uprawę.");
        }

        public void DisplayHarvestsInfo(Farm farm)
        {
            Console.WriteLine("Informacje o zbiorach z pól:");
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