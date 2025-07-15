using System.Collections.Generic;
using Entitas;
using Gameplay.Cooldowns;
using Gameplay.Projectiles;
using Gameplay.Projectiles.Factory;
using UnityEngine;

namespace Gameplay.Towers.Systems
{
    public class CannonTowerAttackSystem : IExecuteSystem
    {
        private const float MaxAngleBetweenCannonAndTarget = 0.5f;
        
        private readonly IProjectileFactory _projectileFactory;

        private readonly IGroup<GameEntity> _cannonTowers;
        private readonly List<GameEntity> _buffer = new(64);

        public CannonTowerAttackSystem(GameContext gameContext, IProjectileFactory projectileFactory)
        {
            _projectileFactory = projectileFactory;

            _cannonTowers = gameContext.GetGroup(GameMatcher.AllOf(
                GameMatcher.TargetId,
                GameMatcher.CannonTower,
                GameMatcher.CooldownUp,
                GameMatcher.Prediction,
                GameMatcher.AttackSpawnPoint,
                GameMatcher.DeparturePoint));
        }

        public void Execute()
        {
            foreach (GameEntity cannonTower in _cannonTowers.GetEntities(_buffer))
            {
                Vector3 adjustedPredictedPosition = cannonTower.Prediction.Position;
                adjustedPredictedPosition.y = cannonTower.DeparturePoint.position.y;
                
                float angleBetweenCannonAndTarget = Vector3.Angle(
                    adjustedPredictedPosition - cannonTower.DeparturePoint.position,
                    cannonTower.DeparturePoint.forward);
                
                if (angleBetweenCannonAndTarget < MaxAngleBetweenCannonAndTarget)
                {
                    float distanceBeforeDeparture = Vector3.Distance(cannonTower.AttackSpawnPoint.position,
                        cannonTower.DeparturePoint.position);
                    
                    _projectileFactory.Create(ProjectileType.Cannon, cannonTower.AttackSpawnPoint.position)
                        .AddAttackSpawnPoint(cannonTower.AttackSpawnPoint)
                        .AddRotation(cannonTower.AttackSpawnPoint.rotation)
                        .AddDistanceBeforeDeparture(distanceBeforeDeparture)
                        .AddAngleShot(cannonTower.Prediction.Angle);

                    cannonTower.AddRotationDelay(distanceBeforeDeparture / cannonTower.StartProjectileSpeed + 0.2f);
                    cannonTower.PutOnCooldown();
                    cannonTower.RemovePrediction();
                }
            }
        }
    }
}