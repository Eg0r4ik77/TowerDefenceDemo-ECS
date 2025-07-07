using Code.Common;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Enemies.Systems
{
    public class SpawnEnemySystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _entities;
        private readonly TestMonster _prefab;
        private readonly Transform[] _routePoints;

        public SpawnEnemySystem(GameContext game, TestMonster prefab, Transform[] routePoints)
        {
            _prefab = prefab;
            _routePoints = routePoints;
            
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
                    
                    var enemy = Object.Instantiate(_prefab);
                    enemy.Init(_routePoints);
                    
                }

                entity.ReplaceEnemySpawnTimer(entity.EnemySpawnTimer - Time.deltaTime);
            }
        }
    }
}