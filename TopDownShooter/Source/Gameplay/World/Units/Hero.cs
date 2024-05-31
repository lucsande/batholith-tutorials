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
    public class Hero : Unit
    {
        new public float speed;
        public Hero(string PATH, Vector2 POS, Vector2 DIMS) : base(PATH, POS, DIMS)
        {
            speed = 2.0f;
        }

        public override void Update()
        {
            // fazemos + ou - 8 pra melhorar feedback visual, pra personagem nunca conseguir ficar 100% escondido da tela
            float screenVisibilityOffset = 8;
            float maxLeft = 0 - dims.X / 2 + screenVisibilityOffset;
            float maxRight = Globals.screenWidth + dims.X / 2 - screenVisibilityOffset;
            float maxTop = 0 - dims.Y / 2 + screenVisibilityOffset;
            float maxBottom = Globals.screenHeight + dims.Y / 2 - screenVisibilityOffset;

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

            if (Globals.mouse.LeftClick())
            {
                Random rand = new Random();
                float startProjX = pos.X + rand.Next((int)dims.X / 2 * -1, (int)dims.X / 2);
                float startProjY = pos.Y + rand.Next((int)dims.Y / 2 * -1, (int)dims.Y / 2);

                Vector2 startProjPos = new Vector2(startProjX, startProjY);
                Vector2 projTarget = new Vector2(Globals.mouse.newMousePos.X, Globals.mouse.newMousePos.Y);

                Projectile2d proj = new Fireball(startProjPos, this, projTarget);

                GameGlobals.PassProjectile(proj);
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