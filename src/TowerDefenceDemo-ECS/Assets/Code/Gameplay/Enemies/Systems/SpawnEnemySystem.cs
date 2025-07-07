using Code.Common;
using Entitas;
using UnityEngine;
using VContainer;

namespace Code.Gameplay.Enemies.Systems
{
    public class SpawnEnemySystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _entities;
        private readonly EnemyFactory _enemyFactory;

        [Inject]
        public SpawnEnemySystem(EnemyFactory enemyFactory, GameContext game)
        {
            _enemyFactory = enemyFactory;
            
            _entities = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.EnemySpawnTimer));
        }

        public void Execute()
        {
            foreach (GameEntity entity in _entities)
            {
                if (entity.EnemySpawnTimer <= 0)
                {
                    entity.ReplaceEnemySpawnTimer(3);
                    
                    _enemyFactory.CreateEnemy(EnemyType.Simple, Vector3.zero);
                }

                entity.ReplaceEnemySpawnTimer(entity.EnemySpawnTimer - Time.deltaTime);
            }
        }
    }
}