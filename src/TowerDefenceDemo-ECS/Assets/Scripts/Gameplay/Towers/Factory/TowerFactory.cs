using System;
using Common.Extensions;
using Gameplay.Cooldowns;
using Gameplay.TargetDetection;
using Gameplay.Towers.Data;
using Infrastructure.Identifiers;
using Infrastructure.StaticData;
using UnityEngine;

namespace Gameplay.Towers.Factory
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
                _ => throw new Exception($"Tower with type {type} does not exist")
            };
        }

        private GameEntity CreateSimple(Vector3 position)
        {
            TowerData data = _staticDataService.GetTowerData(TowerType.Simple);

            return _gameContext.CreateEntity()
                .AddId(_identifierGenerator.GetId())
                .AddWorldPosition(position)
                .AddViewPrefab(data.Prefab)
                .AddTargetDetectionInterval(data.TargetDetectionInterval)
                .AddTargetDetectionTimer(data.TargetDetectionInterval)
                .AddTargetDetectionDistance(data.TargetDetectionDistance)
                .AddTargetDetectionLayerMask(EntityLayer.Enemy.AsMask())
                .AddCooldown(data.Cooldown)
                .PutOnCooldown()
                .With(e => e.isSimpleTower = true)
                .With(e => e.isNeedForDetection = true)
                .With(e => e.isReadyForDetection = true);
        }
        
        private GameEntity CreateCannon(Vector3 position)
        {
            CannonTowerData data = (CannonTowerData)_staticDataService.GetTowerData(TowerType.Cannon);

            return _gameContext.CreateEntity()
                .AddId(_identifierGenerator.GetId())
                .AddWorldPosition(position)
                .AddViewPrefab(data.Prefab)
                .AddRotationSpeed(data.RotationSpeed)
                .AddTargetDetectionInterval(data.TargetDetectionInterval)
                .AddTargetDetectionTimer(data.TargetDetectionInterval)
                .AddTargetDetectionDistance(data.TargetDetectionDistance)
                .AddStartProjectileSpeed(data.StartProjectileSpeed)
                .AddTargetDetectionLayerMask(EntityLayer.Enemy.AsMask())
                .AddCooldown(data.Cooldown)
                .PutOnCooldown()
                .With(e => e.isCannonTower = true)
                .With(e => e.isNeedForDetection = true)
                .With(e => e.isReadyForDetection = true)
                .With(e => e.isFollowingTarget = true);
        }
    }
}