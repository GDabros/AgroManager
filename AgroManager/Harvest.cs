﻿using System;

namespace AgroManager
{
    public class Harvest
    {
        public string? FieldNumber { get; set; }
        public DateTime HarvestDate { get; set; }
        public double QuantityInTons { get; set; }
        public double Moisture { get; set; }
        public string? Quality { get; set; }
        public string? CropType { get; set; }
    }
}