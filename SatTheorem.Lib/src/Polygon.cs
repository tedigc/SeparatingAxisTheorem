using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;

namespace Halfcut.SatTheorem.Lib; 

public class Polygon : Shape {
        
    private readonly Vector2[] _vertices;
    private float _angle;
    private Vector2 _originalPosition;
    private readonly Vector2 _origin;
    private readonly int _edgeCount;

    public Polygon(Vector2[] vertices, Vector2 origin) : this(vertices, origin, 0) { }
    public Polygon(Vector2[] vertices, Vector2 origin = new Vector2(), float angle = 0) {
        _origin = origin;
        _vertices = vertices.Select(vertex => vertex - origin).ToArray();
        _originalPosition = _vertices[0];
        _edgeCount = vertices.Length;
        SetAngle(angle);
    }


    public Vector2[] GetVertices() {
        return _vertices;
    }

    public Vector2 GetVertex(int index) {
        return _vertices[index];
    }
    
    public Vector2 GetEdge(int index) {
        Vector2 v1 = _vertices[index];
        Vector2 v2 = _vertices[(index + 1) % _vertices.Length];
        return v1 - v2;
    }

    public Vector2 GetEdgeNormal(int index) {
        Vector2 edge = GetEdge(index);
        return new Vector2(edge.Y, -edge.X);
    }

    public List<Vector2> GetEdges() {
        List<Vector2> edges = new List<Vector2>();
        for (int i = 0; i < _edgeCount; i++) {
            edges.Add(GetEdge(i));
        }
        return edges;
    }
    
    public List<Vector2> GetEdgeNormals() {
        List<Vector2> normals = new List<Vector2>();
        for (int i = 0; i < _edgeCount; i++) {
            normals.Add(GetEdgeNormal(i));
        }
        return normals;
    }

    public void SetPosition(Vector2 position) {
        Vector2 diff = position - (_originalPosition + _origin);
        
        for(int i = 0; i < _vertices.Length; i++) {
            _vertices[i] += diff;
        }

        _originalPosition += diff;
    }

    public void SetAngle(float angle) {
        float diff = angle - _angle;
        _angle = angle;

        Vector2 offset = _originalPosition + _origin;

        for (int i = 0; i < _vertices.Length; i++) {
            _vertices[i] = Vector2.Transform(_vertices[i] - offset, Matrix.CreateRotationZ(diff)) + offset;
        }
    }

    public Vector2 GetOrigin() {
        return _origin;
    }

    public Vector2 GetPosition() {
        return _originalPosition + _origin;
    }

}