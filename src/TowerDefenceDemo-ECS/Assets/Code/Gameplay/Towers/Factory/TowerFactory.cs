using System;
using Code.Common;
using Code.Common.Extensions;
using Code.Infrastructure.Identifiers;
using Code.StaticData;
using UnityEngine;

namespace Code.Gameplay.Towers.Factory
{
    public class TowerFactory : ITowerFactory
    {
        private readonly GameContext _gameContext;
        private readonly IStaticDataService _staticDataService;
        private readonly IIdentifierGenerator _identifierGenerator;

        public TowerFactory(GameContext gameContext,
            IStaticDataService staticDataService,
            IIdentifierGenerator identifierGenerator)
        {
            _gameContext = gameContext;
            _staticDataService = staticDataService;
            _identifierGenerator = identifierGenerator;
        }
        
        public GameEntity Create(TowerType type, Vector3 position)
        {
            return type switch
            {
                TowerType.Simple => CreateSimple(position),
                TowerType.Cannon => CreateCannon(position),
                _ => throw new Exception($"Enemy with type {type} does not exist")
            };
        }

        private GameEntity CreateSimple(Vector3 position)
        {
            TowerData data = _staticDataService.GetTowerData(TowerType.Simple);

            GameEntity entity = _gameContext.CreateEntity()
                .AddId(_identifierGenerator.GetId())
                .AddWorldPosition(position)
                .AddViewPrefab(data.Prefab)
                .AddTargetDetectionInterval(data.TargetDetectionInterval)
                .AddTargetDetectionTimer(data.TargetDetectionInterval)
                .AddTargetDetectionDistance(data.TargetDetectionDistance)
                .AddTargetDetectionLayerMask(EntityLayer.Enemy.AsMask())
                .With(e => e.isNeedForDetection = true)
                .With(e => e.isReadyForDetection = true)
                .With(e => e.isFollowingTarget = true);
            
            return entity;
        }
        
        private GameEntity CreateCannon(Vector3 position)
        {
            return _gameContext.CreateEntity();
        }
    }
}