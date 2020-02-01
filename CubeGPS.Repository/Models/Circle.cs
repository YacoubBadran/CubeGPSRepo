using System;
using System.Collections.Generic;

namespace CubeGPS.Repository.Models
{
    public partial class Circle
    {
        public int Id { get; set; }
        public int ShapeId { get; set; }
        public decimal Longitude { get; set; }
        public decimal Latitude { get; set; }
        public decimal Radius { get; set; }

        public virtual Shape Shape { get; set; }
    }
}
