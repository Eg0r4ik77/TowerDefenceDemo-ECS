using System.Collections.Generic;
using Code.Gameplay.Cooldowns;
using Code.Gameplay.Movement;
using Code.Gameplay.Projectiles;
using Code.Gameplay.Projectiles.Factory;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Attack.Systems
{
    public class CannonTowerAttackSystem : IExecuteSystem
    {
        private readonly GameContext _gameContext;
        private readonly IProjectileFactory _projectileFactory;

        private readonly IGroup<GameEntity> _cannonTowers;
        private readonly List<GameEntity> _buffer = new(64);

        public CannonTowerAttackSystem(GameContext gameContext, IProjectileFactory projectileFactory)
        {
            _gameContext = gameContext;
            _projectileFactory = projectileFactory;
            
            _cannonTowers = gameContext.GetGroup(GameMatcher.AllOf(
                GameMatcher.TargetId,
                GameMatcher.CannonTower,
                GameMatcher.CooldownUp,
                GameMatcher.AttackSpawnPoint));
        }

        public void Execute()
        {
            foreach (GameEntity cannonTower in _cannonTowers.GetEntities(_buffer))
            {
                GameEntity target = _gameContext.GetEntityWithId(cannonTower.TargetId);
                cannonTower.isRotating = true;
                
                Vector3 adjustedTargetPosition = target.WorldPosition;
                adjustedTargetPosition.y = cannonTower.AttackSpawnPoint.position.y;
 
                float angleBetweenCannonAndTarget = Vector3.Angle(
                    adjustedTargetPosition - cannonTower.AttackSpawnPoint.position,
                    cannonTower.AttackSpawnPoint.forward);

                if (angleBetweenCannonAndTarget < 1f)
                {
                    _projectileFactory.Create(ProjectileType.Parabolic, cannonTower.AttackSpawnPoint.position)
                        .AddAttackSpawnPoint(cannonTower.AttackSpawnPoint)
                        .AddDistanceBeforeDeparture(cannonTower.CannonLength)
                        .AddAngleShot(60 * Mathf.Deg2Rad)
                        .AddRotation(cannonTower.AttackSpawnPoint.rotation);
                
                    cannonTower.isRotating = false;
                    cannonTower.PutOnCooldown();
                }
            }
        }
    }
}