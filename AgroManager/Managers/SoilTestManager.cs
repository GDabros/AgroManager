using AgroManager.Models;
using AgroManager.Services;
using System;
using System.Globalization;

namespace AgroManager.Managers
{
    public class SoilTestManager
    {
        private readonly SoilTestService _soilTestService;

        public SoilTestManager(SoilTestService soilTestService)
        {
            _soilTestService = soilTestService;
        }

        public void AddSoilTest(Farm farm)
        {
            Console.WriteLine("===== Dodaj nowe badanie gleby =====");

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

            // Pobranie daty badania
            DateTime testDate;
            while (true)
            {
                Console.Write("Data badania (RRRR-MM-DD): ");
                if (DateTime.TryParse(Console.ReadLine(), out testDate))
                {
                    break;
                }
                Console.WriteLine("Niepoprawny format daty. Spróbuj ponownie.");
            }

            // Pobranie poziomu pH
            double phLevel;
            while (true)
            {
                Console.Write("Poziom pH: ");
                if (double.TryParse(Console.ReadLine(), NumberStyles.Any, CultureInfo.InvariantCulture, out phLevel) && phLevel >= 0 && phLevel <= 14)
                {
                    break;
                }
                Console.WriteLine("Niepoprawna wartość pH. Podaj liczbę od 0 do 14.");
            }

            // Pobranie azotu (N) w mg/kg
            double nitrogen;
            while (true)
            {
                Console.Write("Azot (N) w mg/kg: ");
                if (double.TryParse(Console.ReadLine(), out nitrogen) && nitrogen >= 0)
                {
                    break;
                }
                Console.WriteLine("Niepoprawna wartość azotu. Podaj wartość większą lub równą 0.");
            }

            // Pobranie fosforu (P) w mg/kg
            double phosphorus;
            while (true)
            {
                Console.Write("Fosfor (P) w mg/kg: ");
                if (double.TryParse(Console.ReadLine(), out phosphorus) && phosphorus >= 0)
                {
                    break;
                }
                Console.WriteLine("Niepoprawna wartość fosforu. Podaj wartość większą lub równą 0.");
            }

            // Pobranie potasu (K) w mg/kg
            double potassium;
            while (true)
            {
                Console.Write("Potas (K) w mg/kg: ");
                if (double.TryParse(Console.ReadLine(), out potassium) && potassium >= 0)
                {
                    break;
                }
                Console.WriteLine("Niepoprawna wartość potasu. Podaj wartość większą lub równą 0.");
            }

            // Pobranie dodatkowych uwag
            Console.Write("Dodatkowe uwagi (opcjonalnie): ");
            string? additionalNotes = Console.ReadLine()?.Trim();

            try
            {
                _soilTestService.AddSoilTest(farm, fieldNumber!, testDate, phLevel, nitrogen, phosphorus, potassium, additionalNotes);
                Console.WriteLine($"Nowe badanie gleby dla pola {fieldNumber} zostało dodane pomyślnie.");
            }
            catch (ArgumentException e)
            {
                Console.WriteLine($"Błąd: {e.Message}");
            }
        }

        public void DisplaySoilTests(Farm farm)
        {
            Console.WriteLine("===== Wyświetl badania gleby =====");
            _soilTestService.DisplaySoilTests(farm);
        }
    }
}
