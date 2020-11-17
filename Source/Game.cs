using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace PolygonCollision {
    public class Game : Microsoft.Xna.Framework.Game {
        
        private const int Width = 400;
        private const int Height = 300;
        private const string Title = "Polygon Collision";
        
        public static GraphicsDeviceManager graphics;
        public static SpriteBatch sb;

        private Polygon polygon1;
        private Polygon polygon2;
        private Circle circle1;
        
        private Vector2 position;
        private float angle;

        private const float MoveSpeed = 75f;
        private const float RotateSpeed = 0.5f;

        public Game() {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize() {
            graphics.PreferredBackBufferWidth  = Width;
            graphics.PreferredBackBufferHeight = Height;
            graphics.ApplyChanges();
            Window.Title = Title;
            base.Initialize();
        }

        protected override void LoadContent() {
            sb = new SpriteBatch(GraphicsDevice);
            Texture2D texture = Content.Load<Texture2D>("textures/circle");
            Assets.get().SetTexture("circle", texture);
            
            position = new Vector2(128, 128);
            polygon1 = PolygonFactory.CreateRectangle(128, 128, 32, 32);
            polygon2 = PolygonFactory.CreateRectangle(176, 116, 48, 48);
            circle1 = new Circle(new Vector2(50, 50), 16);
        }

        protected override void Update(GameTime gameTime) {
            float dt = gameTime.ElapsedGameTime.Milliseconds * 0.001f;
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape)) Exit();
            
            // Handle input
            if (Keyboard.GetState().IsKeyDown(Keys.D)) position.X += MoveSpeed * dt;
            if (Keyboard.GetState().IsKeyDown(Keys.A)) position.X -= MoveSpeed * dt;
            if (Keyboard.GetState().IsKeyDown(Keys.W)) position.Y -= MoveSpeed * dt;
            if (Keyboard.GetState().IsKeyDown(Keys.S)) position.Y += MoveSpeed * dt;
            
            // Update polygon
            angle += dt * RotateSpeed;
            polygon1 = PolygonFactory.CreateRectangle((int) position.X, (int) position.Y, 32, 32, angle);
            
            base.Update(gameTime);
        }
        
        protected override void Draw(GameTime gameTime) {
            GraphicsDevice.Clear(Color.Black);
            sb.Begin();
            
            bool intersecting = PolygonTools.Intersect(polygon1, polygon2);
            Color edgeColour = intersecting ? Color.Red : Color.Green;
            Color vertColour = intersecting ? Color.Pink : Color.LightGreen;
            DrawTools.DrawPolygon(polygon1, edgeColour, vertColour);
            DrawTools.DrawPolygon(polygon2, edgeColour, vertColour);
            circle1.Draw();

            sb.End();
            base.Draw(gameTime);
        }

    }
}
