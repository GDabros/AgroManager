using AgroManager.Models;
using AgroManager.Services;
using System;

namespace AgroManager.Managers
{
    public class CropManager
    {
        private readonly CropService _cropService;

        public CropManager(CropService cropService)
        {
            _cropService = cropService;
        }

        public void AddCrop(Farm farm)
        {
            Console.WriteLine("===== Dodaj nową uprawę =====");

            // Pobranie numeru pola
            Console.Write("Numer pola: ");
            string? fieldNumber = Console.ReadLine()?.Trim();

            // Sprawdzenie, czy pole istnieje w gospodarstwie
            Field? field = farm.FieldsList.Find(f => f.FieldNumber == fieldNumber);
            if (field == null)
            {
                Console.WriteLine($"Pole o numerze {fieldNumber} nie istnieje w gospodarstwie.");
                return;
            }

            // Pobranie rodzaju uprawy
            string? cropType;
            do
            {
                Console.Write("Rodzaj uprawy: ");
                cropType = Console.ReadLine()?.Trim();
                if (string.IsNullOrWhiteSpace(cropType))
                {
                    Console.WriteLine("Rodzaj uprawy nie może być pusty.");
                }
            } while (string.IsNullOrWhiteSpace(cropType));

            // Pobranie daty siewu
            DateTime sowingDate;
            while (true)
            {
                Console.Write("Data siewu (RRRR-MM-DD): ");
                if (DateTime.TryParse(Console.ReadLine(), out sowingDate))
                {
                    break;
                }
                Console.WriteLine("Niepoprawny format daty. Spróbuj ponownie.");
            }

            // Pobranie powierzchni uprawy
            double areaInHectares;
            while (true)
            {
                Console.Write("Obszar w hektarach (ha): ");
                if (!double.TryParse(Console.ReadLine(), out areaInHectares) || areaInHectares <= 0)
                {
                    Console.WriteLine("Niepoprawny format obszaru. Podaj wartość większą niż 0.");
                    continue;
                }

                if (areaInHectares > field.AreaInHectares)
                {
                    Console.WriteLine($"Podana powierzchnia ({areaInHectares} ha) przekracza dostępny obszar pola ({field.AreaInHectares} ha).");
                    continue;
                }

                break;
            }

            // Dodanie uprawy
            _cropService.AddCrop(farm, fieldNumber!, cropType, sowingDate, areaInHectares);
            Console.WriteLine($"Nowa uprawa ({cropType}) została dodana do pola {fieldNumber}.");
        }

        public void DisplayCropsInfo(Farm farm)
        {
            Console.WriteLine("===== Informacje o uprawach na polach =====");
            _cropService.DisplayCropsInfo(farm);
        }
    }
}
