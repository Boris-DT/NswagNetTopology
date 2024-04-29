using Microsoft.AspNetCore.Mvc;
using NetTopologySuite.Geometries;

namespace Nswag13_20_0.Controllers
{
    [Produces("application/json")]
    [Route("api/geocode")]
    [ApiController]
    public class GeoController : ControllerBase
    {
        [HttpGet("GetCoordinate")]
        public Point GetCoordinate()
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