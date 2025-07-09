using System;
using Code.Common.Extensions;
using Code.Infrastructure.Identifiers;
using Code.StaticData;
using UnityEngine;

namespace Code.Gameplay.Projectiles.Factory
{
    public class ProjectileFactory : IProjectileFactory
    {
        private readonly GameContext _gameContext;
        private readonly IStaticDataService _staticDataService;
        private readonly IIdentifierGenerator _identifierGenerator;

        public ProjectileFactory(GameContext gameContext,
            IStaticDataService staticDataService,
            IIdentifierGenerator identifierGenerator)
        {
            _gameContext = gameContext;
            _staticDataService = staticDataService;
            _identifierGenerator = identifierGenerator;
        }
        
        public GameEntity Create(ProjectileType type, Vector3 position)
        {
            return type switch
            {
                ProjectileType.Guided => CreateGuided(position),
                ProjectileType.Parabolic => CreateParabolic(position),
                _ => throw new Exception($"Projectile with type {type} does not exist")
            };
        }

        private GameEntity CreateGuided(Vector3 position)
        {
            ProjectileData data = _staticDataService.GetProjectileData(ProjectileType.Guided);

            GameEntity entity = _gameContext.CreateEntity()
                .AddId(_identifierGenerator.GetId())
                .AddWorldPosition(position)
                .AddViewPrefab(data.Prefab)
                .AddSpeed(data.Speed)
                .With(e => e.isMoving = true)
                .With(e => e.isMovementToTransform = true);
             
            return entity;
        }

        private GameEntity CreateParabolic(Vector3 position)
        {
            return _gameContext.CreateEntity();
        }
            
    }
}