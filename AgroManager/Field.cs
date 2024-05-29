using System.Collections.Generic;

namespace AgroManager
{
    public class Field
    {
        public string? FieldNumber { get; set; }
        public double AreaInHectares { get; set; }
        public List<Crop> Crops { get; set; } = new List<Crop>();
        public List<Harvest> Harvests { get; set; } = new List<Harvest>();
        public List<Treatment> Treatments { get; set; } = new List<Treatment>();
        public List<SoilTest> SoilTests { get; set; } = new List<SoilTest>();
    }
}