using Microsoft.Xna.Framework;

namespace MossBoy.Core;

internal static class Configuration
{
    public static Vector2 windowSize = new(800, 600);
    public static float playerMove = 600;
    public static float dampening = 0.80f;
    public static float bulletSpeed = 1000;
}