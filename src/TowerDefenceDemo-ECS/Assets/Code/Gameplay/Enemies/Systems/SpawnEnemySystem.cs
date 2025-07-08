using Entitas;
using UnityEngine;
using Zenject;

namespace Code.Gameplay.Enemies.Systems
{
    public class SpawnEnemySystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _entities;
        private readonly IEnemyFactory _enemyFactory;

        [Inject]
        public SpawnEnemySystem(IEnemyFactory enemyFactory, GameContext game)
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