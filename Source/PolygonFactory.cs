using Microsoft.Xna.Framework;

namespace PolygonCollision {
    public static class PolygonFactory {

        public static Polygon CreateRectangle(int x, int y, int width, int height) {
            return new Polygon(
                new [] {
                    new Vector2(x, y),
                    new Vector2(x + width, y),
                    new Vector2(x + width, y + height),
                    new Vector2(x, y + height)
                }
            );
        }
        
    }
}