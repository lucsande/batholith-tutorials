using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TopDownShooter;

public class Main : Game
{
    private GraphicsDeviceManager _graphics;
    // private SpriteBatch _spriteBatch;

    World world;

    public Main()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here

        base.Initialize();
    }

    protected override void LoadContent()
    {
        Globals.content = this.Content;
        Globals.spriteBatch = new SpriteBatch(GraphicsDevice);
        Globals.keyboard = new McKeyboard();

        world = new World();

        // TODO: use this.Content to load your game content here
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        Globals.keyboard.Update();

        // TODO: Add your update logic here
        world.Update();

        Globals.keyboard.UpdateOld();

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);


        Globals.spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend);

        // TODO: Add your drawing code here



        world.Draw();



        Globals.spriteBatch.End();


        base.Draw(gameTime);
    }
}
