using UnityEngine;

namespace Code.Gameplay.Enemies
{
    public interface IEnemyFactory
    {
        public GameEntity Create(EnemyType type, Vector3 position, Quaternion rotation);
    }
}