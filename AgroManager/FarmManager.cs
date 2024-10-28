using System;

namespace AgroManager
{
    public class FarmManager
    {
        private readonly FarmService _farmService;

        public FarmManager(FarmService farmService)
        {
            _farmService = farmService;
        }

        public void CreateFarm(Farm farm)
        {
            Console.WriteLine("===== Utwórz nowe gospodarstwo: =====");

            Console.Write("Nazwa gospodarstwa: ");
            string? farmName = Console.ReadLine() ?? string.Empty;
            while (string.IsNullOrWhiteSpace(farmName))
            {
                Console.WriteLine("Nazwa gospodarstwa nie może być pusta. Spróbuj ponownie.");
                farmName = Console.ReadLine() ?? string.Empty;
            }

            Console.Write("Lokalizacja: ");
            string? location = Console.ReadLine() ?? string.Empty;
            while (string.IsNullOrWhiteSpace(location))
            {
                Console.WriteLine("Lokalizacja gospodarstwa nie może być pusta. Spróbuj ponownie.");
                location = Console.ReadLine() ?? string.Empty;
            }

            _farmService.CreateFarm(farm, farmName, location);
            Console.WriteLine("Gospodarstwo zostało pomyślnie utworzone.");
        }

        public void DisplayFarmInfo(Farm farm)
        {
            Console.WriteLine("Informacje o gospodarstwie:");
            _farmService.DisplayFarmInfo(farm);
        }

        public void EditFarmDetails(Farm farm)
        {
            Console.WriteLine("Edytuj dane gospodarstwa:");
            Console.WriteLine("1. Edytuj nazwę gospodarstwa");
            Console.WriteLine("2. Edytuj lokalizację");
            Console.WriteLine("3. Powrót do menu głównego");
            Console.Write("Wybierz opcję: ");

            if (int.TryParse(Console.ReadLine(), out int editChoice))
            {
                switch (editChoice)
                {
                    case 1:
                        Console.Write("Nowa nazwa gospodarstwa: ");
                        string? newFarmName = Console.ReadLine();
                        if (!string.IsNullOrWhiteSpace(newFarmName))
                        {
                            _farmService.EditFarmName(farm, newFarmName);
                            Console.WriteLine("Nazwa gospodarstwa została zaktualizowana.");
                        }
                        else
                        {
                            Console.WriteLine("Nazwa gospodarstwa nie może być pusta.");
                        }
                        break;
                    case 2:
                        Console.Write("Nowa lokalizacja: ");
                        string? newLocation = Console.ReadLine();
                        if (!string.IsNullOrWhiteSpace(newLocation))
                        {
                            _farmService.EditFarmLocation(farm, newLocation);
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
    }
}