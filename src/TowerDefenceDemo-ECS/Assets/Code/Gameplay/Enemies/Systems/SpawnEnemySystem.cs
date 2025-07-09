using Code.Gameplay.Enemies.Data;
using Code.Infrastructure;
using Code.StaticData;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Enemies.Systems
{
    public class SpawnEnemySystem : IExecuteSystem
    {
        private readonly IEnemyFactory _enemyFactory;
        private readonly IGroup<GameEntity> _entities;

        private float _interval;
        private EnemyType _enemyType;
        private Vector3 _spawnPosition;
        
        public SpawnEnemySystem(IEnemyFactory enemyFactory,
            IStaticDataService staticDataService,
            LevelDataProvider levelDataProvider,
            GameContext gameContext)
        {
            _enemyFactory = enemyFactory;
            
            _entities = gameContext.GetGroup(GameMatcher
                .AllOf(GameMatcher.EnemySpawnTimer));
            
            SetData(staticDataService, levelDataProvider);
        }

        public void Execute()
        {
            foreach (GameEntity entity in _entities)
            {
                if (entity.EnemySpawnTimer <= 0)
                {
                    entity.ReplaceEnemySpawnTimer(_interval);
                    
                    _enemyFactory.Create(_enemyType, _spawnPosition);
                }

                entity.ReplaceEnemySpawnTimer(entity.EnemySpawnTimer - Time.deltaTime);
            }
        }

        private void SetData(IStaticDataService staticDataService, LevelDataProvider levelDataProvider)
        {
            EnemySpawnerData data = staticDataService.GetEnemySpawnerData();
            
            _interval = data.Interval;
            _enemyType = data.EnemyType;
            _spawnPosition = levelDataProvider.SpawnPosition;
        }
    }
}