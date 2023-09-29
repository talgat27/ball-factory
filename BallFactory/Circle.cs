using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace BallFactory
{
    internal class Circle : Item
    {
        //Propeties
        public int radius;
        public bool alive = true;

        //Constructor
        public Circle(int radius, SolidBrush color, Vector2 location)
            : base(2 * radius, 2 * radius, color, location)
        {
            this.radius = radius;
        }

        //Methods
        override public void draw(Graphics canvas)
        {
            canvas.FillEllipse(color, topLeft.X, topLeft.Y, width, height);
        }
    }
}
