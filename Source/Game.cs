using System;
using System.Numerics;
using System.Runtime.Intrinsics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Vector2 = Microsoft.Xna.Framework.Vector2;

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
            DrawTools.DrawEdge(polygon2.GetNormal(0).Item1, polygon2.GetNormal(0).Item2, Color.DarkCyan);

            DrawTools.DrawPoint(Project(polygon1.GetVertices()[0], polygon2.GetNormal(1)), Color.Red);
            DrawTools.DrawPoint(Project(polygon1.GetVertices()[1], polygon2.GetNormal(1)), Color.Red);
            DrawTools.DrawPoint(Project(polygon1.GetVertices()[2], polygon2.GetNormal(1)), Color.Red);
            DrawTools.DrawPoint(Project(polygon1.GetVertices()[3], polygon2.GetNormal(1)), Color.Red);

            DrawTools.DrawPoint(Project(polygon2.GetVertices()[0], polygon2.GetNormal(1)), Color.Green);
            DrawTools.DrawPoint(Project(polygon2.GetVertices()[1], polygon2.GetNormal(1)), Color.Green);
            DrawTools.DrawPoint(Project(polygon2.GetVertices()[2], polygon2.GetNormal(1)), Color.Green);
            DrawTools.DrawPoint(Project(polygon2.GetVertices()[3], polygon2.GetNormal(1)), Color.Green);
            
            sb.End();
            base.Draw(gameTime);
        }

        private Vector2 Project(Vector2 v1, Tuple<Vector2, Vector2> edge) {
            Vector2 diff = Vector2.Subtract(edge.Item1, edge.Item2);
            float dot = Vector2.Dot(v1, diff);
            float mag2 = diff.LengthSquared();
            return dot / mag2 * diff;
        }

        // private Vector2 ProjectionToScalar() {
        //     
        // }

    }
}
