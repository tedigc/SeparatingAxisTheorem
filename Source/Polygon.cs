using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PolygonCollision {
    public class Polygon {
        
        private Vector2[] vertices;

        public Polygon(Vector2[] vertices) {
            this.vertices = vertices;
        }

        public void Draw() {
            Texture2D texture = new Texture2D(Game.graphics.GraphicsDevice, 1, 1);
            texture.SetData(new []{ Color.White });
            
            for (int i = 0; i < vertices.Length; i++) {
                Vector2 v1 = vertices[i];
                Vector2 v2 = vertices[(i + 1) % vertices.Length];
                Vector2 diff = v1 - v2;
                float angle = (float) (Math.Atan2(diff.Y, diff.X) + Math.PI);
                float length = Vector2.Distance(v1, v2);
                
                Game.sb.Draw(
                    texture, 
                    new Vector2(v1.X, v1.Y), 
                    new Rectangle(0, 0, (int) length, (int) 2), 
                    Color.Gray, 
                    angle, 
                    new Vector2(0, 2), 
                    1f, 
                    SpriteEffects.None, 
                    0
                );
            }

            for (int i = 0; i < vertices.Length; i++) {
                Vector2 v1 = vertices[i];
                Game.sb.Draw(
                    texture, 
                    new Vector2(v1.X, v1.Y), 
                    new Rectangle(0, 0, 6, 6), 
                    Color.White, 
                    0, 
                    new Vector2(3, 3), 
                    1f, 
                    SpriteEffects.None, 
                    0
                );
            }
        }
        
        // colour, 
        // angle, 
        // origin,
        // 1f, 
        // SpriteEffects.None, 
        // 0
        
    }
}