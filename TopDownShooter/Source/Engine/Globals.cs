using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace TopDownShooter
{
    public class Globals
    {
        public static int screenHeight, screenWidth;
        public static ContentManager content;
        public static SpriteBatch spriteBatch;

        public static McKeyboard keyboard;
        public static McMouseControl mouse;


        public static float GetDistance(Vector2 pos, Vector2 target)
        {
            return (float)Math.Sqrt(Math.Pow(pos.X - target.X, 2) + Math.Pow(pos.Y - target.Y, 2));
        }

        public static float RotateTowards(Vector2 Pos, Vector2 focus)
        {
            // return (float)Math.Atan2(Pos.Y - focus.Y, Pos.X - focus.X) - MathHelper.PiOver2;

            float h, sineTheta, angle;
            if (Pos.Y - focus.Y != 0)
            {
                h = (float)Math.Sqrt(Math.Pow(Pos.X - focus.X, 2) + Math.Pow(Pos.Y - focus.Y, 2));
                sineTheta = (float)(Math.Abs(Pos.Y - focus.Y) / h); //* ((item.Pos.Y-focus.Y)/(Math.Abs(item.Pos.Y-focus.Y))));
            }
            else
            {
                h = Pos.X - focus.X;
                sineTheta = 0;
            }

            angle = (float)Math.Asin(sineTheta);

            // Drawing diagonial lines here.
            //Quadrant 2
            if (Pos.X - focus.X > 0 && Pos.Y - focus.Y > 0)
            {
                angle = (float)(Math.PI * 3 / 2 + angle);
            }
            //Quadrant 3
            else if (Pos.X - focus.X > 0 && Pos.Y - focus.Y < 0)
            {
                angle = (float)(Math.PI * 3 / 2 - angle);
            }
            //Quadrant 1
            else if (Pos.X - focus.X < 0 && Pos.Y - focus.Y > 0)
            {
                angle = (float)(Math.PI / 2 - angle);
            }
            else if (Pos.X - focus.X < 0 && Pos.Y - focus.Y < 0)
            {
                angle = (float)(Math.PI / 2 + angle);
            }
            else if (Pos.X - focus.X > 0 && Pos.Y - focus.Y == 0)
            {
                angle = (float)Math.PI * 3 / 2;
            }
            else if (Pos.X - focus.X < 0 && Pos.Y - focus.Y == 0)
            {
                angle = (float)Math.PI / 2;
            }
            else if (Pos.X - focus.X == 0 && Pos.Y - focus.Y > 0)
            {
                angle = (float)0;
            }
            else if (Pos.X - focus.X == 0 && Pos.Y - focus.Y < 0)
            {
                angle = (float)Math.PI;
            }

            return angle;
        }

    }



}