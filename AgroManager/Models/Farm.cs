using System.Collections.Generic;

namespace AgroManager.Models
{
    public class Farm
    {
        public int Id { get; set; }
        public string? FarmName { get; set; }
        public string? Location { get; set; }
        public List<Field> FieldsList { get; set; } = new List<Field>();
        public List<Stock> StockList { get; set; } = new List<Stock>();

        public Farm(int id, string farmName, string location)
        {
            Id = id;
            FarmName = farmName;
            Location = location;
        }
    }
}
