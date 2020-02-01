using CubeGPS.Infrastructure.Models;
using CubeGPS.Repository.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CubeGPS.Repository.DataAccess
{
    public interface IGPSRepository
    {
        Circle InsertCirlce(Circle circle);
        Rectangle InsertRectangle(Rectangle rectangle);
        IEnumerable<IrregularShape> InsertIrregularShape(IEnumerable<IrregularShape> irregularShape);
        Shape InsertShape(Shape shape);
        IEnumerable<ShapeType> GetShapeTypes();
    }
}
