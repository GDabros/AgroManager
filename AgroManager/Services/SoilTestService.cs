using AgroManager.Models;
using System;

namespace AgroManager.Services
{
    public class SoilTestService
    {
        public void AddSoilTest(Farm farm, string fieldNumber, DateTime testDate, double phLevel, double nitrogen, double phosphorus, double potassium, string? additionalNotes)
        {
            Field? field = farm.FieldsList.Find(f => f.FieldNumber == fieldNumber);
            if (field == null)
            {
                throw new ArgumentException("Pole o podanym numerze nie istnieje.");
            }

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
        }

        public void DisplaySoilTests(Farm farm)
        {
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