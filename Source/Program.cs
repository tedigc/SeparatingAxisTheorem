using System;

namespace PolygonCollision {
    public static class Program {
        [STAThread]
        static void Main() {
            using var game = new Game();
            game.Run();
        }
    }
}
