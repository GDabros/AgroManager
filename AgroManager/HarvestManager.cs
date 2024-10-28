using System;

namespace AgroManager
{
    public class HarvestManager
    {
        private readonly HarvestService _harvestService;

        public HarvestManager(HarvestService harvestService)
        {
            _harvestService = harvestService;
        }

        public void AddHarvest(Farm farm)
        {
            Console.WriteLine("Dodaj nowy zbiór:");
            Console.Write("Numer pola: ");
            string? fieldNumber = Console.ReadLine();

            Console.Write("Data zbioru (RRRR-MM-DD): ");
            if (!DateTime.TryParse(Console.ReadLine(), out DateTime harvestDate))
            {
                Console.WriteLine("Niepoprawny format daty.");
                return;
            }

            Console.Write("Ilość zbioru w tonach: ");
            if (!double.TryParse(Console.ReadLine(), out double quantityInTons))
            {
                Console.WriteLine("Niepoprawny format ilości.");
                return;
            }

            Console.Write("Wilgotność zbioru (%): ");
            if (!double.TryParse(Console.ReadLine(), out double moisture))
            {
                Console.WriteLine("Niepoprawny format wilgotności.");
                return;
            }

            Console.Write("Jakość zbioru: ");
            string? quality = Console.ReadLine();

            try
            {
                _harvestService.AddHarvest(farm, fieldNumber, harvestDate, quantityInTons, moisture, quality);
                Console.WriteLine("Nowy zbiór został dodany pomyślnie. Pole gotowe na nową uprawę.");
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void DisplayHarvestsInfo(Farm farm)
        {
            Console.WriteLine("Informacje o zbiorach z pól:");
            _harvestService.DisplayHarvestsInfo(farm);
        }
    }
}