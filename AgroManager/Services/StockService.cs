using AgroManager.Models;
using System;

namespace AgroManager.Services
{
    public class StockService
    {
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