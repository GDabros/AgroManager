using AgroManager.Models;
using AgroManager.Services;
using System;

namespace AgroManager.Managers
{
    public class TreatmentManager
    {
        private readonly TreatmentService _treatmentService;

        public TreatmentManager(TreatmentService treatmentService)
        {
            _treatmentService = treatmentService;
        }

        public void AddTreatment(Farm farm)
        {
            Console.WriteLine("===== Dodaj nowy zabieg =====");
 
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

            DateTime treatmentDate;
            while (true)
            {
                Console.Write("Data zabiegu (RRRR-MM-DD): ");
                if (DateTime.TryParse(Console.ReadLine(), out treatmentDate))
                {
                    break;
                }
                Console.WriteLine("Niepoprawny format daty. Spróbuj ponownie.");
            }

            string? treatmentType;
            do
            {
                Console.Write("Typ zabiegu: ");
                treatmentType = Console.ReadLine()?.Trim();
                if (string.IsNullOrWhiteSpace(treatmentType))
                {
                    Console.WriteLine("Typ zabiegu nie może być pusty.");
                }
            } while (string.IsNullOrWhiteSpace(treatmentType));

            string? details;
            do
            {
                Console.Write("Szczegóły zabiegu: ");
                details = Console.ReadLine()?.Trim();
                if (string.IsNullOrWhiteSpace(details))
                {
                    Console.WriteLine("Szczegóły zabiegu nie mogą być puste.");
                }
            } while (string.IsNullOrWhiteSpace(details));

            try
            {
                _treatmentService.AddTreatment(farm, fieldNumber!, treatmentDate, treatmentType, details);
                Console.WriteLine($"Nowy zabieg ({treatmentType}) został dodany pomyślnie dla pola {fieldNumber}.");
            }
            catch (ArgumentException e)
            {
                Console.WriteLine($"Błąd: {e.Message}");
            }
        }
        public void DisplayTreatmentsInfo(Farm farm)
        {
            Console.WriteLine("===== Informacje o zabiegach na polach =====");
            _treatmentService.DisplayTreatmentsInfo(farm);
        }
    }
}
