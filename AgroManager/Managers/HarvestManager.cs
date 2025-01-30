using AgroManager.Models;
using AgroManager.Services;
using System;

namespace AgroManager.Managers
{
    public class HarvestManager
    {
        private readonly HarvestService _harvestService;

        public HarvestManager(HarvestService harvestService)
        {
            _harvestService = harvestService;
        }

        public void AddHarvest(Farm farm)
        {
            Console.WriteLine("===== Dodaj nowy zbiór =====");

            // Pobranie numeru pola i walidacja
            string? fieldNumber;
            Field? field;
            do
            {
                Console.Write("Podaj numer pola: ");
                fieldNumber = Console.ReadLine()?.Trim();

                field = farm.FieldsList.Find(f => f.FieldNumber == fieldNumber);
                if (field == null)
                {
                    Console.WriteLine($"Pole o numerze {fieldNumber} nie istnieje w gospodarstwie. Spróbuj ponownie.");
                }

            } while (field == null);

            // Pobranie daty zbioru
            DateTime harvestDate;
            while (true)
            {
                Console.Write("Data zbioru (RRRR-MM-DD): ");
                if (DateTime.TryParse(Console.ReadLine(), out harvestDate))
                {
                    break;
                }
                Console.WriteLine("Niepoprawny format daty. Spróbuj ponownie.");
            }

            // Pobranie ilości zbioru w tonach
            double quantityInTons;
            while (true)
            {
                Console.Write("Ilość zbioru w tonach: ");
                if (double.TryParse(Console.ReadLine(), out quantityInTons) && quantityInTons > 0)
                {
                    break;
                }
                Console.WriteLine("Niepoprawna ilość zbioru. Podaj wartość większą niż 0.");
            }

            // Pobranie wilgotności zbioru
            double moisture;
            while (true)
            {
                Console.Write("Wilgotność zbioru (%): ");
                if (double.TryParse(Console.ReadLine(), out moisture) && moisture >= 0 && moisture <= 100)
                {
                    break;
                }
                Console.WriteLine("Niepoprawna wartość wilgotności. Podaj liczbę od 0 do 100.");
            }

            // Pobranie jakości zbioru
            string? quality;
            do
            {
                Console.Write("Jakość zbioru: ");
                quality = Console.ReadLine()?.Trim();
                if (string.IsNullOrWhiteSpace(quality))
                {
                    Console.WriteLine("Jakość zbioru nie może być pusta.");
                }
            } while (string.IsNullOrWhiteSpace(quality));

            try
            {
                _harvestService.AddHarvest(farm, fieldNumber!, harvestDate, quantityInTons, moisture, quality);
                Console.WriteLine($"Nowy zbiór został dodany pomyślnie dla pola {fieldNumber}. Pole gotowe na nową uprawę.");
            }
            catch (ArgumentException e)
            {
                Console.WriteLine($"Błąd: {e.Message}");
            }
        }

        public void DisplayHarvestsInfo(Farm farm)
        {
            Console.WriteLine("===== Informacje o zbiorach z pól =====");
            _harvestService.DisplayHarvestsInfo(farm);
        }
    }
}
