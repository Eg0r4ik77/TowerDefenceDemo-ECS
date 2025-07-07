using Code.Common;
using Code.Gameplay.Enemies.Systems;
using UnityEngine;

namespace Code.Gameplay.Enemies
{
    public class EnemyFeature : Feature
    {
        public EnemyFeature(EnemyFactory enemyFactory, GameContext gameContext)
        {
            Add(new InitializeEnemySpawnTimerSystem());
            Add(new SpawnEnemySystem(enemyFactory, gameContext));
        }
    }
}