using Microsoft.Xna.Framework;

namespace PolygonCollision {
    public class Polygon {
        
        private readonly Vector2[] vertices;

        public Polygon(Vector2[] vertices) {
            this.vertices = vertices;
        }

        public Vector2[] GetVertices() {
            return vertices;
        }
        
    }
}