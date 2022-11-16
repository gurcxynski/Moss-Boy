using Microsoft.Xna.Framework;

namespace PlatformerGame.Core
{
    internal static class Configuration
    {
        public static Vector2 windowSize = new(800, 600);
        public static float gravity = 5;
        public static float playerJump = 50;
        public static float playerMove = 5;
        public static float dampening = 0.95f;

    }
}