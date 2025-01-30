using AgroManager.Models;
using System;

namespace AgroManager.Services
{
    public class TreatmentService
    {
        public void AddTreatment(Farm farm, string fieldNumber, DateTime treatmentDate, string treatmentType, string details)
        {
            Field? field = farm.FieldsList.Find(f => f.FieldNumber == fieldNumber);
            if (field == null)
            {
                throw new ArgumentException("Pole o podanym numerze nie istnieje.");
            }

            Treatment newTreatment = new Treatment
            {
                FieldNumber = fieldNumber,
                TreatmentDate = treatmentDate,
                TreatmentType = treatmentType,
                Details = details
            };

            field.Treatments.Add(newTreatment);
        }

        public void DisplayTreatmentsInfo(Farm farm)
        {
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