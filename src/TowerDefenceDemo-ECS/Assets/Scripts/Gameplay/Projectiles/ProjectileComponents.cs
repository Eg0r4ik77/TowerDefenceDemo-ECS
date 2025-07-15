using Entitas;

namespace Gameplay.Projectiles
{
    [Game] public class CannonProjectile : IComponent { }
    [Game] public class DistanceBeforeDeparture : IComponent{ public float Value; }
}