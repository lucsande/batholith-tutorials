

using Microsoft.Xna.Framework;

namespace TopDownShooter
{
    public class World

    {
        public Basic2d hero;

        public World()
        {
            hero = new Hero("2D/totoro", new Vector2(300, 300), new Vector2(48, 48));
        }

        public virtual void Update()
        {
            hero.Update();
        }

        public virtual void Draw(Vector2 OFFSET)
        {
            hero.Draw(OFFSET);
        }
    }

}