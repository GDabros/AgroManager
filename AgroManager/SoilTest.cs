using System;

namespace AgroManager
{
    public class SoilTest
    {
        public DateTime TestDate { get; set; }
        public double PhLevel { get; set; }
        public double Nitrogen { get; set; }
        public double Phosphorus { get; set; }
        public double Potassium { get; set; }
        public string? AdditionalNotes { get; set; }
    }
}