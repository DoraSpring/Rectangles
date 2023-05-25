using Microsoft.AspNetCore.Mvc;

using System.Drawing;

namespace Rectangles.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class RectangleController
    {
        private readonly ILogger<RectangleController> _logger;

        public RectangleController(ILogger<RectangleController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetRectangles")]
        public Services.RectanglesContainingPoint[] Get([FromBody] Point[] points)
        {
            var rectangles = Services.RectangleService.GetRectanglesContainingPoints(points);
            return rectangles;
        }
    }
}
