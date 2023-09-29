﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace BallFactory
{
    internal class Bullet : Item
    {
        //Properties
        public Image image;
        public bool alive = true;

        //Constructor
        public Bullet(Image image, int width, int height, Vector2 location) :
            base(width, height, new SolidBrush(Color.Black), location)
        {
            this.image = image;
        }

        //Methods
        override public void draw(Graphics canvas)
        {
            canvas.DrawImage(this.image, topLeft.X, topLeft.Y, width, height);
        }
    }
}
