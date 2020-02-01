using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using Microsoft.Extensions.Options;
using System.Data.SqlClient;
using CubeGPS.Repository.Models;
using CubeGPS.Infrastructure.Models;
using CubeGPS.Repository;
using CubeGPS.Repository.DataAccess;
using Nancy.Json;

namespace CubeGPS.Business.Services.Implementation
{
    public class GPSService : IGPSService
    {
        private readonly IGPSRepository _repository;
        private readonly ILogger _logger;

        public GPSService(IGPSRepository repository, ILoggerFactory loggerFactory) 
        {
            _repository = repository;
            _logger = loggerFactory.CreateLogger(typeof(GPSService));
        }

        public bool AddCircle(CircleArea circleArea)
        {
            var circle = ObjectMapper.ToCircle(circleArea);
            var shape = ObjectMapper.ToShape(circleArea);

            var shapeResult = _repository.InsertShape(shape);
            circle.ShapeId = shapeResult.Id;
            var circleResult = _repository.InsertCirlce(circle);

            if(shapeResult == null || circleResult == null)
            {
                return false;
            }

            return true;
        }

        public bool AddIrrigularShape(IrregularShapeArea irregularShapeArea)
        {
            var irregularShape = ObjectMapper.ToIrregularShape(irregularShapeArea);
            var shape = ObjectMapper.ToShape(irregularShapeArea);

            var shapeResult = _repository.InsertShape(shape);

            foreach(var ishape in irregularShape)
            {
                ishape.ShapeId = shapeResult.Id;
            }

            var irregularShapeResult = _repository.InsertIrregularShape(irregularShape);

            if (shapeResult == null || irregularShapeResult == null)
            {
                return false;
            }

            return true;
        }

        public bool AddRectangle(RectangleArea rectangleArea)
        {
            var rectangle = ObjectMapper.ToRectangle(rectangleArea);
            var shape = ObjectMapper.ToShape(rectangleArea);

            var shapeResult = _repository.InsertShape(shape);
            rectangle.ShapeId = shapeResult.Id;
            var circleResult = _repository.InsertRectangle(rectangle);

            if (shapeResult == null || rectangle == null)
            {
                return false;
            }

            return true;
        }

        public IEnumerable<AreaType> GetShapeTypes()
        {
            var result = _repository.GetShapeTypes();

            if (result == null)
            {
                return null;
            }

            var areaTypes = ObjectMapper.ToAreaType(result);

            return areaTypes;
        }
    }
}
