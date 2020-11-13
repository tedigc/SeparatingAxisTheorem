using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace PolygonCollision {
    public static class PolygonTools {

        public static bool Intersect(Polygon polygon1, Polygon polygon2) {
            List<Vector2> normals = new List<Vector2>();
            normals.AddRange(polygon1.GetEdgeNormals());
            normals.AddRange(polygon2.GetEdgeNormals());
            foreach(Vector2 axis in normals) {
                var (min1, max1) = GetMinMaxProjections(polygon1, axis);
                var (min2, max2) = GetMinMaxProjections(polygon2, axis);
                float intervalDistance = min1 < min2 ? min2 - max1 : min1 - max2;
                if (intervalDistance >= 0) return false;
            }
            return true;
        }
        
        private static (float, float) GetMinMaxProjections(Polygon polygon, Vector2 axis) {
            float min = Int32.MaxValue;
            float max = Int32.MinValue;
            foreach (Vector2 vertex in polygon.GetVertices()) {
                Vector2 projection = Project(vertex, axis);
                float scalar = Scalar(projection, axis);
                if (scalar < min) min = scalar;
                if (scalar > max) max = scalar;
            }
            return (min, max);
        }

        private static Vector2 Project(Vector2 vertex, Vector2 axis) {
            float dot = Vector2.Dot(vertex, axis);
            float mag2 = axis.LengthSquared();
            return dot / mag2 * axis;
        }

        private static float Scalar(Vector2 vertex, Vector2 axis) {
            return Vector2.Dot(vertex, axis);
        }

    }
}