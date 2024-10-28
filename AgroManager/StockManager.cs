using System;

namespace AgroManager
{
    public class StockManager
    {
        private readonly StockService _stockService;

        public StockManager(StockService stockService)
        {
            _stockService = stockService;
        }

        public void DisplayHarvestStock(Farm farm)
        {
            Console.WriteLine("Stan magazynowy zbiorów:");
            List<Stock> stockList = _stockService.GetHarvestStock(farm);

            if (stockList.Count == 0)
            {
                Console.WriteLine("Brak zbiorów w magazynie.");
            }
            else
            {
                foreach (var stock in stockList)
                {
                    Console.WriteLine($"Rodzaj uprawy: {stock.CropType}, Suma zbiorów (tony): {stock.QuantityInTons}");
                }
            }
        }
    }
}