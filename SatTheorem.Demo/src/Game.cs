using Halfcut.SatTheorem.Lib;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Halfcut.SatTheorem.Demo;

public class Game : Microsoft.Xna.Framework.Game {
    
    private const string Title       = "Halfcut.SatTheorem.Demo";
    private const int    Width       = 400;
    private const int    Height      = 300;
    private const float  MoveSpeed   = 75f;
    private const float  RotateSpeed = 0.5f;
    
    public static GraphicsDeviceManager Graphics;
    public static SpriteBatch SpriteBatch;

    private Polygon _polygon1;
    private Polygon _polygon2;
    private Vector2 _position;
    private float   _angle;

    public Game() {
        Graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize() {
        Graphics.PreferredBackBufferWidth  = Width;
        Graphics.PreferredBackBufferHeight = Height;
        Graphics.ApplyChanges();
        Window.Title = Title;
        base.Initialize();
    }

    protected override void LoadContent() {
        SpriteBatch = new SpriteBatch(GraphicsDevice);

        _position = new Vector2(128, 128);
        _polygon1 = PolygonFactory.CreateRectangle(128, 128, 32, 32);
        _polygon2 = new Polygon(new[] {
            new Vector2(_position.X, _position.Y),
            new Vector2(_position.X + 32, _position.Y),
            new Vector2(_position.X + 64, _position.Y + 16),
            new Vector2(_position.X + 32, _position.Y + 32),
            new Vector2(_position.X, _position.Y + 32),
        }, new Vector2(48, 16));
    }

    protected override void Update(GameTime gameTime) {
        float dt = gameTime.ElapsedGameTime.Milliseconds * 0.001f;

        if (Keyboard.GetState().IsKeyDown(Keys.Escape)) {
            Exit();
        }
            
        // Handle input
        if (Keyboard.GetState().IsKeyDown(Keys.D)) _position.X += MoveSpeed * dt;
        if (Keyboard.GetState().IsKeyDown(Keys.A)) _position.X -= MoveSpeed * dt;
        if (Keyboard.GetState().IsKeyDown(Keys.W)) _position.Y -= MoveSpeed * dt;
        if (Keyboard.GetState().IsKeyDown(Keys.S)) _position.Y += MoveSpeed * dt;
            
        // Update polygon
        _angle += dt * RotateSpeed;
        _polygon1.SetPosition(_position);
        _polygon1.SetAngle(_angle);
        _polygon2.SetAngle(-_angle);
    }

    protected override void Draw(GameTime gameTime) {
        GraphicsDevice.Clear(Color.Black);
        SpriteBatch.Begin();
            
        bool intersecting = _polygon1.IntersectsWith(_polygon2);
        Color edgeColour = intersecting ? Color.Red : Color.Green;
        Color vertColour = intersecting ? Color.Pink : Color.LightGreen;
        Renderer.DrawPolygon(_polygon1, edgeColour, vertColour);
        Renderer.DrawPolygon(_polygon2, edgeColour, vertColour);

        SpriteBatch.End();
        base.Draw(gameTime);
    }
    
}
