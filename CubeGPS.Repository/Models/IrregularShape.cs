using System;
using System.Collections.Generic;

namespace CubeGPS.Repository.Models
{
    public partial class IrregularShape
    {
        public int Id { get; set; }
        public int ShapeId { get; set; }
        public decimal Longitude { get; set; }
        public decimal Latitude { get; set; }

        public virtual Shape Shape { get; set; }
    }
}
