#region Includes
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;

using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using Microsoft.Xna.Framework.Media;
#endregion

namespace TopDownShooter
{
    public class Hero : Basic2d
    {
        public float speed;
        public Hero(string PATH, Vector2 POS, Vector2 DIMS) : base(PATH, POS, DIMS)
        {
            speed = 2.0f;
        }

        public override void Update()
        {
            if (Globals.keyboard.GetPress("A"))
            {
                pos = new Vector2(pos.X - 1, pos.Y);
            }

            if (Globals.keyboard.GetPress("D"))
            {
                pos = new Vector2(pos.X + 1, pos.Y);
            }

            if (Globals.keyboard.GetPress("W"))
            {
                pos = new Vector2(pos.X, pos.Y - 1);
            }

            if (Globals.keyboard.GetPress("S"))
            {
                pos = new Vector2(pos.X, pos.Y + 1);
            }

            Vector2 mouseFocus = new Vector2(Globals.mouse.newMousePos.X, Globals.mouse.newMousePos.Y);
            rot = Globals.RotateTowards(pos, mouseFocus);


            base.Update();
        }

        public override void Draw(Vector2 OFFSET)
        {
            base.Draw(OFFSET);
        }
    }
}