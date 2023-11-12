using Microsoft.Xna.Framework;

namespace Halfcut.SatTheorem.Lib; 

public class Circle : Shape {

    private Vector2 _position;
    private float _radius;

    public Circle(Vector2 position, float radius) {
        _position = position;
        _radius = radius;
    }

    public Vector2 GetPosition() {
        return _position;
    }

    public float GetRadius() {
        return _radius;
    }

    public void SetPosition(float x, float y) {
        _position.X = x;
        _position.Y = y;
    }

}