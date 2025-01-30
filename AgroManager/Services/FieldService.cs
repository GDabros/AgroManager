using AgroManager.Models;
using System;

namespace AgroManager.Services
{
    public class FieldService
    {
        public bool AddField(Farm farm, string fieldNumber, double areaInHectares)
        {
            if (farm.FieldsList.Any(field => field.FieldNumber == fieldNumber))
            {
                return false;
            }

            Field newField = new Field
            {
                FieldNumber = fieldNumber,
                AreaInHectares = areaInHectares
            };
            farm.FieldsList.Add(newField);
            return true;
        }

        public bool EditField(Farm farm, string? fieldNumber, string? newFieldNumber, double? newAreaInHectares)
        {
            Field? field = farm.FieldsList.Find(f => f.FieldNumber == fieldNumber);
            if (field == null) return false;

            if (!string.IsNullOrWhiteSpace(newFieldNumber))
            {
                field.FieldNumber = newFieldNumber;
            }

            if (newAreaInHectares.HasValue)
            {
                field.AreaInHectares = newAreaInHectares.Value;
            }

            return true;
        }

        public bool RemoveField(Farm farm, string? fieldNumber)
        {
            Field? field = farm.FieldsList.Find(f => f.FieldNumber == fieldNumber);
            if (field == null) return false;

            farm.FieldsList.Remove(field);
            return true;
        }
    }
}