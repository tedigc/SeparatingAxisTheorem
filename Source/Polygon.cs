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

        public Vector2 GetVertex(int index) {
            return vertices[index];
        }
        
        public Vector2 GetEdge(int index) {
            Vector2 v1 = vertices[index];
            Vector2 v2 = vertices[(index + 1) % vertices.Length];
            return v1 - v2;
        }

        public Vector2 GetEdgeNormal(int index) {
            Vector2 edge = GetEdge(index);
            return new Vector2(edge.Y, -edge.X);
        }

    }
}