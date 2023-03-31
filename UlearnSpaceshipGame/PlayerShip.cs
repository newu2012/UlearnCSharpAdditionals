using System;
using Quaternion = Microsoft.Xna.Framework.Quaternion;
using Vector2 = Microsoft.Xna.Framework.Vector2;

namespace UlearnSpaceshipGame;

public class PlayerShip : Entity
{
    private static PlayerShip instance;
    const float speed = 8;
    private const int cooldownFrames = 12;
    private int cooldownRemaining = 0;
    private static Random rand = new(); 
    
    public static PlayerShip Instance => instance ??= new PlayerShip();

    private PlayerShip()
    {
        image = Art.Player;
        Position = GameRoot.ScreenSize / 2;
        Radius = 10;
    }

    public override void Update()
    {
        Move();
        Shoot();
    }

    private void Move()
    {
        Velocity = speed * Input.GetMovementDirection();
        Position += Velocity;
        Position = Vector2.Clamp(Position, Size / 2, GameRoot.ScreenSize - Size / 2);

        if (Velocity.LengthSquared() > 0)
            Orientation = Velocity.ToAngle();
    }

    private void Shoot()
    {
        var aim = Input.GetAimDirection();

        if (aim.LengthSquared() > 0 && cooldownRemaining <= 0)
        {
            cooldownRemaining = cooldownFrames;
            var aimAngle = aim.ToAngle();
            var aimQuaternion = Quaternion.CreateFromYawPitchRoll(0, 0, aimAngle);

            var randomSpread = rand.NextFloat(-0.04f, 0.04f) + rand.NextFloat(-0.04f, 0.04f);
            var velocity = MathUtil.FromPolar(aimAngle + randomSpread, 11f);

            AddNewBullet(aimQuaternion, velocity, new Vector2(25, -8));
            AddNewBullet(aimQuaternion, velocity, new Vector2(25, 8));
        }

        if (cooldownRemaining > 0)
            cooldownRemaining--;
    }

    private void AddNewBullet(Quaternion aimQuaternion, Vector2 velocity, Vector2 fromPoint)
    {
        var offset = Vector2.Transform(fromPoint, aimQuaternion);
        EntityManager.Add(new Bullet(Position + offset, velocity));
    }
}