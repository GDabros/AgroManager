using AgroManager.Managers;
using AgroManager.Models;
using AgroManager.Services;
using System;
using System.Collections.Generic;

namespace AgroManager
{
    class Program
    {
        static void Main(string[] args)
        {
            const string version = "0.1.25";
            Console.WriteLine("Witaj w aplikacji AgroManager!");
            Console.WriteLine($"Wersja: {version}\n");

            // Inicjalizacja serwisów
            FarmService farmService = new FarmService();
            FieldService fieldService = new FieldService();
            CropService cropService = new CropService();
            HarvestService harvestService = new HarvestService();
            TreatmentService treatmentService = new TreatmentService();
            StockService stockService = new StockService();
            SoilTestService soilTestService = new SoilTestService();

            // Inicjalizacja menedżerów
            FarmManager farmManager = new FarmManager(farmService);
            FieldManager fieldManager = new FieldManager(fieldService);
            CropManager cropManager = new CropManager(cropService);
            HarvestManager harvestManager = new HarvestManager(harvestService);
            TreatmentManager treatmentManager = new TreatmentManager(treatmentService);
            StockManager stockManager = new StockManager(stockService);
            SoilTestManager soilTestManager = new SoilTestManager(soilTestService);

            // Tworzenie lub wybór gospodarstwa
            int selectedFarmId = SelectOrCreateFarm(farmManager);
            if (selectedFarmId == -1)
            {
                Console.WriteLine("Zamykanie programu...");
                return;
            }

            int choice;
            do
            {
                DisplayMenu();

                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Niepoprawny wybór. Spróbuj ponownie.");
                    choice = 0;
                    continue;
                }

                // Pobranie obiektu Farm przed przekazaniem go do Managera
                Farm? selectedFarm = farmService.GetFarmById(selectedFarmId);
                if (selectedFarm == null)
                {
                    Console.WriteLine("Nie znaleziono gospodarstwa. Wybierz inne lub utwórz nowe.");
                    selectedFarmId = SelectOrCreateFarm(farmManager);
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        farmManager.DisplayFarmInfo();
                        break;
                    case 2:
                        fieldManager.AddField(selectedFarm);
                        break;
                    case 3:
                        fieldManager.DisplayFieldsMenu(selectedFarm);
                        break;
                    case 4:
                        cropManager.AddCrop(selectedFarm);
                        break;
                    case 5:
                        harvestManager.AddHarvest(selectedFarm);
                        break;
                    case 6:
                        treatmentManager.AddTreatment(selectedFarm);
                        break;
                    case 7:
                        stockManager.DisplayHarvestStock(selectedFarm);
                        break;
                    case 8:
                        soilTestManager.AddSoilTest(selectedFarm);
                        break;
                    case 9:
                        soilTestManager.DisplaySoilTests(selectedFarm);
                        break;
                    case 10:
                        farmManager.EditFarmDetails();
                        break;
                    case 11:
                        Console.WriteLine("\nProgram 'AgroManager' został zamknięty.");
                        break;
                    default:
                        Console.WriteLine("Niepoprawny wybór. Spróbuj ponownie.\n");
                        break;
                }
            } while (choice != 11);


            static int SelectOrCreateFarm(FarmManager farmManager)
            {
                int farmId = -1;

                while (farmId == -1)
                {
                    Console.WriteLine("\n====== Wybór gospodarstwa ======");
                    farmManager.DisplayAllFarms();

                    Console.WriteLine("1. Wybierz gospodarstwo");
                    Console.WriteLine("2. Utwórz nowe gospodarstwo");
                    Console.WriteLine("3. Zakończ program");
                    Console.Write("\nWybierz opcję: ");

                    if (!int.TryParse(Console.ReadLine(), out int option))
                    {
                        Console.WriteLine("Niepoprawny wybór. Spróbuj ponownie.");
                        continue;
                    }

                    switch (option)
                    {
                        case 1:
                            farmId = farmManager.SelectFarm()?.Id ?? -1;
                            if (farmId == -1)
                            {
                                Console.WriteLine("Niepoprawne ID. Spróbuj ponownie.");
                            }
                            break;
                        case 2:
                            farmManager.CreateFarm();
                            farmId = farmManager.SelectFarm()?.Id ?? -1;
                            break;
                        case 3:
                            return -1;
                        default:
                            Console.WriteLine("Niepoprawny wybór. Spróbuj ponownie.");
                            break;
                    }
                }

                return farmId;
            }

            static void DisplayMenu()
            {
                Console.WriteLine("\n====== Menu główne ======");
                Console.WriteLine("1. Wyświetl informacje o gospodarstwie");
                Console.WriteLine("2. Dodaj pole");
                Console.WriteLine("3. Przegląd pól");
                Console.WriteLine("4. Dodaj nową uprawę");
                Console.WriteLine("5. Dodaj nowy zbiór");
                Console.WriteLine("6. Dodaj nowy zabieg");
                Console.WriteLine("7. Sprawdź stan magazynowy zbiorów");
                Console.WriteLine("8. Dodaj badanie gleby");
                Console.WriteLine("9. Wyświetl badania gleby");
                Console.WriteLine("10. Edytuj dane gospodarstwa");
                Console.WriteLine("11. Wyjście z programu");
                Console.Write("\nWybierz opcję: ");
            }
        }
    }
}

