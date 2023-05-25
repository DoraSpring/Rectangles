using System.Windows;
using System.Drawing;
using System.ComponentModel.DataAnnotations;

namespace Rectangles.Services
{
    public class RectangleService
    {
        public static RectanglesContainingPoint[] GetRectanglesContainingPoints(UserPoint[] points)
        {
            RectanglesContainingPoint[] rectanglesContainingPoints = new RectanglesContainingPoint[points.Length];

            var allRectangles = Models.RectangleAdmin.GetRectangles();

            for (int i = 0; i < points.Length; i++)
            {
                var rectangles = new List<Models.RectangleDetail>();
                foreach (var rectangle in allRectangles)
                {
                    if (PointInRectangle(points[i], rectangle))
                    {
                        rectangles.Add(rectangle);
                    }
                }

                rectanglesContainingPoints[i] = new RectanglesContainingPoint();
                rectanglesContainingPoints[i].Point = points[i];
                rectanglesContainingPoints[i].Rectangles = rectangles;

            }

            return rectanglesContainingPoints;
        }

        public static bool PointInRectangle(UserPoint point, Models.RectangleDetail rectangleDetail)
        {
            Rectangle rectangle = new Rectangle(rectangleDetail.X, rectangleDetail.Y, rectangleDetail.Width, rectangleDetail.Height);

            return rectangle.Contains(new Point(point.X, point.Y));
        }
    }

    public class UserPoint
    {
        public int X { get; set; }
        public int Y { get; set; }
    }

    public class RectanglesContainingPoint
    {
        public Services.UserPoint Point { get; set; }
        public List<Models.RectangleDetail> Rectangles;
    }
}
