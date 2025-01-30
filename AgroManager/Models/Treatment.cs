using System;

namespace AgroManager.Models
{
    public class Treatment
    {
        public string? FieldNumber { get; set; }
        public string? TreatmentType { get; set; }
        public DateTime TreatmentDate { get; set; }
        public string? Details { get; set; }
    }
}