using System;
using System.Collections.Generic;

namespace CubeGPS.Repository.Models
{
    public partial class ShapeType
    {
        public ShapeType()
        {
            Shape = new HashSet<Shape>();
        }

        public int Id { get; set; }
        public string Type { get; set; }

        public virtual ICollection<Shape> Shape { get; set; }
    }
}
