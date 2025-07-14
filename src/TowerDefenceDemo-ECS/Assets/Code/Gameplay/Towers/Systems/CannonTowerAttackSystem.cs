using System.Collections.Generic;
using Code.Gameplay.Cooldowns;
using Code.Gameplay.Projectiles;
using Code.Gameplay.Projectiles.Factory;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Attack.Systems
{
    public class CannonTowerAttackSystem : IExecuteSystem
    {
        private readonly IProjectileFactory _projectileFactory;

        private readonly IGroup<GameEntity> _cannonTowers;
        private readonly List<GameEntity> _buffer = new(64);

        public CannonTowerAttackSystem(GameContext game, IProjectileFactory projectileFactory)
        {
            _projectileFactory = projectileFactory;
            
            _cannonTowers = game.GetGroup(GameMatcher.AllOf(
                GameMatcher.TargetId,
                GameMatcher.CannonTower,
                GameMatcher.CooldownUp,
                GameMatcher.AttackSpawnPoint));
        }

        public void Execute()
        {
            foreach (GameEntity cannonTower in _cannonTowers.GetEntities(_buffer))
            {
                _projectileFactory.Create(ProjectileType.Parabolic, cannonTower.AttackSpawnPoint.position)
                    .AddAttackSpawnPoint(cannonTower.AttackSpawnPoint)
                    .AddDistanceBeforeDeparture(cannonTower.CannonLength)
                    .AddAngleShot(60 * Mathf.Deg2Rad);
                
                cannonTower.PutOnCooldown();
            }
        }
    }
}