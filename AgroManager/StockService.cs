using System;
using System.Collections.Generic;

namespace AgroManager
{
    public class StockService
    {
        public void DisplayHarvestStock(Farm farm)
        {
            if (farm == null)
            {
                Console.WriteLine("Gospodarstwo nie może być puste.");
                return;
            }

            if (farm.FieldsList == null)
            {
                Console.WriteLine("Lista pól nie może być pusta.");
                return;
            }

            Console.WriteLine("Stan magazynowy zbiorów:");
            Dictionary<string, double> harvestStock = new Dictionary<string, double>();

            foreach (var field in farm.FieldsList)
            {
                if (field?.Harvests == null) continue;

                foreach (var harvest in field.Harvests)
                {
                    if (harvest == null || string.IsNullOrEmpty(harvest.CropType)) continue;

                    if (harvestStock.TryGetValue(harvest.CropType, out double currentQuantity))
                    {
                        harvestStock[harvest.CropType] = currentQuantity + harvest.QuantityInTons;
                    }
                    else
                    {
                        harvestStock.Add(harvest.CropType, harvest.QuantityInTons);
                    }
                }
            }

            if (harvestStock.Count == 0)
            {
                Console.WriteLine("Brak zbiorów w magazynie.");
            }
            else
            {
                foreach (var crop in harvestStock)
                {
                    Console.WriteLine($"Rodzaj uprawy: {crop.Key}, Suma zbiorów (tony): {crop.Value}");
                }
            }
        }

        public List<Stock> GetHarvestStock(Farm farm)
        {
            List<Stock> stockList = new List<Stock>();

            if (farm?.FieldsList != null)
            {
                Dictionary<string, double> harvestStock = new Dictionary<string, double>();

                foreach (var field in farm.FieldsList)
                {
                    if (field?.Harvests == null) continue;

                    foreach (var harvest in field.Harvests)
                    {
                        if (harvest == null || string.IsNullOrEmpty(harvest.CropType)) continue;

                        if (harvestStock.TryGetValue(harvest.CropType, out double currentQuantity))
                        {
                            harvestStock[harvest.CropType] = currentQuantity + harvest.QuantityInTons;
                        }
                        else
                        {
                            harvestStock.Add(harvest.CropType, harvest.QuantityInTons);
                        }
                    }
                }

                foreach (var crop in harvestStock)
                {
                    stockList.Add(new Stock { CropType = crop.Key, QuantityInTons = crop.Value });
                }
            }

            return stockList;
        }
    }
}