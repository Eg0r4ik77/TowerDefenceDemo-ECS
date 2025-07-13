using Entitas;

namespace Code.Gameplay.Projectiles
{
    [Game] public class CannonProjectile : IComponent { }
    [Game] public class DistanceBeforeDeparture : IComponent{ public float Value; }
}