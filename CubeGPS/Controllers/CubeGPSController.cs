using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CubeGPS.Models;
using CubeGPS.Business.Services;
using CubeGPS.Models.Authorizations;
using CubeGPS.Infrastructure.Models;
using CubeGPS.Models.APIResponse;

namespace CubeGPS.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CubeGPSController : ControllerBase
    {
        private readonly IGPSService _GPSService;
        private readonly ILogger<CubeGPSController> _logger;

        public CubeGPSController(ILogger<CubeGPSController> logger, IGPSService GPSService)
        {
            _GPSService = GPSService;
            _logger = logger;
        }

        [BasicAuthorize("CubeGPS")]
        [HttpGet("GetShapeTypes")]
        public GetShapeTypesResponse GetShapeTypes()
        {
            var response = new GetShapeTypesResponse();

            try
            {
                var shapeTypes = _GPSService.GetShapeTypes();

                if (shapeTypes == null)
                {
                    HttpContext.Response.StatusCode = 500;

                    response.Success = new APISuccessResponse("Internal Server Error");
                    return response;
                }
                else
                {
                    response.ShapeTypes = shapeTypes;
                    response.Success = new APISuccessResponse();

                    return response;
                }
            }
            catch (Exception ex)
            {
                _logger.LogWarning("An error occurs, Exception: {Exception Message}", ex.Message);
                HttpContext.Response.StatusCode = 500;

                response.Success = new APISuccessResponse("Internal Server Error");

                return response;
            }
        }

        [BasicAuthorize("CubeGPS")]
        [HttpPost("AddCircle")]
        public APISuccessResponse AddCircle([FromBody] CircleArea circle)
        {
            try
            {
                if(circle.Radius == 0 || string.IsNullOrEmpty(circle.Name))
                {
                    HttpContext.Response.StatusCode = BadRequest().StatusCode;

                    return new APISuccessResponse("One or more fields in the request contain invalid data");
                }

                bool isSuccess = _GPSService.AddCircle(circle);

                if(isSuccess)
                {
                    HttpContext.Response.StatusCode = Ok().StatusCode;

                    return new APISuccessResponse();
                }
                else
                {
                    return new APISuccessResponse("Error in adding circle to database");
                }
            }
            catch (Exception ex)
            {
                _logger.LogWarning("An error occurs, Exception: {Exception Message}", ex.Message);
                HttpContext.Response.StatusCode = 500;

                return new APISuccessResponse("Internal Server Error");
            }
        }

        [BasicAuthorize("CubeGPS")]
        [HttpPost("AddRectangle")]
        public APISuccessResponse AddRectangle([FromBody] RectangleArea rectangle)
        {
            try
            {
                if (rectangle.Coordinate1.Longitude == rectangle.Coordinate2.Longitude ||
                    rectangle.Coordinate1.Latitude == rectangle.Coordinate2.Latitude)
                {
                    HttpContext.Response.StatusCode = BadRequest().StatusCode;

                    return new APISuccessResponse("The selected shape is not a rectangle");
                }

                bool isSuccess = _GPSService.AddRectangle(rectangle);

                if (isSuccess)
                {
                    HttpContext.Response.StatusCode = Ok().StatusCode;

                    return new APISuccessResponse();
                }
                else
                {
                    return new APISuccessResponse("Error in adding rectangle to database");
                }
            }
            catch (Exception ex)
            {
                _logger.LogWarning("An error occurs, Exception: {Exception Message}", ex.Message);
                HttpContext.Response.StatusCode = 500;

                return new APISuccessResponse("Internal Server Error");
            }
        }

        [BasicAuthorize("CubeGPS")]
        [HttpPost("AddIrregularShape")]
        public APISuccessResponse AddIrregularShape([FromBody] IrregularShapeArea irregularShape)
        {
            try
            {
                
                if (irregularShape.Coordinates.Count < 3)
                {
                    HttpContext.Response.StatusCode = BadRequest().StatusCode;

                    return new APISuccessResponse("The shape should have at least three coordinates");
                }

                bool isSuccess = _GPSService.AddIrrigularShape(irregularShape);

                if (isSuccess)
                {
                    HttpContext.Response.StatusCode = Ok().StatusCode;

                    return new APISuccessResponse();
                }
                else
                {
                    return new APISuccessResponse("Error in adding rectangle to database");
                }
            }
            catch (Exception ex)
            {
                _logger.LogWarning("An error occurs, Exception: {Exception Message}", ex.Message);
                HttpContext.Response.StatusCode = 500;

                return new APISuccessResponse("Internal Server Error");
            }
        }
    }
}
