using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;

namespace PolygonCollision {
    public class Polygon : Shape {
        
        private readonly Vector2[] vertices;
        private float angle;
        private Vector2 originalPosition;
        private readonly Vector2 origin;
        private readonly int edgeCount;

        public Polygon(Vector2[] vertices, Vector2 origin) : this(vertices, origin, 0) { }
        public Polygon(Vector2[] vertices, Vector2 origin = new Vector2(), float angle = 0) {
            this.origin = origin;
            this.vertices = vertices.Select(vertex => vertex - origin).ToArray();
            this.originalPosition = this.vertices[0];
            edgeCount = vertices.Length;
            SetAngle(angle);
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
            for (int i = 0; i < edgeCount; i++) {
                edges.Add(GetEdge(i));
            }
            return edges;
        }
        
        public List<Vector2> GetEdgeNormals() {
            List<Vector2> normals = new List<Vector2>();
            for (int i = 0; i < edgeCount; i++) {
                normals.Add(GetEdgeNormal(i));
            }
            return normals;
        }

        public void SetPosition(Vector2 position) {
            Vector2 diff = position - (originalPosition + origin);
            
            for(int i = 0; i < vertices.Length; i++) {
                vertices[i] += diff;
            }

            originalPosition += diff;
        }

        public void SetAngle(float angle) {
            float diff = angle - this.angle;
            this.angle = angle;

            Vector2 offset = originalPosition + origin;

            for (int i = 0; i < vertices.Length; i++) {
                vertices[i] = Vector2.Transform(vertices[i] - offset, Matrix.CreateRotationZ(diff)) + offset;
            }
        }

        public Vector2 GetOrigin() {
            return origin;
        }

        public Vector2 GetPosition() {
            return originalPosition + origin;
        }

    }
}