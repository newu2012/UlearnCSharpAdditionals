﻿using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace UlearnSpaceshipGame;

public static class Art
{
    public static Texture2D Player { get; private set; }
    public static Texture2D Seeker { get; private set; }
    public static Texture2D Wanderer { get; private set; }
    public static Texture2D Bullet { get; private set; }
    public static Texture2D Pointer { get; private set; }

    public static void Load(ContentManager contentManager)
    {
        Player = contentManager.Load<Texture2D>("Player");
        Seeker = contentManager.Load<Texture2D>("Seeker");
        Wanderer = contentManager.Load<Texture2D>("Wanderer");
        Bullet = contentManager.Load<Texture2D>("coiled-nail");
        Pointer = contentManager.Load<Texture2D>("Pointer");
    }
}