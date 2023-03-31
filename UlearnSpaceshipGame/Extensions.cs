using System;
using Microsoft.Xna.Framework;

namespace UlearnSpaceshipGame;

public static class Extensions
{
    public static float ToAngle(this Vector2 vector) => (float)Math.Atan2(vector.Y, vector.X);

    public static float NextFloat(this Random rand, float minValue, float maxValue) =>
        (float)rand.NextDouble() * (maxValue - minValue) + minValue;
}