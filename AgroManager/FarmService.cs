using System;
using System.Linq;

namespace AgroManager
{
    public class FarmService
    {
        public void CreateFarm(Farm farm)
        {
            Console.WriteLine("===== Utwórz nowe gospodarstwo: =====");
            Console.WriteLine();

            Console.Write("Nazwa gospodarstwa: ");
            farm.FarmName = Console.ReadLine() ?? string.Empty;
            while (string.IsNullOrEmpty(farm.FarmName))
            {
                Console.WriteLine("Nazwa gospodarstwa nie może być pusta. Spróbuj ponownie.");
                farm.FarmName = Console.ReadLine() ?? string.Empty;
            }

            Console.Write("Lokalizacja: ");
            farm.Location = Console.ReadLine() ?? string.Empty;
            while (string.IsNullOrEmpty(farm.Location))
            {
                Console.WriteLine("Lokalizacja gospodarstwa nie może być pusta. Spróbuj ponownie.");
                farm.Location = Console.ReadLine() ?? string.Empty;
            }
            Console.WriteLine();
        }

        public void DisplayFarmInfo(Farm farm)
        {
            Console.WriteLine();
            Console.WriteLine($"Nazwa gospodarstwa: {farm.FarmName}");
            Console.WriteLine($"Lokalizacja: {farm.Location}");
            Console.WriteLine($"Liczba pól: {farm.FieldsList.Count}");
            Console.WriteLine($"Hektary łącznie: {farm.FieldsList.Sum(field => field.AreaInHectares)}");
            Console.WriteLine();
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
                        if (!string.IsNullOrEmpty(newFarmName))
                        {
                            farm.FarmName = newFarmName;
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
                        if (!string.IsNullOrEmpty(newLocation))
                        {
                            farm.Location = newLocation;
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