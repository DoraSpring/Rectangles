using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

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
        public IEnumerable<Models.Rectangle> Get()
        {
            return null;
        }
    }
}
