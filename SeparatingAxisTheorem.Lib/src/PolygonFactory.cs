using Microsoft.Xna.Framework;

namespace Halfcut.SeparatingAxisTheorem.Lib; 

public static class PolygonFactory {
    
    public static Polygon CreateRectangle(int x, int y, int width, int height) {
        return CreateRectangle(x, y, width, height, 0);
    }
        
    public static Polygon CreateRectangle(int x, int y, int width, int height, float angle) {
        Vector2 origin = new Vector2(width * .5f, height * .5f);
        return CreateRectangle(x, y, width, height, angle, origin);
    }
        
    public static Polygon CreateRectangle(int x, int y, int width, int height, float angle, Vector2 origin) {
        return new Polygon(
            new [] {
                new Vector2(x, y),
                new Vector2(x + width, y),
                new Vector2(x + width, y + height),
                new Vector2(x, y + height)
            },
            origin,
            angle
        );
    }
    
}