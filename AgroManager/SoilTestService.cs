using System;
using System.Linq;

namespace AgroManager
{
    public class SoilTestService
    {
        public void AddSoilTest(Farm farm)
        {
            Console.WriteLine("Dodaj nowe badanie gleby:");
            Console.Write("Numer pola: ");
            string? fieldNumber = Console.ReadLine();
            Field? field = farm.FieldsList.Find(f => f.FieldNumber == fieldNumber);

            if (field == null)
            {
                Console.WriteLine("Pole o podanym numerze nie istnieje.");
                return;
            }

            Console.Write("Data badania (RRRR-MM-DD): ");
            if (!DateTime.TryParse(Console.ReadLine(), out DateTime testDate))
            {
                Console.WriteLine("Niepoprawny format daty. Spróbuj ponownie.");
                return;
            }

            Console.Write("Poziom pH: ");
            if (!double.TryParse(Console.ReadLine(), out double phLevel))
            {
                Console.WriteLine("Niepoprawny format poziomu pH. Spróbuj ponownie.");
                return;
            }

            Console.Write("Azot (N) w mg/kg: ");
            if (!double.TryParse(Console.ReadLine(), out double nitrogen))
            {
                Console.WriteLine("Niepoprawny format zawartości azotu. Spróbuj ponownie.");
                return;
            }

            Console.Write("Fosfor (P) w mg/kg: ");
            if (!double.TryParse(Console.ReadLine(), out double phosphorus))
            {
                Console.WriteLine("Niepoprawny format zawartości fosforu. Spróbuj ponownie.");
                return;
            }

            Console.Write("Potas (K) w mg/kg: ");
            if (!double.TryParse(Console.ReadLine(), out double potassium))
            {
                Console.WriteLine("Niepoprawny format zawartości potasu. Spróbuj ponownie.");
                return;
            }

            Console.Write("Dodatkowe uwagi: ");
            string? additionalNotes = Console.ReadLine();

            SoilTest newSoilTest = new SoilTest
            {
                TestDate = testDate,
                PhLevel = phLevel,
                Nitrogen = nitrogen,
                Phosphorus = phosphorus,
                Potassium = potassium,
                AdditionalNotes = additionalNotes
            };
            field.SoilTests.Add(newSoilTest);

            Console.WriteLine("Nowe badanie gleby zostało dodane pomyślnie.");
        }

        public void DisplaySoilTests(Farm farm)
        {
            Console.WriteLine("Wyświetl badania gleby:");
            foreach (var field in farm.FieldsList)
            {
                Console.WriteLine($"Pole: {field.FieldNumber}");
                if (field.SoilTests.Any())
                {
                    Console.WriteLine("Badania gleby:");
                    foreach (var test in field.SoilTests)
                    {
                        Console.WriteLine($"- Data badania: {test.TestDate:yyyy-MM-dd}, pH: {test.PhLevel}, Azot: {test.Nitrogen}, Fosfor: {test.Phosphorus}, Potas: {test.Potassium}, Uwagi: {test.AdditionalNotes}");
                    }
                }
                else
                {
                    Console.WriteLine("Brak badań gleby dla tego pola.");
                }
            }
        }
    }
}