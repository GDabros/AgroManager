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
            Console.WriteLine("Dodaj nową uprawę:");
            Console.Write("Numer pola: ");
            string? fieldNumber = Console.ReadLine();

            Console.Write("Rodzaj uprawy: ");
            string? cropType = Console.ReadLine();

            Console.Write("Data siewu (RRRR-MM-DD): ");
            if (!DateTime.TryParse(Console.ReadLine(), out DateTime sowingDate))
            {
                Console.WriteLine("Niepoprawny format daty.");
                return;
            }

            double areaInHectares;
            while (true)
            {
                Console.Write("Obszar w hektarach (ha): ");
                if (!double.TryParse(Console.ReadLine(), out areaInHectares))
                {
                    Console.WriteLine("Niepoprawny format obszaru.");
                    continue;
                }

                if (_cropService.IsAreaValid(farm, fieldNumber, areaInHectares))
                {
                    _cropService.AddCrop(farm, fieldNumber, cropType, sowingDate, areaInHectares);
                    Console.WriteLine("Nowa uprawa została dodana pomyślnie.");
                    break;
                }
                else
                {
                    Console.WriteLine($"Pole jest mniejsze niż podana wartość.");
                }
            }
        }

        public void DisplayCropsInfo(Farm farm)
        {
            Console.WriteLine("Informacje o uprawach na polach:");
            _cropService.DisplayCropsInfo(farm);
        }
    }
}