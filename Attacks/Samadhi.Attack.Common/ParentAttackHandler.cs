using Samadhi.Data;
using Samadhi.History.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Samadhi.Attack.Common
{
    public abstract class ParentAttackHandler
    {
        public List<AttackModel> Attacks = new List<AttackModel>();
        public abstract bool Validate(AttackHistory history, Request request);
    }
}

//class Shape
//{
//    public void setWidth(int w)
//    {
//        width = w;
//    }
//    public void setHeight(int h)
//    {
//        height = h;
//    }
//    protected int width;
//    protected int height;
//}

//// Derived class
//class Rectangle : Shape
//{
//    public int getArea()
//    {
//        return (width * height);
//    }
//}

//class RectangleTester
//{
//    static void Main(string[] args)
//    {
//        Rectangle Rect = new Rectangle();

//        Rect.setWidth(5);
//        Rect.setHeight(7);

//        // Print the area of the object.
//        Console.WriteLine("Total area: {0}", Rect.getArea());
//        Console.ReadKey();
//    }
//}