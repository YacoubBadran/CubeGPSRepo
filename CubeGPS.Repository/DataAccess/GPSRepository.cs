using CubeGPS.Infrastructure.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using CubeGPS.Repository.Models;
using System.Threading.Tasks;

namespace CubeGPS.Repository.DataAccess
{
    public class GPSRepository : IGPSRepository
    {
        private readonly GPSContext _context;
        private readonly ILogger _logger;

        public GPSRepository (GPSContext context, ILoggerFactory loggerFactory)
        {
            _context = context;
            _logger = loggerFactory.CreateLogger(typeof(GPSRepository));
        }

        public IEnumerable<ShapeType> GetShapeTypes()
        {
            try
            {
                var shapeTypes = (from type in _context.ShapeType
                                  select type).ToList();

                return shapeTypes;
            }
            catch (SqlException ex)
            {
                _logger.LogWarning("GetShapeTypes method couldn't work, because of DB connection error: {ErrorMessage}", ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogWarning("GetShapeTypes method couldn't work, because of this error: {ErrorMessage}", ex.Message);
            }

            return null;
        }

        public Circle InsertCirlce(Circle circle)
        {
            try
            {
                _context.Circle.Add(circle);
                _context.SaveChanges();

                return circle;
            }
            catch (SqlException ex)
            {
                _logger.LogWarning("InsertCirlce method couldn't work, because of DB connection error: {ErrorMessage}", ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogWarning("InsertCirlce method couldn't work, because of this error: {ErrorMessage}", ex.Message);
            }

            return null;
        }

        public IEnumerable<IrregularShape> InsertIrregularShape(IEnumerable<IrregularShape> irregularShape)
        {
            try
            {
                _context.IrregularShape.AddRange(irregularShape);
                _context.SaveChanges();

                return irregularShape;
            }
            catch (SqlException ex)
            {
                _logger.LogWarning("InsertIrregularShape method couldn't work, because of DB connection error: {ErrorMessage}", ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogWarning("InsertIrregularShape method couldn't work, because of this error: {ErrorMessage}", ex.Message);
            }

            return null;
        }

        public Rectangle InsertRectangle(Rectangle rectangle)
        {
            try
            {
                _context.Rectangle.Add(rectangle);
                _context.SaveChanges();

                return rectangle;
            }
            catch (SqlException ex)
            {
                _logger.LogWarning("InsertRectangle method couldn't work, because of DB connection error: {ErrorMessage}", ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogWarning("InsertRectangle method couldn't work, because of this error: {ErrorMessage}", ex.Message);
            }

            return null;
        }

        public Shape InsertShape(Shape shape)
        {
            try
            {
                _context.Shape.Add(shape);
                _context.SaveChanges();

                return shape;
            }
            catch (SqlException ex)
            {
                _logger.LogWarning("InsertShape method couldn't work, because of DB connection error: {ErrorMessage}", ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogWarning("InsertShape method couldn't work, because of this error: {ErrorMessage}", ex.Message);
            }

            return null;
        }
    }
}
