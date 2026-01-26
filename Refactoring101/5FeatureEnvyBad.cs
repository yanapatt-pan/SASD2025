using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refactoring101.FeatureEnvyBad;

// 5
public class FeatureEnvy
{
    public void TestAdd()
    {
        /* Solution 1
        var point = Point.Add(new Point(2, 3), new Point(4, 5));
        */

        /* Solution 2
        var point = new Point(2, 3).Add(new Point(4,5));
        */ 

        //Solution 3
        var point = new Point(2, 3) + new Point(4, 5);
    }
    /*public Point AddPoint(Point a, Point b)
    {
        return new Point(a.X + b.X, a.Y + b.Y);
    }*/
}

public class Point
{
    public double X { get; }
    public double Y { get; }
    public Point(double x, double y)
    {
        X = x;
        Y = y;
    }

    /* Solution 1
    public static Point Add(Point a, Point b)
    {
        return new Point(a.X + b.X, a.Y + b.Y);
    }
    */
    /* Solution 2

    public Point Add(Point b)
    {
        return new Point(this.X + b.X, this.Y + b.Y);
    }
    */
    // Solution 3 Operator Overloading (Only C++ and C#)
    public static Point operator +(Point a, Point b)
    {
        return new Point(a.X + b.X, a.Y + b.Y);
    }
}
