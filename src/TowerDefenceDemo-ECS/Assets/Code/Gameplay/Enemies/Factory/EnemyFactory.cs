using System;
using Code.Common;
using Code.Common.Extensions;
using Code.Gameplay.Enemies.Data;
using Code.Infrastructure;
using Code.Infrastructure.Identifiers;
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
        private readonly IIdentifierGenerator _identifierGenerator;

        public EnemyFactory(GameContext gameContext,
            IStaticDataService staticDataService,
            LevelDataProvider levelDataProvider,
            IIdentifierGenerator identifierGenerator)
        {
            _gameContext = gameContext;
            _staticDataService = staticDataService;
            _levelDataProvider = levelDataProvider;
            _identifierGenerator = identifierGenerator;
        }
        
        public GameEntity Create(EnemyType type, Vector3 position)
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
                 .AddId(_identifierGenerator.GetId())
                 .AddLayer(EntityLayer.Enemy)
                 .AddWorldPosition(position)
                 .AddViewPrefab(data.Prefab)
                 .AddSpeed(data.Speed)
                 .AddReachDistance(data.ReachDistance)
                 .AddFinishPosition(_levelDataProvider.TargetPosition)
                 .With(e => e.isEnemy = true)
                 .With(e => e.isMoving = true);
             
            return entity;
        }
    }
}