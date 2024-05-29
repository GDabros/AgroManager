using System;

namespace AgroManager
{
    class Program
    {
        static void Main(string[] args)
        {
            const string version = "0.5.24";
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

            farmService.CreateFarm(farm);

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
                        farmService.DisplayFarmInfo(farm);
                        break;
                    case 2:
                        fieldService.AddField(farm);
                        break;
                    case 3:
                        fieldService.DisplayFieldsMenu(farm);
                        break;
                    case 4:
                        cropService.AddCrop(farm);
                        break;
                    case 5:
                        harvestService.AddHarvest(farm);
                        break;
                    case 6:
                        treatmentService.AddTreatment(farm);
                        break;
                    case 7:
                        stockService.DisplayHarvestStock(farm);
                        break;
                    case 8:
                        soilTestService.AddSoilTest(farm);
                        break;
                    case 9:
                        soilTestService.DisplaySoilTests(farm);
                        break;
                    case 10:
                        farmService.EditFarmDetails(farm);
                        break;
                    case 11:
                        Console.WriteLine();
                        Console.WriteLine("Program 'Moje Gospodarswto' - został zamknięty!");
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