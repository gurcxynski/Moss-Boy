using Microsoft.Xna.Framework;

namespace PlatformerGame.Core
{
    internal static class Configuration
    {
        public static Vector2 windowSize = new(800, 600);
        public static float gravity = 2f;
        public static float playerJump = 60;
        public static float playerMove = 10;
        public static float dampening = 0.90f;

    }
}