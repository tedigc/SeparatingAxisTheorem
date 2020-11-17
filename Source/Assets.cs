using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;

namespace PolygonCollision {
    public class Assets {
        
        private static Assets instance;
        private readonly Dictionary<string, Texture2D> textures = new Dictionary<string, Texture2D>();

        public static Assets get() {
            return instance ??= new Assets();
        }

        public void SetTexture(string key, Texture2D value) {
            textures.Add(key, value);
        }

        public Texture2D GetTexture(string key) {
            return textures[key];
        }
        
    }
}