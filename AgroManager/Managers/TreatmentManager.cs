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
            Console.WriteLine("Dodaj nowy zabieg:");
            Console.Write("Numer pola: ");
            string? fieldNumber = Console.ReadLine();

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

            try
            {
                _treatmentService.AddTreatment(farm, fieldNumber, treatmentDate, treatmentType, details);
                Console.WriteLine("Nowy zabieg został dodany pomyślnie.");
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void DisplayTreatmentsInfo(Farm farm)
        {
            Console.WriteLine("Informacje o zabiegach na polach:");
            _treatmentService.DisplayTreatmentsInfo(farm);
        }
    }
}