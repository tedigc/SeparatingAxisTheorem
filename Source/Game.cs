using System;
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
            polygon1 = PolygonFactory.CreateRectangle(128, 128, 32, 32);
            polygon2 = PolygonFactory.CreateRectangle(176, 116, 48, 48);
            Console.WriteLine(PolygonTools.Intersect(polygon1, polygon2));
        }

        protected override void Update(GameTime gameTime) {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape)) Exit();
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime) {
            GraphicsDevice.Clear(Color.Black);
            sb.Begin();
            
            DrawTools.DrawPolygon(polygon1);
            DrawTools.DrawPolygon(polygon2);

            sb.End();
            base.Draw(gameTime);
        }

    }
}
