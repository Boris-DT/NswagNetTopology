﻿using Microsoft.AspNetCore.Mvc;
using NetTopologySuite.Geometries;

namespace Nswag14_0_7.Controllers
{
    [Produces("application/json")]
    [Route("api/route")]
    [ApiController]
    public class RouteController : ControllerBase
    {
        [HttpGet("GetStartCoordinate")]
        public Point GetStartCoordinate()
        {
            return new Point(new Coordinate(51.05, 3.72));
        }

        [HttpGet("GetLineString")]
        public LineString GetLineString()
        {
            return new LineString(new[] { new Coordinate(51.05, 3.72), new Coordinate(50.84, 4.36) });
        }
    }
}