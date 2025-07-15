using UnityEngine;

namespace Gameplay.Enemies.Factory
{
    public interface IEnemyFactory
    {
        public GameEntity Create(EnemyType type, Vector3 position, Quaternion rotation);
    }
}