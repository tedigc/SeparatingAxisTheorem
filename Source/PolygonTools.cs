using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace PolygonCollision {
    public static class PolygonTools {
        
        public static bool Intersect(Shape shape1, Shape shape2) {
            if(shape1.GetType() == typeof(Polygon) && shape2.GetType() == typeof(Polygon)) {
                return Intersect((Polygon) shape1, (Polygon) shape2);
            }

            if (shape1.GetType() == typeof(Polygon) && shape2.GetType() == typeof(Circle)) {
                return Intersect((Polygon) shape1, (Circle) shape2);
            }
            
            if (shape1.GetType() == typeof(Circle) && shape2.GetType() == typeof(Polygon)) {
                return Intersect((Polygon) shape2, (Circle) shape1);
            }
            
            if (shape1.GetType() == typeof(Circle) && shape2.GetType() == typeof(Circle)) {
                return Intersect((Circle) shape1, (Circle) shape2);
            }

            Console.WriteLine("Warning: shape types not recognised");
            return false;
        }
        
        private static bool Intersect(Circle circle1, Circle circle2) {
            Vector2 dv = circle2.GetPosition() - circle1.GetPosition();
            return dv.X * dv.X + dv.Y * dv.Y <= MathF.Pow(circle1.GetRadius() + circle2.GetRadius(), 2);
        }

        private static bool Intersect(Polygon polygon, Circle circle) {
            List<Vector2> normals = new List<Vector2>();
            normals.AddRange(polygon.GetEdgeNormals());
            normals.Add(GetPolygonCircleAxis(polygon, circle));
            foreach (Vector2 axis in normals) {
                var (min1, max1) = GetMinMaxProjections(polygon, axis);
                var (min2, max2) = GetMinMaxProjections(circle, axis);
                float intervalDistance = min1 < min2 ? min2 - max1 : min1 - max2;
                if (intervalDistance >= 0) return false;
            }
            return true;
        }

        private static bool Intersect(Polygon polygon1, Polygon polygon2) {
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
        
        private static (float, float) GetMinMaxProjections(Circle circle, Vector2 axis) {
            Vector2 v1 = circle.GetPosition() - Vector2.Normalize(axis) * circle.GetRadius(); 
            Vector2 v2 = circle.GetPosition() + Vector2.Normalize(axis) * circle.GetRadius();
            Vector2 p1 = Project(v1, axis);
            Vector2 p2 = Project(v2, axis);
            float s1 = Scalar(p1, axis);
            float s2 = Scalar(p2, axis);
            return (s1 > s2) ? (s2, s1) : (s1, s2);
        }

        private static Vector2 Project(Vector2 vertex, Vector2 axis) {
            float dot = Vector2.Dot(vertex, axis);
            float mag2 = axis.LengthSquared();
            return dot / mag2 * axis;
        }

        private static float Scalar(Vector2 vertex, Vector2 axis) {
            return Vector2.Dot(vertex, axis);
        }

        private static Vector2 GetPolygonCircleAxis(Polygon polygon, Circle circle) {
            Vector2 nearestVertex = FindClosestVertex(polygon, circle.GetPosition());
            Vector2 axis = circle.GetPosition() - nearestVertex;
            Vector2 perp = new Vector2(axis.Y, -axis.X);
            return perp;
        }

        private static Vector2 FindClosestVertex(Polygon polygon, Vector2 vertex) {
            float shortestDistance = Int32.MaxValue;
            Vector2 closestVertex = polygon.GetVertex(0);
            foreach (Vector2 polygonVertex in polygon.GetVertices()) {
                float currentDistance = Vector2.DistanceSquared(vertex, polygonVertex);
                if (currentDistance < shortestDistance) {
                    closestVertex = polygonVertex;
                    shortestDistance = currentDistance;
                }
            }
            return closestVertex;
        }

    }
}