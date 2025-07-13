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

        public ProjectileFactory(GameContext gameContext,
            IStaticDataService staticDataService)
        {
            _gameContext = gameContext;
            _staticDataService = staticDataService;
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

            return _gameContext.CreateEntity()
                .AddWorldPosition(position)
                .AddViewPrefab(data.Prefab)
                .AddSpeed(data.Speed)
                .AddDamage(data.Damage)
                .AddSelfDestructTimer(data.LifeTime)
                .With(e => e.isMoving = true)
                .With(e => e.isMovementByRigidbody = true)
                .With(e => e.isMovementToTransform = true);
        }

        private GameEntity CreateParabolic(Vector3 position)
        {
            ProjectileData data = _staticDataService.GetProjectileData(ProjectileType.Parabolic);

            return _gameContext.CreateEntity()
                .AddWorldPosition(position)
                .AddViewPrefab(data.Prefab)
                .AddSpeed(data.Speed)
                .AddDamage(data.Damage)
                .AddSelfDestructTimer(data.LifeTime)
                .With(e => e.isCannonProjectile = true)
                .With(e => e.isMoving = true)
                .With(e => e.isMovementByRigidbody = true);
        }
    }
}