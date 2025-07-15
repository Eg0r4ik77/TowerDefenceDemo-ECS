using Entitas;
using Gameplay.Enemies.Data;
using Gameplay.Enemies.Factory;
using Gameplay.Time;
using Infrastructure;
using Infrastructure.StaticData;
using UnityEngine;

namespace Gameplay.Enemies.Systems
{
    public class SpawnEnemySystem : IExecuteSystem
    {
        private readonly IEnemyFactory _enemyFactory;
        private readonly ITimeService _timeService;
        
        private readonly IGroup<GameEntity> _entities;

        private float _interval;
        private EnemyType _enemyType;
        private Transform _spawnPoint;
        
        public SpawnEnemySystem(IEnemyFactory enemyFactory,
            ITimeService timeService,
            IStaticDataService staticDataService,
            LevelDataProvider levelDataProvider,
            GameContext gameContext)
        {
            _enemyFactory = enemyFactory;
            _timeService = timeService;

            _entities = gameContext.GetGroup(GameMatcher.EnemySpawnTimer);
            
            SetData(staticDataService, levelDataProvider);
        }

        public void Execute()
        {
            foreach (GameEntity entity in _entities)
            {
                if (entity.EnemySpawnTimer <= 0)
                {
                    entity.ReplaceEnemySpawnTimer(_interval);
                    
                    _enemyFactory.Create(_enemyType, _spawnPoint.position, _spawnPoint.rotation);
                }

                entity.ReplaceEnemySpawnTimer(entity.EnemySpawnTimer - _timeService.DeltaTime);
            }
        }

        private void SetData(IStaticDataService staticDataService, LevelDataProvider levelDataProvider)
        {
            EnemySpawnerData data = staticDataService.GetEnemySpawnerData();
            
            _interval = data.Interval;
            _enemyType = data.EnemyType;
            _spawnPoint = levelDataProvider.SpawnPoint;
        }
    }
}