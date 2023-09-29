using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BallFactory
{
    public partial class Form1 : Form
    {
        //Global objects, variables
        Factory factory = new Factory();

        public Form1()
        {
            InitializeComponent();
            //
            Item.boundaryW = canvas.Width;
            Item.boundaryH = canvas.Height;
        }
        //---------------------------------------------------------------

        private void Form1_Load(object sender, EventArgs e)
        {
            //Add a timer
            Timer timer = new Timer();
            timer.Interval = 50;//100ms
            timer.Tick += timer_Tick;//Add Tick event
            timer.Enabled = true;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            canvas.Invalidate();
        }
        //---------------------------------------------------------------
        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            //Draw ball generator
            e.Graphics.FillRectangle(new SolidBrush(Color.Blue), factory.circleGenerator.X, factory.circleGenerator.Y, 15, 80);

            factory.belt.draw(e.Graphics);
            factory.windMill.draw(e.Graphics);
            factory.trampoline.draw(e.Graphics);
            factory.tank.draw(e.Graphics);
            factory.stage.draw(e.Graphics);

            //Draw all objects in the List
            foreach (Circle circle in factory.listOfCircles)
            {
                circle.move();
                circle.draw(e.Graphics);
            }


            foreach (Bullet bullet in factory.listOfBullets)
            {
                bullet.move();
                bullet.draw(e.Graphics);
            }

            //Check collision
            factory.collisionCircleBeltWindMill();
            factory.collisionCircleTrampoline();
            factory.collisionCircleTank();
            factory.collisionCircleStage();



            factory.updateBullet();
            factory.collisionBulletBall();
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            //Create a blue ball at the generator block           
            Circle circle = new Circle(20, new SolidBrush(Color.Blue),
                new Vector2(0, 50));
            factory.listOfCircles.Add(circle);
        }

        private void shootBtn_Click(object sender, EventArgs e)
        {
            Image image = Properties.Resources.bullet;
            Bullet bullet = new Bullet(image, 40, 30,
                new Vector2(factory.tank.topLeft.X + 180, factory.tank.topLeft.Y - 2));
            bullet.velocity = new Vector2(10, 0);
            factory.tank.status = 1;
            factory.listOfBullets.Add(bullet);
        }

        private void stopBtn_Click(object sender, EventArgs e)
        {
            factory.removeBallBullet();
        }
    }
}
