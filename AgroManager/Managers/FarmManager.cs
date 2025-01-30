using AgroManager.Models;
using AgroManager.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AgroManager.Managers
{
    public class FarmManager
    {
        private readonly FarmService _farmService;

        public FarmManager(FarmService farmService)
        {
            _farmService = farmService;
        }

        public void CreateFarm()
        {
            Console.WriteLine("===== Utwórz nowe gospodarstwo: =====");

            Console.Write("Nazwa gospodarstwa: ");
            string? farmName = Console.ReadLine()?.Trim();
            while (string.IsNullOrWhiteSpace(farmName))
            {
                Console.WriteLine("Nazwa gospodarstwa nie może być pusta. Spróbuj ponownie.");
                farmName = Console.ReadLine()?.Trim();
            }

            Console.Write("Lokalizacja: ");
            string? location = Console.ReadLine()?.Trim();
            while (string.IsNullOrWhiteSpace(location))
            {
                Console.WriteLine("Lokalizacja gospodarstwa nie może być pusta. Spróbuj ponownie.");
                location = Console.ReadLine()?.Trim();
            }

            _farmService.AddFarm(farmName, location);
            Console.WriteLine("Gospodarstwo zostało pomyślnie utworzone.");
        }

        public void DisplayAllFarms()
        {
            List<Farm> farms = _farmService.GetAllFarms();

            if (farms.Count == 0)
            {
                Console.WriteLine("Brak gospodarstw w systemie.");
                return;
            }

            Console.WriteLine("\nLista gospodarstw:");
            foreach (var farm in farms)
            {
                Console.WriteLine($"[{farm.Id}] {farm.FarmName} - {farm.Location}");
            }
        }

        public void DisplayFarmInfo()
        {
            Farm? farm = SelectFarm();
            if (farm == null) return;

            Console.WriteLine("\nInformacje o gospodarstwie:");
            Console.WriteLine($"Nazwa: {farm.FarmName}");
            Console.WriteLine($"Lokalizacja: {farm.Location}");
            Console.WriteLine($"Liczba pól: {farm.FieldsList.Count}");
            Console.WriteLine($"Łączna powierzchnia: {farm.FieldsList.Sum(field => field.AreaInHectares)} ha");
        }

        public void EditFarmDetails()
        {
            Farm? farm = SelectFarm();
            if (farm == null) return;

            Console.WriteLine("\nEdytuj dane gospodarstwa:");
            Console.WriteLine("1. Zmień nazwę gospodarstwa");
            Console.WriteLine("2. Zmień lokalizację");
            Console.WriteLine("3. Powrót do menu głównego");
            Console.Write("Wybierz opcję: ");

            if (int.TryParse(Console.ReadLine(), out int editChoice))
            {
                switch (editChoice)
                {
                    case 1:
                        Console.Write("Nowa nazwa gospodarstwa: ");
                        string? newFarmName = Console.ReadLine()?.Trim();
                        if (!string.IsNullOrWhiteSpace(newFarmName))
                        {
                            _farmService.EditFarmName(farm.Id, newFarmName);
                            Console.WriteLine("Nazwa gospodarstwa została zaktualizowana.");
                        }
                        else
                        {
                            Console.WriteLine("Nazwa gospodarstwa nie może być pusta.");
                        }
                        break;
                    case 2:
                        Console.Write("Nowa lokalizacja: ");
                        string? newLocation = Console.ReadLine()?.Trim();
                        if (!string.IsNullOrWhiteSpace(newLocation))
                        {
                            _farmService.EditFarmLocation(farm.Id, newLocation);
                            Console.WriteLine("Lokalizacja gospodarstwa została zaktualizowana.");
                        }
                        else
                        {
                            Console.WriteLine("Lokalizacja gospodarstwa nie może być pusta.");
                        }
                        break;
                    case 3:
                        Console.WriteLine("Powrót do menu głównego.");
                        break;
                    default:
                        Console.WriteLine("Niepoprawny wybór. Spróbuj ponownie.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Niepoprawny wybór. Spróbuj ponownie.");
            }
        }

        public Farm? SelectFarm()
        {
            List<Farm> farms = _farmService.GetAllFarms();

            if (farms.Count == 0)
            {
                Console.WriteLine("Brak gospodarstw w systemie.");
                return null;
            }

            Console.WriteLine("\nWybierz gospodarstwo:");
            foreach (var farm in farms)
            {
                Console.WriteLine($"[{farm.Id}] {farm.FarmName} - {farm.Location}");
            }

            Console.Write("\nPodaj ID gospodarstwa: ");
            if (int.TryParse(Console.ReadLine(), out int farmId))
            {
                Farm? selectedFarm = _farmService.GetFarmById(farmId);
                if (selectedFarm != null)
                {
                    return selectedFarm;
                }
                else
                {
                    Console.WriteLine("Nie znaleziono gospodarstwa o podanym ID.");
                }
            }
            else
            {
                Console.WriteLine("Niepoprawne ID. Spróbuj ponownie.");
            }

            return null;
        }
    }
}
