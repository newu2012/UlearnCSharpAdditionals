using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace UlearnSpaceshipGame;

public static class Input
{
    private static KeyboardState keyboardState, lastKeyboardState;
    private static MouseState mouseState, lastMouseState;
    private static bool isAimingWithMouse = false;

    public static Vector2 MousePosition => new Vector2(mouseState.X, mouseState.Y);

    public static void Update()
    {
        lastKeyboardState = keyboardState;
        lastMouseState = mouseState;

        keyboardState = Keyboard.GetState();
        mouseState = Mouse.GetState();

        if (new[] { Keys.Left, Keys.Right, Keys.Up, Keys.Down }.Any(key => keyboardState.IsKeyDown(key)))
            isAimingWithMouse = false;
        else if (MousePosition != new Vector2(lastMouseState.X, lastMouseState.Y))
            isAimingWithMouse = true;
    }

    public static bool WasKeyPressed(Keys key) => lastKeyboardState.IsKeyUp(key) && keyboardState.IsKeyDown(key);

    public static Vector2 GetMovementDirection()
    {
        var direction = Vector2.Zero;

        if (keyboardState.IsKeyDown(Keys.A))
            direction.X -= 1;
        if (keyboardState.IsKeyDown(Keys.D))
            direction.X += 1;
        if (keyboardState.IsKeyDown(Keys.W))
            direction.Y -= 1;
        if (keyboardState.IsKeyDown(Keys.S))
            direction.Y += 1;

        if (direction.LengthSquared() > 1)
            direction.Normalize();

        return direction;
    }

    public static Vector2 GetAimDirection()
    {
        if (isAimingWithMouse)
            return GetMouseAimDirection();

        var direction = Vector2.Zero;
        
        if (keyboardState.IsKeyDown(Keys.Left))
            direction.X -= 1;
        if (keyboardState.IsKeyDown(Keys.Right))
            direction.X += 1;
        if (keyboardState.IsKeyDown(Keys.Up))
            direction.Y -= 1;
        if (keyboardState.IsKeyDown(Keys.Down))
            direction.Y += 1;
        
        direction = MousePosition - PlayerShip.Instance.Position;
        return direction == Vector2.Zero ? Vector2.Zero : Vector2.Normalize(direction);
    }

    private static Vector2 GetMouseAimDirection()
    {
        var direction = MousePosition - PlayerShip.Instance.Position;
        return direction == Vector2.Zero ? Vector2.Zero : Vector2.Normalize(direction);
    }
}