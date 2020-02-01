using System;
using System.Collections.Generic;

namespace CubeGPS.Repository.Models
{
    public partial class Shape
    {
        public Shape()
        {
            Circle = new HashSet<Circle>();
            IrregularShape = new HashSet<IrregularShape>();
            Rectangle = new HashSet<Rectangle>();
        }

        public int Id { get; set; }
        public int TypeId { get; set; }
        public string Name { get; set; }

        public virtual ShapeType Type { get; set; }
        public virtual ICollection<Circle> Circle { get; set; }
        public virtual ICollection<IrregularShape> IrregularShape { get; set; }
        public virtual ICollection<Rectangle> Rectangle { get; set; }
    }
}
