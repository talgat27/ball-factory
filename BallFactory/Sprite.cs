using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace BallFactory
{
    internal class Sprite : Item
    {
        //Properites
        public Image[] frames = new Image[4];
        public int frameIndex = 0;

        //Constructors
        public Sprite(int width, int height, Image[] frames, Vector2 location) :
               base(width, height, new SolidBrush(Color.Black), location)
        {
            this.frames = frames;
        }

        //Methods
        override public void draw(Graphics canvas)
        {
            canvas.DrawImage(frames[frameIndex], topLeft.X, topLeft.Y, width, height);
            //Update frame index
            if (frameIndex == 3)
            {
                frameIndex = 0;
            }
            else
            {
                frameIndex++;
            }

        }
    }
}
