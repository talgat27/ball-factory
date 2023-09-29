using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace BallFactory
{
    internal class Factory
    {
        //Properties
        public List<Circle> listOfCircles = new List<Circle>();
        public List<Sprite> listOfSprites = new List<Sprite>();
        public List<Bullet> listOfBullets = new List<Bullet>();

        public Vector2 circleGenerator = new Vector2(0, 40);

        public Sprite windMill;
        public Sprite belt;
        public BgItem trampoline;
        public Tank tank;
        public BgItem stage;

        //Constructors
        public Factory()
        {

            Image[] frames = new Image[] {Properties.Resources.windmill1,
                                          Properties.Resources.windmill2,
                                          Properties.Resources.windmill3,
                                          Properties.Resources.windmill4 };
            windMill = new Sprite(100, 100, frames, new Vector2(450, 70));

            frames = new Image[]{ Properties.Resources.belt1,
                                  Properties.Resources.belt2,
                                  Properties.Resources.belt3,
                                  Properties.Resources.belt4};
            belt = new Sprite(160, 20, frames, new Vector2(60, 200));

            Image Image = Properties.Resources.trampoline1;
            trampoline = new BgItem(Image, 120, 40, new Vector2(400, 460));

            Image = Properties.Resources.stage;
            stage = new BgItem(Image, 200, 60, new Vector2(0, 450));

            List<Image> Images = new List<Image>  { Properties.Resources.tank,
                                   Properties.Resources.tank2,
                                   Properties.Resources.tank2,
                                   Properties.Resources.tank};

            tank = new Tank(200, 100, Images, new Vector2(0, 350));

        }

        //Methods

        //--------------------------------
        public bool checkCollision(Circle obj1, Sprite obj2)
        {
            //Calculate the center coordinate of 2 object boxes
            int obj1CenterX = (int)obj1.topLeft.X + (obj1.width / 2);
            int obj1CenterY = (int)obj1.topLeft.Y + (obj1.height / 2);

            int obj2CenterX = (int)obj2.topLeft.X + (obj2.width / 2);
            int obj2CenterY = (int)obj2.topLeft.Y + (obj2.height / 2);

            //Calculate the distance between the central points of two object boxes
            int centralDistanceX = Math.Abs(obj1CenterX - obj2CenterX);
            int centralDistanceY = Math.Abs(obj1CenterY - obj2CenterY);

            //Check two collision conditions:
            if (centralDistanceX <= (obj1.width / 2 + obj2.width / 2)
                && centralDistanceY <= (obj1.height / 2 + obj2.height / 2))
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public void collisionCircleBeltWindMill()
        {
            foreach (Circle circle in listOfCircles)
            {
                //Circle touches belt
                if (checkCollision(circle, belt))
                {

                    if (circle.topLeft.Y < belt.topLeft.Y)
                    {
                        //circle touches upper surface of the belt
                        circle.velocity.Y = -circle.velocity.Y;
                        circle.topLeft.Y = belt.topLeft.Y - circle.height;
                    }
                    else
                    {
                        //circle touches lower surface of the belt
                        circle.velocity.Y = -circle.velocity.Y;
                        circle.topLeft.Y = belt.topLeft.Y + belt.height;
                    }
                }

                //increment
                double velocityIncrement = 1.7;
                int upperLimit = 12;

                //Circle touches windmill1
                if (checkCollision(circle, windMill))
                {
                    if (circle.topLeft.Y < windMill.topLeft.Y)
                    {
                        //circle touches upper side of the windmill
                        circle.velocity.Y = -circle.velocity.Y;
                        circle.topLeft.Y = windMill.topLeft.Y - circle.height;
                        //increase the velocity by velocity increment
                        if (circle.velocity.X <= upperLimit && circle.velocity.Y <= upperLimit)
                        {
                            circle.velocity = (int)velocityIncrement * circle.velocity;
                        }

                    }
                    else if (circle.topLeft.Y > windMill.topLeft.Y + windMill.height)
                    {
                        //circle touches lower side of the windmill
                        circle.velocity.Y = -circle.velocity.Y;
                        circle.topLeft.Y = windMill.topLeft.Y + belt.height;
                        //increase the velocity by velocity increment
                        if (circle.velocity.X <= upperLimit && circle.velocity.Y <= upperLimit)
                        {
                            circle.velocity = (int)velocityIncrement * circle.velocity;
                        }

                    }
                    else
                    {
                        //circle touches left side of the windmill
                        if (circle.topLeft.X < windMill.topLeft.X)
                        {
                            circle.velocity.X = -circle.velocity.X;
                            circle.topLeft.X = windMill.topLeft.X - circle.width;
                            //increase the velocity by velocity increment
                            if (circle.velocity.X <= upperLimit && circle.velocity.Y <= upperLimit)
                            {
                                circle.velocity = (int)velocityIncrement * circle.velocity;
                            }
                        }
                        else
                        {
                            //circle touches right side of the windmill
                            circle.velocity.X = -circle.velocity.X;
                            circle.topLeft.X = windMill.topLeft.X + windMill.width;
                            //increase the velocity by velocity increment
                            if (circle.velocity.X <= upperLimit && circle.velocity.Y <= upperLimit)
                            {
                                circle.velocity = (int)velocityIncrement * circle.velocity;
                            }
                        }
                    }
                }
            }
        }

        public bool checkCollision(Circle obj1, Tank obj2)
        {
            //Calculate the center coordinate of 2 object boxes
            int obj1CenterX = (int)obj1.topLeft.X + (obj1.width / 2);
            int obj1CenterY = (int)obj1.topLeft.Y + (obj1.height / 2);

            int obj2CenterX = (int)obj2.topLeft.X + (obj2.width / 2);
            int obj2CenterY = (int)obj2.topLeft.Y + (obj2.height / 2);

            //Calculate the distance between the central points of two object boxes
            int centralDistanceX = Math.Abs(obj1CenterX - obj2CenterX);
            int centralDistanceY = Math.Abs(obj1CenterY - obj2CenterY);

            //Check two collision conditions:
            if (centralDistanceX <= (obj1.width / 2 + obj2.width / 2)
                && centralDistanceY <= (obj1.height / 2 + obj2.height / 2))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void collisionCircleTank()
        {
            foreach (Circle circle in listOfCircles)
            {
                //Circle touches tank
                if (checkCollision(circle, tank))
                {
                    //increment
                    double velocityIncrement = 1.7;
                    int upperLimit = 12;


                    //Circle touches tank
                    if (checkCollision(circle, tank))
                    {
                        if (circle.topLeft.Y < tank.topLeft.Y)
                        {
                            //circle touches upper side of the tank
                            circle.velocity.Y = -circle.velocity.Y;
                            circle.topLeft.Y = tank.topLeft.Y - circle.height;
                            //increase the velocity by velocity increment
                            if (circle.velocity.X <= upperLimit && circle.velocity.Y <= upperLimit)
                            {
                                circle.velocity = (int)velocityIncrement * circle.velocity;
                            }

                        }
                        else
                        {
                            //circle touches left side of the tank
                            if (circle.topLeft.X > tank.topLeft.X)
                            {
                                //circle touches right side of the windmill
                                circle.velocity.X = -circle.velocity.X;
                                circle.topLeft.X = tank.topLeft.X + tank.width;
                                //increase the velocity by velocity increment
                                if (circle.velocity.X <= upperLimit && circle.velocity.Y <= upperLimit)
                                {
                                    circle.velocity = (int)velocityIncrement * circle.velocity;
                                }
                            }
                        }

                    }
                }
            }
        }

        public bool checkCollision(Circle obj1, BgItem obj2)
        {
            //Calculate the center coordinate of 2 object boxes
            int obj1CenterX = (int)obj1.topLeft.X + (obj1.width / 2);
            int obj1CenterY = (int)obj1.topLeft.Y + (obj1.height / 2);

            int obj2CenterX = (int)obj2.topLeft.X + (obj2.width / 2);
            int obj2CenterY = (int)obj2.topLeft.Y + (obj2.height / 2);

            //Calculate the distance between the central points of two object boxes
            int centralDistanceX = Math.Abs(obj1CenterX - obj2CenterX);
            int centralDistanceY = Math.Abs(obj1CenterY - obj2CenterY);

            //Check two collision conditions:
            if (centralDistanceX <= (obj1.width / 2 + obj2.width / 2 - Math.Min(obj1.width, obj2.width) / 2)
                && centralDistanceY <= (obj1.height / 2 + obj2.height / 2) - Math.Min(obj1.height, obj2.height) / 2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void collisionCircleStage()
        {
            foreach (Circle circle in listOfCircles)
            {
                //Circle touches stage
                if (checkCollision(circle, stage))
                {

                    //increment
                    double velocityIncrement = 1.7;
                    int upperLimit = 12;


                    //Circle touches stage
                    if (checkCollision(circle, stage))
                    {
                        if (circle.topLeft.Y > stage.topLeft.Y)
                        {
                            if (circle.topLeft.X > stage.topLeft.X)
                            {
                                //circle touches right side of the stage
                                circle.velocity.X = -circle.velocity.X;
                                circle.topLeft.X = stage.topLeft.X + stage.width;
                                //increase the velocity by velocity increment
                                if (circle.velocity.X <= upperLimit && circle.velocity.Y <= upperLimit)
                                {
                                    circle.velocity = (int)velocityIncrement * circle.velocity;
                                }
                            }

                        }
                    }
                }
            }
        }

        public void collisionCircleTrampoline()
        {
            bool collision = false;
            foreach (Circle circle in listOfCircles)
            {
                if (checkCollision(circle, trampoline))
                {
                    //circle touches the trampoline surface
                    circle.velocity.Y = -circle.velocity.Y;
                    circle.topLeft.Y = trampoline.topLeft.Y - circle.height;
                    collision = true;
                }
            }

            //Change the trampoline image if collision is true
            if (collision)
            {
                trampoline.image = Properties.Resources.trampoline2;
            }
            else
            {
                trampoline.image = Properties.Resources.trampoline1;
            }
        }



        //--------------------------------
        public void updateBullet()
        {
            for (var i = listOfBullets.Count - 1; i >= 0; i--)
            {
                if (listOfBullets[i].topLeft.X >= 650)
                {
                    listOfBullets.RemoveAt(i);
                }
            }
        }


        public bool checkCollision(Bullet obj1, Circle obj2)
        {
            //Calculate the center coordinate of 2 object boxes
            int obj1CenterX = (int)obj1.topLeft.X + (obj1.width / 2);
            int obj1CenterY = (int)obj1.topLeft.Y + (obj1.height / 2);

            int obj2CenterX = (int)obj2.topLeft.X + (obj2.width / 2);
            int obj2CenterY = (int)obj2.topLeft.Y + (obj2.height / 2);

            //Calculate the distance between the central points of two object boxes
            int centralDistanceX = Math.Abs(obj1CenterX - obj2CenterX);
            int centralDistanceY = Math.Abs(obj1CenterY - obj2CenterY);

            //Check two collision conditions:
            if (centralDistanceX <= (obj1.width / 2 + obj2.width / 2 - Math.Min(obj1.width, obj2.width) / 2)
                && centralDistanceY <= (obj1.height / 2 + obj2.height / 2) - Math.Min(obj1.height, obj2.height) / 2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void collisionBulletBall()
        {
            for (var i = listOfBullets.Count - 1; i >= 0; i--)
            {
                for (var j = listOfCircles.Count - 1; j >= 0; j--)
                {
                    //
                    if (checkCollision(listOfBullets[i], listOfCircles[j]))
                    {
                        listOfBullets[i].alive = false;
                        listOfCircles[j].alive = false;
                    }
                }
            }
            //Remove all dead bullets and sprites
            for (var i = listOfBullets.Count - 1; i >= 0; i--)
            {
                if (!listOfBullets[i].alive)
                {
                    listOfBullets.RemoveAt(i);
                }
            }
            for (var j = listOfCircles.Count - 1; j >= 0; j--)
            {
                if (!listOfCircles[j].alive)
                {
                    listOfCircles.RemoveAt(j);
                }
            }
        }

        public void removeBallBullet() {
            for (var i = listOfBullets.Count - 1; i >= 0; i--)
            {
                listOfBullets.RemoveAt(i);
            }
            for (var i = listOfCircles.Count - 1; i >= 0; i--)
            {
                listOfCircles.RemoveAt(i);
            }
        }
    }
}
