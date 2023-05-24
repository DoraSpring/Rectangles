using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace Rectangles.Models
{
    public class Rectangle
    {
        [Key]
        public int Id { get; set; }
        public int Point1 { get; set; }
        public int Point2 { get; set; }

        public Rectangle(int point1, int point2)
        {
            Point1 = point1;
            Point2 = point2;
        }
    }

    public class Point
    {
        [Key]
        public int Id { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
    }

    public class RectangleAdmin
    {
        public void TestDbConnection()
        {
            using (var context = new MyContext())
            {
                var rectangleCnt = context.Rectangle.Count();

                for (int i = rectangleCnt; i < Utils.Constant.MaxRectangles; i++)
                {
                    var point1 = CreateOrGetPoint(context);
                    var point2 = CreateOrGetPoint(context);

                    var sameRectangle = context.Rectangle.Where(rectangle => rectangle.Point1 == point1 && rectangle.Point2 == point2).ToList();
                    Rectangle rectangle = new Rectangle(point1, point2);

                    context.Rectangle.Add(rectangle);
                    context.SaveChanges();
                }
            }
        }

        public int CreateOrGetPoint(MyContext context)
        {
            Random rnd = new Random();

            var newPoint = new Point(rnd.Next(), rnd.Next());

            var samePoints = context.Point.Where(point => point.X == newPoint.X && point.Y == newPoint.Y).ToList();

            var point = 0;
            if (samePoints.Count > 0)
            {
                point = samePoints.First().Id;
            }
            else
            {
                context.Point.Add(newPoint);
                context.SaveChanges();

                point = newPoint.Id;
            }

            return point;
        }
    }
}
