using UnityEngine;

namespace Code.Gameplay.Enemies
{
    public interface IEnemyFactory
    {
        GameEntity CreateEnemy(EnemyType type, Vector3 position);
    }
}