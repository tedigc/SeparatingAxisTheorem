using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;

namespace PolygonCollision {
    public class Polygon {
        
        private readonly Vector2[] vertices;
        private Vector2 origin;
        public readonly int EdgeCount;

        public Polygon(Vector2[] vertices, Vector2 origin, float angle) {
            this.origin = origin;
            this.vertices = vertices.Select(vertex => Vector2.Transform(vertex - origin, Matrix.CreateRotationZ(angle)) + origin).ToArray();
            EdgeCount = vertices.Length;
        }
        
        public Polygon(Vector2[] vertices) {
            this.vertices = vertices;
            EdgeCount = vertices.Length;
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

        public List<Vector2> GetEdges() {
            List<Vector2> edges = new List<Vector2>();
            for (int i = 0; i < EdgeCount; i++) {
                edges.Add(GetEdge(i));
            }
            return edges;
        }
        
        public List<Vector2> GetEdgeNormals() {
            List<Vector2> normals = new List<Vector2>();
            for (int i = 0; i < EdgeCount; i++) {
                normals.Add(GetEdgeNormal(i));
            }
            return normals;
        }

    }
}