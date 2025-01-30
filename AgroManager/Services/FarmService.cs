using AgroManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AgroManager.Services
{
    public class FarmService
    {
        private readonly List<Farm> _farms = new(); // Lista przechowująca gospodarstwa

        public void AddFarm(string farmName, string location)
        {
            int newId = _farms.Count + 1; // Generowanie unikalnego ID gospodarstwa
            Farm newFarm = new Farm(newId, farmName, location); // Teraz przekazujemy ID
            _farms.Add(newFarm);
        }

        public Farm? GetFarmById(int id)
        {
            return _farms.FirstOrDefault(f => f.Id == id);
        }

        public List<Farm> GetAllFarms()
        {
            return _farms;
        }

        public void EditFarmName(int id, string newFarmName)
        {
            var farm = GetFarmById(id);
            if (farm != null)
            {
                farm.FarmName = newFarmName;
            }
        }

        public void EditFarmLocation(int id, string newLocation)
        {
            var farm = GetFarmById(id);
            if (farm != null)
            {
                farm.Location = newLocation;
            }
        }
    }
}
