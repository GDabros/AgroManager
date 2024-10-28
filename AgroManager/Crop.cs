using System;

namespace AgroManager;

public class Crop
{
    public string? FieldNumber { get; set; }
    public string? CropType { get; set; }
    public DateTime SowingDate { get; set; }
    public double AreaInHectares { get; set; }
}