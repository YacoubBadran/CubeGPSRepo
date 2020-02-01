using System;
using System.Collections.Generic;

namespace CubeGPS.Repository.Models
{
    public partial class Rectangle
    {
        public int Id { get; set; }
        public int ShapeId { get; set; }
        public decimal Longitude1 { get; set; }
        public decimal Latitude1 { get; set; }
        public decimal Longitude2 { get; set; }
        public decimal Latitude2 { get; set; }

        public virtual Shape Shape { get; set; }
    }
}
