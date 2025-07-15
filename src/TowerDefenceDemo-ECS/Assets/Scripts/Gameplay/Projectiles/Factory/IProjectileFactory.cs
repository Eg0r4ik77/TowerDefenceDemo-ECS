using UnityEngine;

namespace Gameplay.Projectiles.Factory
{
    public interface IProjectileFactory
    {
        public GameEntity Create(ProjectileType type, Vector3 position);
    }
}