using CubeGPS.Infrastructure.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CubeGPS.Models.APIResponse
{
    public class GetShapeTypesResponse : APIResponse
    {
        [JsonProperty(PropertyName = "ShapeTypes")]
        public IEnumerable<AreaType> ShapeTypes { get; set; }

        public GetShapeTypesResponse() : base()
        {
            ShapeTypes = new List<AreaType>();
        }
    }
}
