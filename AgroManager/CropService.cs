using System;
using System.Linq;

namespace AgroManager
{
    public class CropService
    {
        public void AddCrop(Farm farm)
        {
            Console.WriteLine("Dodaj nową uprawę:");
            Console.Write("Numer pola: ");
            string? fieldNumber = Console.ReadLine();
            Field? field = farm.FieldsList.Find(f => f.FieldNumber == fieldNumber);

            if (field == null)
            {
                Console.WriteLine("Pole o podanym numerze nie istnieje.");
                return;
            }

            Console.Write("Rodzaj uprawy: ");
            string? cropType = Console.ReadLine();
            Console.Write("Data siewu (RRRR-MM-DD): ");
            if (!DateTime.TryParse(Console.ReadLine(), out DateTime sowingDate))
            {
                Console.WriteLine("Niepoprawny format daty.");
                return;
            }

            double areaInHectares;
            while (true)
            {
                Console.Write("Obszar w hektarach (ha): ");
                if (!double.TryParse(Console.ReadLine(), out areaInHectares))
                {
                    Console.WriteLine("Niepoprawny format obszaru.");
                    continue;
                }

                if (areaInHectares > field.AreaInHectares)
                {
                    Console.WriteLine($"Pole jest mniejsze niż podana wartość. Dostępna powierzchnia pola: {field.AreaInHectares} ha.");
                }
                else
                {
                    break;
                }
            }

            Crop newCrop = new Crop
            {
                FieldNumber = fieldNumber,
                CropType = cropType,
                SowingDate = sowingDate,
                AreaInHectares = areaInHectares
            };
            field.Crops.Add(newCrop);

            Console.WriteLine("Nowa uprawa została dodana pomyślnie.");
        }

        public void DisplayCropsInfo(Farm farm)
        {
            Console.WriteLine("Informacje o uprawach na polach:");
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