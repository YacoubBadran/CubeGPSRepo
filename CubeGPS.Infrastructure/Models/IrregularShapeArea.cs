using CubeGPS.Infrastructure.Models;
using System;
using System.Collections.Generic;

namespace CubeGPS.Infrastructure.Models
{
    public partial class IrregularShapeArea
    {
        public string Name { get; set; }
        public int TypeId { get; set; }
        public List<Coordinate> Coordinates { get; set; }
    }
}
