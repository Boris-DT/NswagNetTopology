using Microsoft.AspNetCore.Mvc;
using NetTopologySuite.Geometries;

namespace Nswag14_0_7_Type_Mapper.Controllers
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
    }
}