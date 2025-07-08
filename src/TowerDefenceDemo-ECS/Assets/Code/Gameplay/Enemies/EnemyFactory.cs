using System;
using Code.Common.Extensions;
using Code.Gameplay.Enemies.Data;
using Code.Infrastructure;
using Code.Infrastructure.View;
using Code.StaticData;
using UnityEngine;

namespace Code.Gameplay.Enemies
{
    public class EnemyFactory : IEnemyFactory
    {
        private readonly GameContext _gameContext;
        private readonly IStaticDataService _staticDataService;
        private readonly LevelDataProvider _levelDataProvider;

        public EnemyFactory(GameContext gameContext,
            IStaticDataService staticDataService,
            LevelDataProvider levelDataProvider)
        {
            _gameContext = gameContext;
            _staticDataService = staticDataService;
            _levelDataProvider = levelDataProvider;
        }
        
        public GameEntity CreateEnemy(EnemyType type, Vector3 position)
        {
            return type switch
            {
                EnemyType.Simple => CreateSimple(position),
                _ => throw new Exception($"Enemy with type {type} does not exist")
            };
        }

        private GameEntity CreateSimple(Vector3 position)
        {
             EnemyData data = _staticDataService.GetEnemyData(EnemyType.Simple);

             GameEntity entity = _gameContext.CreateEntity()
                 .AddSpeed(data.Speed)
                 .AddReachDistance(data.ReachDistance)
                 .AddWorldPosition(position)
                 .AddTargetPosition(_levelDataProvider.TargetPosition)
                 .With(e => e.isEnemy = true)
                 .With(e => e.isMoving = true);

             EntityView view = UnityEngine.Object.Instantiate(data.View, entity.WorldPosition, Quaternion.identity);
             
             view.SetEntity(entity);
            
            return entity;
        }
    }
}