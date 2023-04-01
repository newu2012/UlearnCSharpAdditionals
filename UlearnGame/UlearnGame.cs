using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace UlearnGame;

public class UlearnGame : Game
{
    private Texture2D coinsTexture;
    private Vector2 coinsPosition;
    private float coinsSpeed;

    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    public UlearnGame()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here
        coinsPosition = new Vector2(_graphics.PreferredBackBufferWidth / 2,
            _graphics.PreferredBackBufferHeight / 2);
        coinsSpeed = 100f;

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        // TODO: use this.Content to load your game content here
        coinsTexture = Content.Load<Texture2D>("coins");
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
            Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // TODO: Add your update logic here
        var kstate = Keyboard.GetState();

        if (kstate.IsKeyDown(Keys.Up))
            coinsPosition.Y -= coinsSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
        if (kstate.IsKeyDown(Keys.Down))
            coinsPosition.Y += coinsSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
        if (kstate.IsKeyDown(Keys.Left))
            coinsPosition.X -= coinsSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
        if (kstate.IsKeyDown(Keys.Right))
            coinsPosition.X += coinsSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
        
        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        // TODO: Add your drawing code here
        _spriteBatch.Begin();
        _spriteBatch.Draw(coinsTexture, coinsPosition, null, Color.Wheat,
            0f, new Vector2(coinsTexture.Width / 2, coinsTexture.Width / 2), Vector2.One / 10, SpriteEffects.None, 0f);
        _spriteBatch.End();

        base.Draw(gameTime);
    }
}