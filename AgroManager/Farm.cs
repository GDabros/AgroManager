using System.Collections.Generic;
using System.Linq;

namespace AgroManager
{
    public class Farm
    {
        public string? FarmName { get; set; }
        public string? Location { get; set; }
        public List<Field> FieldsList { get; set; } = new List<Field>();
    }
}