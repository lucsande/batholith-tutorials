

using System.Collections.Generic;
using System.ComponentModel;
using Microsoft.Xna.Framework;

namespace TopDownShooter
{
    public class World
    {

        public List<Projectile2d> projectiles = new List<Projectile2d>();
        public Basic2d hero;
        public Vector2 offset;

        public World()
        {
            hero = new Hero("2D/totoro", new Vector2(300, 300), new Vector2(48, 48));

            GameGlobals.PassProjectile = AddProjectile;
        }

        public virtual void Update()
        {
            hero.Update();

            for (int i = 0; i < projectiles.Count; i++)
            {
                projectiles[i].Update(offset, null);

                if (projectiles[i].done)
                {
                    projectiles.RemoveAt(i);
                    i--;
                }
            }
        }

        public virtual void AddProjectile(object INFO)
        {
            projectiles.Add((Projectile2d)INFO);
        }

        public virtual void Draw(Vector2 OFFSET)
        {
            hero.Draw(OFFSET);

            for (int i = 0; i < projectiles.Count; i++)
            {
                projectiles[i].Draw(offset);
            }
        }
    }

}