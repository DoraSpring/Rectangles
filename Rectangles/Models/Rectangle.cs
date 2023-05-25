using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Drawing;
using System.Security.Cryptography;

namespace Rectangles.Models
{
    public class RectangleDetail
    {
        public int Id { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
    }

    public class RectangleAdmin
    {
        public static List<RectangleDetail> GetRectangles()
        {
            using (var context = new MyContext())
            {
                var rectangles = (from r in context.Rectangle
                                  join c in context.Coordinate on r.CoordinateId equals c.Id
                                  select new RectangleDetail
                                  {
                                      Id = r.Id,
                                      X = c.X,
                                      Y = c.Y,
                                      Width = r.Width,
                                      Height = r.Height,
                                  }).ToList();

                return rectangles;
            }
        }

        public static void CreateRectangles()
        {
            using (var context = new MyContext())
            {
                var rectangleCnt = context.Rectangle.Count();

                int i = rectangleCnt;
                while (i < Utils.Constant.MaxRectangles)
                {
                    Random rnd = new Random();

                    var coordinateId = CreateOrGetCoordinate(context,rnd);
                    var width = rnd.Next();
                    var height = rnd.Next();

                    var sameRectangle = context.Rectangle.Where(r => r.CoordinateId == coordinateId && r.Width == width && r.Height==height).ToList();
                    if (sameRectangle.Count > 0)
                    {
                        continue;
                    }

                    Rectangle rectangle = new Rectangle(coordinateId, width,height);

                    context.Rectangle.Add(rectangle);
                    context.SaveChanges();

                    i++;
                }
            }
        }

        public static int CreateOrGetCoordinate(MyContext context, Random rnd)
        {
            var newCoordinate = new Coordinate(rnd.Next(), rnd.Next());

            var sameCoordinates = context.Coordinate.Where(c => c.X == newCoordinate.X && c.Y == newCoordinate.Y).ToList();

            var newCoordinateId = 0;
            if (sameCoordinates.Count>0)
            {
                newCoordinateId = sameCoordinates.First().Id;
            }
            else
            {
                context.Coordinate.Add(newCoordinate);
                context.SaveChanges();

                newCoordinateId = newCoordinate.Id;
            }

            return newCoordinateId;
        }

        public static decimal GetRandomDecimal(Random rnd)
        {
            var x = (decimal)rnd.Next() + decimal.Round((decimal)rnd.NextDouble(), 2, MidpointRounding.AwayFromZero);
            return x;
        }
    }

    public class Rectangle
    {
        [Key]
        public int Id { get; set; }

        [Column("coordinate_id", TypeName = "int")]
        public int CoordinateId { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public Rectangle(int coordinateId, int width, int height)
        {
            CoordinateId = coordinateId;
            Width = width;
            Height = height;
        }

    }

    public class Coordinate
    {
        [Key]
        public int Id { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        public Coordinate(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
