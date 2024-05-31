using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TopDownShooter;

public class Main : Game
{
    private GraphicsDeviceManager graphics;
    // private SpriteBatch _spriteBatch;

    World world;
    Basic2d cursor;

    public Main()
    {
        graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = false;
    }

    protected override void Initialize()
    {
        Globals.screenWidth = 800; // 1800;
        Globals.screenHeight = 480;// 900;

        graphics.PreferredBackBufferWidth = Globals.screenWidth;
        graphics.PreferredBackBufferHeight = Globals.screenHeight;
        // graphics.ApplyChanges();
        // TODO: Add your initialization logic here

        base.Initialize();
    }

    protected override void LoadContent()
    {
        Globals.content = this.Content;
        Globals.spriteBatch = new SpriteBatch(GraphicsDevice);

        cursor = new Basic2d("2D/Misc/mouse", new Vector2(0, 0), new Vector2(18, 18));
        Globals.keyboard = new McKeyboard();
        Globals.mouse = new McMouseControl();

        world = new World();


        // TODO: use this.Content to load your game content here
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        Globals.gameTime = gameTime; // ms since last frame

        Globals.keyboard.Update();
        Globals.mouse.Update();

        // TODO: Add your update logic here
        world.Update();

        Globals.keyboard.UpdateOld();
        Globals.mouse.UpdateOld();

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.Lerp(Color.LightGoldenrodYellow, Color.LightGreen, 0.20f));


        Globals.spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend);

        // TODO: Add your drawing code here

        world.Draw(Vector2.Zero);

        Vector2 cursorOffset = new Vector2(Globals.mouse.newMousePos.X, Globals.mouse.newMousePos.Y);
        cursor.Draw(cursorOffset, new Vector2(0, 0));

        Globals.spriteBatch.End();


        base.Draw(gameTime);
    }
}
