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
        public IEnumerable<RectangleOut> Get([FromBody] Services.UserPoint[] points)
        {
            var rectangles = Services.RectangleService.GetRectanglesContainingPoints(points).ToArray();


            var rectanglesOut = rectangles.Select(rectangle => new RectangleOut
            {
                Point = rectangle.Point,
                Rectangles = rectangle.Rectangles
            })
            .ToArray();

            return rectanglesOut;
        }
    }
}
