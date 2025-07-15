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
        
        public GameEntity Create(EnemyType type, Vector3 position, Quaternion rotation)
        {
            return type switch
            {
                EnemyType.Simple => CreateSimple(position, rotation),
                _ => throw new Exception($"Enemy with type {type} does not exist")
            };
        }

        private GameEntity CreateSimple(Vector3 position, Quaternion rotation)
        {
             EnemyData data = _staticDataService.GetEnemyData(EnemyType.Simple);

             return _gameContext.CreateEntity()
                 .AddId(_identifierGenerator.GetId())
                 .AddLayer(EntityLayer.Enemy)
                 .AddEntityViewPoolType(EntityViewPoolType.SimpleEnemy)
                 .AddWorldPosition(position)
                 .AddRotation(rotation)
                 .AddViewPrefab(data.Prefab)
                 .AddSpeed(data.Speed)
                 .AddReachDistance(data.ReachDistance)
                 .AddMaxHealth(data.MaxHealth)
                 .AddHealth(data.MaxHealth)
                 .AddTargetPosition(_levelDataProvider.TargetPoint.position)
                 .With(e => e.isEnemy = true)
                 .With(e => e.isAdjustTransformWithSpawnPoint = true)
                 .With(e => e.isMoving = true)
                 .With(e => e.isMovementByRigidbody = true);
        }
    }
}