using CubeGPS.Infrastructure.Models;
using CubeGPS.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CubeGPS.Business.Services
{
    public interface IGPSService
    {
        bool AddCircle(CircleArea circle);
        bool AddRectangle(RectangleArea circle);
        bool AddIrrigularShape(IrregularShapeArea circle);
        IEnumerable<AreaType> GetShapeTypes();
    }
}
