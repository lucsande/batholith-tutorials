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
            // fazemos + ou - 8 pra melhorar feedback visual, pra personagem nunca conseguir ficar 100% escondido da tela
            float maxLeft = 0 - dims.X / 2 + 8;
            float maxRight = 800 + dims.X / 2 - 8;
            float maxTop = 0 - dims.Y / 2 + 8;
            float maxBottom = 480 + dims.Y / 2 - 8;

            if (Globals.keyboard.GetPress("A"))
            {
                float newX = pos.X < maxLeft ? maxRight : pos.X - speed;
                pos = new Vector2(newX, pos.Y);
            }

            if (Globals.keyboard.GetPress("D"))
            {
                float newX = pos.X > maxRight ? maxLeft : pos.X + speed;
                pos = new Vector2(newX, pos.Y);
            }

            if (Globals.keyboard.GetPress("W"))
            {
                float newY = pos.Y < maxTop ? maxBottom : pos.Y - speed;
                pos = new Vector2(pos.X, newY);
            }

            if (Globals.keyboard.GetPress("S"))
            {
                float newY = pos.Y > maxBottom ? maxTop : pos.Y + speed;
                pos = new Vector2(pos.X, newY);
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