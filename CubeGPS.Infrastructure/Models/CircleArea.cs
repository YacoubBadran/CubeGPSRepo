using System;
using System.Collections.Generic;

namespace CubeGPS.Infrastructure.Models
{
    public partial class CircleArea
    {
        public string Name { get; set; }
        public int TypeId { get; set; }
        public Coordinate CenterCoordinate { get; set; }
        public decimal Radius { get; set; }
    }
}
