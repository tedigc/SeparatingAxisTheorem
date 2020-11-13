using System;
using Microsoft.Xna.Framework;

namespace PolygonCollision {
    public class Polygon {
        
        private const int NormalLength = 24;
        private readonly Vector2[] vertices;

        public Polygon(Vector2[] vertices) {
            this.vertices = vertices;
        }

        public Vector2[] GetVertices() {
            return vertices;
        }

        public Tuple<Vector2, Vector2> GetEdge(int index) {
            return Tuple.Create(vertices[index], vertices[(index + 1) % vertices.Length]);
        }
        
        public Tuple<Vector2, Vector2> GetNormal(int index) {
            Tuple<Vector2, Vector2> edge = GetEdge(index);
            Vector2 v1 = edge.Item1;
            Vector2 v2 = edge.Item2;
            Vector2 diff = Vector2.Normalize(Vector2.Subtract(v1, v2)) * NormalLength;
            Vector2 v3 = new Vector2(v1.X - diff.Y, v1.Y + diff.X);
            return Tuple.Create(v1, v3);
        }

    }
}