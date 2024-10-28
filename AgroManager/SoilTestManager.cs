using System;

namespace AgroManager
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
            Console.WriteLine("Dodaj nowe badanie gleby:");
            Console.Write("Numer pola: ");
            string? fieldNumber = Console.ReadLine();

            Console.Write("Data badania (RRRR-MM-DD): ");
            if (!DateTime.TryParse(Console.ReadLine(), out DateTime testDate))
            {
                Console.WriteLine("Niepoprawny format daty. Spróbuj ponownie.");
                return;
            }

            Console.Write("Poziom pH: ");
            if (!double.TryParse(Console.ReadLine(), System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out double phLevel))
            {
                Console.WriteLine("Niepoprawny format poziomu pH.");
                return;
            }

            Console.Write("Azot (N) w mg/kg: ");
            if (!double.TryParse(Console.ReadLine(), out double nitrogen))
            {
                Console.WriteLine("Niepoprawny format zawartości azotu.");
                return;
            }

            Console.Write("Fosfor (P) w mg/kg: ");
            if (!double.TryParse(Console.ReadLine(), out double phosphorus))
            {
                Console.WriteLine("Niepoprawny format zawartości fosforu.");
                return;
            }

            Console.Write("Potas (K) w mg/kg: ");
            if (!double.TryParse(Console.ReadLine(), out double potassium))
            {
                Console.WriteLine("Niepoprawny format zawartości potasu.");
                return;
            }

            Console.Write("Dodatkowe uwagi: ");
            string? additionalNotes = Console.ReadLine();

            try
            {
                _soilTestService.AddSoilTest(farm, fieldNumber, testDate, phLevel, nitrogen, phosphorus, potassium, additionalNotes);
                Console.WriteLine("Nowe badanie gleby zostało dodane pomyślnie.");
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void DisplaySoilTests(Farm farm)
        {
            Console.WriteLine("Wyświetl badania gleby:");
            _soilTestService.DisplaySoilTests(farm);
        }
    }
}