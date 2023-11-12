using System;
using Halfcut.SeparatingAxisTheorem.Lib;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Halfcut.SeparatingAxisTheorem.Demo;

public static class Renderer {
        
    private static readonly Texture2D _texture;
    private static int LineWidth = 2;
    private static int PointSize = 4;

    static Renderer() {
        _texture = new Texture2D(Game.Graphics.GraphicsDevice, 1, 1);
        _texture.SetData(new []{ Color.White });
    }
    
    public static void DrawPolygon(Polygon polygon) {
        DrawPolygon(polygon, Color.DarkGray, Color.LightGray);
    }
    
    public static void DrawPolygon(Polygon polygon, Color edgeColour, Color vertColour) {
        Vector2[] vertices = polygon.GetVertices();
        
        // Draw edges
        for (int i = 0; i < vertices.Length; i++) {
            Vector2 v1 = vertices[i];
            Vector2 v2 = vertices[(i + 1) % vertices.Length];
            DrawEdge(v1, v2, edgeColour);
        }
        
        // Draw vertices
        for (int i = 0; i < vertices.Length; i++) {
            Vector2 v1 = vertices[i];
            DrawPoint(v1, vertColour);
        }
        
        // Draw origin
        DrawPoint(polygon.GetPosition(), vertColour);
    }

    public static void DrawPoint(Vector2 v1) {
        DrawPoint(v1, Color.White);
    }
    
    public static void DrawPoint(Vector2 v1, Color colour) {
        Game.SpriteBatch.Draw(
            _texture, 
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
            
        Game.SpriteBatch.Draw(
            _texture, 
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