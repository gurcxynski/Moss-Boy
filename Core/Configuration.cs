using Microsoft.Xna.Framework;

namespace MossBoy.Core;

internal static class Configuration
{
    public static Vector2 windowSize = new(800, 600);
    public static Vector2 startPos = new(400, 500);
    public static float playerMove = 100;
    public static float dampening = 0.8f;
    public static float bulletSpeed = 2000;
    public static int EnemyVel = 120;
    public static int playerHP = 3;
    public static int playerDMG = 1;

}