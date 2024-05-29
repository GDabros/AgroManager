using System;
using System.Linq;

namespace AgroManager
{
    public class TreatmentService
    {
        public void AddTreatment(Farm farm)
        {
            Console.WriteLine("Dodaj nowy zabieg:");
            Console.Write("Numer pola: ");
            string? fieldNumber = Console.ReadLine();
            Field? field = farm.FieldsList.Find(f => f.FieldNumber == fieldNumber);

            if (field == null)
            {
                Console.WriteLine("Pole o podanym numerze nie istnieje.");
                return;
            }

            Console.Write("Data zabiegu (RRRR-MM-DD): ");
            if (!DateTime.TryParse(Console.ReadLine(), out DateTime treatmentDate))
            {
                Console.WriteLine("Niepoprawny format daty.");
                return;
            }

            Console.Write("Typ zabiegu: ");
            string? treatmentType = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(treatmentType))
            {
                Console.WriteLine("Typ zabiegu nie może być pusty.");
                return;
            }

            Console.Write("Szczegóły zabiegu: ");
            string? details = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(details))
            {
                Console.WriteLine("Szczegóły zabiegu nie mogą być puste.");
                return;
            }

            Treatment newTreatment = new Treatment
            {
                FieldNumber = fieldNumber,
                TreatmentDate = treatmentDate,
                TreatmentType = treatmentType,
                Details = details
            };
            field.Treatments.Add(newTreatment);

            Console.WriteLine("Nowy zabieg został dodany pomyślnie.");
        }

        public void DisplayTreatmentsInfo(Farm farm)
        {
            Console.WriteLine("Informacje o zabiegach na polach:");
            foreach (var field in farm.FieldsList)
            {
                Console.WriteLine($"Pole: {field.FieldNumber}");
                if (field.Treatments.Any())
                {
                    Console.WriteLine("Zabiegi:");
                    foreach (var treatment in field.Treatments)
                    {
                        Console.WriteLine($"- Data zabiegu: {treatment.TreatmentDate:yyyy-MM-dd}, Typ: {treatment.TreatmentType}, Szczegóły: {treatment.Details}");
                    }
                }
                else
                {
                    Console.WriteLine("Brak zabiegów na tym polu.");
                }
            }
        }
    }
}