using CubeGPS.Infrastructure.Models;
using CubeGPS.Repository.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace CubeGPS.Business
{
    public class ObjectMapper
    {
        public static Circle ToCircle(CircleArea circleArea)
        {
            var circle = new Circle();

            circle.Longitude = circleArea.CenterCoordinate.Longitude;
            circle.Latitude = circleArea.CenterCoordinate.Latitude;
            circle.Radius = circleArea.Radius;

            return circle;
        }

        public static Rectangle ToRectangle(RectangleArea rectangleArea)
        {
            var rectangle = new Rectangle();

            rectangle.Longitude1 = rectangleArea.Coordinate1.Longitude;
            rectangle.Latitude1 = rectangleArea.Coordinate1.Latitude;
            rectangle.Longitude2 = rectangleArea.Coordinate2.Longitude;
            rectangle.Latitude2 = rectangleArea.Coordinate2.Latitude;

            return rectangle;
        }

        public static IEnumerable<IrregularShape> ToIrregularShape(IrregularShapeArea irregularShapeArea)
        {
            var irregularShape = irregularShapeArea.Coordinates.Select(coordinate => 
                new IrregularShape() 
                { 
                    Longitude = coordinate.Longitude,
                    Latitude = coordinate.Latitude
                });

            return irregularShape;
        }

        public static IEnumerable<AreaType> ToAreaType(IEnumerable<ShapeType> shapeTypes)
        {
            var areaTypes = shapeTypes.Select(shapeType =>
                new AreaType()
                {
                    Id = shapeType.Id,
                    Type = shapeType.Type
                });

            return areaTypes;
        }

        public static Shape ToShape(CircleArea circle)
        {
            var shape = new Shape() 
            { 
                TypeId = circle.TypeId,
                Name = circle.Name
            };

            return shape;
        }

        public static Shape ToShape(RectangleArea rectangle)
        {
            var shape = new Shape()
            {
                TypeId = rectangle.TypeId,
                Name = rectangle.Name
            };

            return shape;
        }

        public static Shape ToShape(IrregularShapeArea irregularShape)
        {
            var shape = new Shape()
            {
                TypeId = irregularShape.TypeId,
                Name = irregularShape.Name
            };

            return shape;
        }
    }
}
