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
            
            polygon1 = new Polygon(new Vector2[] {
                new Vector2(180, 180), 
                new Vector2(220, 180), 
                new Vector2(220, 220), 
                new Vector2(180, 220), 
            });
            
            polygon2 = new Polygon(new Vector2[] {
                new Vector2(64, 64), 
                new Vector2(96, 32), 
                new Vector2(154, 64),
                new Vector2(128, 128),
                new Vector2(96, 164),
                new Vector2(54, 128), 
            });
        }

        protected override void Update(GameTime gameTime) {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape)) Exit();
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime) {
            GraphicsDevice.Clear(Color.Black);
            sb.Begin();

            DrawTools.DrawEdge(polygon2.GetNormal(0).Item1, polygon2.GetNormal(0).Item2, Color.DarkCyan);
            DrawTools.DrawEdge(polygon2.GetNormal(1).Item1, polygon2.GetNormal(1).Item2, Color.DarkCyan);
            DrawTools.DrawEdge(polygon2.GetNormal(2).Item1, polygon2.GetNormal(2).Item2, Color.DarkCyan);
            DrawTools.DrawEdge(polygon2.GetNormal(3).Item1, polygon2.GetNormal(3).Item2, Color.DarkCyan);
            DrawTools.DrawPolygon(polygon1);
            DrawTools.DrawPolygon(polygon2);
            
            sb.End();
            base.Draw(gameTime);
        }



    }
}
