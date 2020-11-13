using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PolygonCollision {
    public static class DrawTools {
        
        private static readonly Texture2D texture;
        private static int LineWidth = 2;
        private static int PointSize = 4;

        static DrawTools() {
            texture = new Texture2D(Game.graphics.GraphicsDevice, 1, 1);
            texture.SetData(new []{ Color.White });
        }
        
        public static void DrawPolygon(Polygon polygon) {
            Vector2[] vertices = polygon.GetVertices();
            
            // Draw edges
            for (int i = 0; i < vertices.Length; i++) {
                Vector2 v1 = vertices[i];
                Vector2 v2 = vertices[(i + 1) % vertices.Length];
                DrawEdge(v1, v2);
            }
            
            // Draw vertices
            for (int i = 0; i < vertices.Length; i++) {
                Vector2 v1 = vertices[i];
                DrawPoint(v1);
            }
        }

        public static void DrawPoint(Vector2 v1) {
            DrawPoint(v1, Color.White);
        }
        
        public static void DrawPoint(Vector2 v1, Color colour) {
            Game.sb.Draw(
                texture, 
                new Vector2(v1.X, v1.Y), 
                new Rectangle(0, 0, PointSize, PointSize), 
                colour, 
                0, 
                new Vector2(PointSize * .5f, PointSize * .5f), 
                1f, 
                SpriteEffects.None, 
                0
            );
        }

        public static void DrawEdge(Vector2 v1, Vector2 v2) {
            DrawEdge(v1, v2, Color.DarkGray);
        }
        
        public static void DrawEdge(Vector2 v1, Vector2 v2, Color colour) {
            Vector2 diff = v1 - v2;
            float angle = (float) (Math.Atan2(diff.Y, diff.X) + Math.PI);
            float length = Vector2.Distance(v1, v2);
                
            Game.sb.Draw(
                texture, 
                new Vector2(v1.X, v1.Y), 
                new Rectangle(0, 0, (int) length, LineWidth), 
                colour, 
                angle, 
                new Vector2(0, LineWidth * .5f), 
                1f, 
                SpriteEffects.None, 
                0
            );
        }

    }
}