using UnityEngine;

namespace Code.Gameplay.Enemies
{
    public interface IEnemyFactory
    {
        public GameEntity CreateEnemy(EnemyType type, Vector3 position);
    }
}