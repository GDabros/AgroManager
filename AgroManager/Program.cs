using System;

namespace AgroManager
{
    class Program
    {
        static void Main(string[] args)
        {
            const string version = "0.10.24";
            Console.WriteLine("Witaj w aplikacji AgroManager!");
            Console.WriteLine($"Wersja: {version}");
            Console.WriteLine();

            Farm farm = new Farm();
            FarmService farmService = new FarmService();
            FieldService fieldService = new FieldService();
            CropService cropService = new CropService();
            HarvestService harvestService = new HarvestService();
            TreatmentService treatmentService = new TreatmentService();
            StockService stockService = new StockService();
            SoilTestService soilTestService = new SoilTestService();

            FarmManager farmManager = new FarmManager(farmService);
            FieldManager fieldManager = new FieldManager(fieldService);
            CropManager cropManager = new CropManager(cropService);
            HarvestManager harvestManager = new HarvestManager(harvestService);
            TreatmentManager treatmentManager = new TreatmentManager(treatmentService);
            StockManager stockManager = new StockManager(stockService);
            SoilTestManager soilTestManager = new SoilTestManager(soilTestService);

            farmManager.CreateFarm(farm);

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

                switch (choice)
                {
                    case 1:
                        farmManager.DisplayFarmInfo(farm);
                        break;
                    case 2:
                        fieldManager.AddField(farm);
                        break;
                    case 3:
                        fieldManager.DisplayFieldsMenu(farm);
                        break;
                    case 4:
                        cropManager.AddCrop(farm);
                        break;
                    case 5:
                        harvestManager.AddHarvest(farm);
                        break;
                    case 6:
                        treatmentManager.AddTreatment(farm);
                        break;
                    case 7:
                        stockManager.DisplayHarvestStock(farm);
                        break;
                    case 8:
                        soilTestManager.AddSoilTest(farm);
                        break;
                    case 9:
                        soilTestManager.DisplaySoilTests(farm);
                        break;
                    case 10:
                        farmManager.EditFarmDetails(farm);
                        break;
                    case 11:
                        Console.WriteLine();
                        Console.WriteLine("Program 'AgroManager' - został zamknięty!");
                        break;
                    default:
                        Console.WriteLine("Niepoprawny wybór. Spróbuj ponownie.");
                        Console.WriteLine();
                        break;
                }
            } while (choice != 11);
        }

        static void DisplayMenu()
        {
            Console.WriteLine("====== Menu główne ======");
            Console.WriteLine();
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
            Console.WriteLine();
            Console.Write("Wybierz opcję: ");
        }
    }
}