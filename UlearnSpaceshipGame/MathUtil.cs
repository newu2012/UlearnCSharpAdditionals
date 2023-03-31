using System;
using Microsoft.Xna.Framework;

namespace UlearnSpaceshipGame;

public static class MathUtil
{
    public static Vector2 FromPolar(float angle, float magnitude) =>
        magnitude * new Vector2((float)Math.Cos(angle), (float)Math.Sin(angle));
}