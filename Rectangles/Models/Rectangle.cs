using System.ComponentModel.DataAnnotations;

namespace Rectangles.Models
{
    public class Rectangle
    {
        [Key]
        public int Id { get; set; }
        public int RectanglePointId1 { get; set; }
        public int RectanglePointId2 { get; set; }
    }

    public class  Point
    {
        [Key]
        public int Id { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        public  Point(int x,int y)
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
                var point = new  Point(1,2);

               var rectangleCnt= context.Rectangle.Count();

                if (rectangleCnt < 200)
                {
                    Random rnd = new Random();
                    for (int i = rectangleCnt; i < 200; i++)
                    {
                        int x = rnd.Next();
                        int y = rnd.Next();

                        var samePoints = context.Point.Where(point => point.X == x && point.Y == y).ToList();

                        var pointId = 0;
                        if (samePoints.Count > 0)
                        {
                            pointId = samePoints.FirstOrDefault().Id;
                        }
                        else
                        {
                            context.Point.Add(point);
                            context.SaveChanges();
                        }

                    }
                }
            }
        }
    }
}
