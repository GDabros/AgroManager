using System;

namespace AgroManager.Models
{
    public class SoilTest
    {
        public string FieldNumber { get; set; }
        public DateTime TestDate { get; set; }
        public double PhLevel { get; set; }
        public double Nitrogen { get; set; }
        public double Phosphorus { get; set; }
        public double Potassium { get; set; }
        public string? AdditionalNotes { get; set; }
    }
}