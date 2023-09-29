using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace BallFactory
{
    internal class Tank : Item
    {
        //Properties
        public int status = 0;//0: initial
        public int frameIndex = 0;
        public List<Image> frames = new List<Image>();
        public Image currentImage;

        //Constructor
        public Tank(int width, int height, List<Image> frames, Vector2 location) :
            base(width, height, new SolidBrush(Color.Black), location)
        {
            this.frames = frames;
            this.currentImage = frames[0];
        }

        //Methods
        public void update()
        {
            if (status == 0)
            {
                currentImage = frames[0];
            }
            else
            {
                //Update frame index
                frameIndex++;
                if (frameIndex == 3)
                {
                    status = 0;
                    frameIndex = 0;
                }
                else
                {
                    frameIndex++;
                }
                currentImage = frames[frameIndex];
            }
        }

        //Override the draw() method in parent class
        override public void draw(Graphics canvas)
        {
            update();
            canvas.DrawImage(this.currentImage, topLeft.X, topLeft.Y, width, height);
        }
    }
}
