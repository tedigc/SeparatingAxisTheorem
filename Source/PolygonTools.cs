using Microsoft.Xna.Framework;

namespace PolygonCollision {
    public static class PolygonTools {
        
        public static Vector2 Project(Vector2 v1, Vector2 edge) {
            float dot = Vector2.Dot(v1, edge);
            float mag2 = edge.LengthSquared();
            return dot / mag2 * edge;
        }
        
    }
}