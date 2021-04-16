using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PolygonCollision {
    public class Circle : Shape {

        private Texture2D texture;
        private Vector2 position;
        private float radius;

        public Circle(Vector2 position, float radius) {
            this.position = position;
            this.radius = radius;
            texture = Assets.get().GetTexture("circle");
        }

        public void Draw(Color color) {
            Game.sb.Draw(texture, new Rectangle((int) (position.X - radius), (int) (position.Y - radius), (int) radius*2, (int) radius*2), color );
        }

        public Vector2 GetPosition() {
            return position;
        }

        public float GetRadius() {
            return radius;
        }

        public void SetPosition(float x, float y) {
            position.X = x;
            position.Y = y;
        }

    }
}