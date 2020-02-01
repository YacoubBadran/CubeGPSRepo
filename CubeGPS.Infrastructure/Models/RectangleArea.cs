using System;
using System.Collections.Generic;

namespace CubeGPS.Infrastructure.Models
{
    public partial class RectangleArea
    {
        public string Name { get; set; }
        public int TypeId { get; set; }
        public Coordinate Coordinate1 { get; set; }
        public Coordinate Coordinate2 { get; set; }
    }
}
