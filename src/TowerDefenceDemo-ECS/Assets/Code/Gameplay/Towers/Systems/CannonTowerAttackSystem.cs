using System.Collections.Generic;
using Code.Gameplay.Cooldowns;
using Code.Gameplay.Projectiles;
using Code.Gameplay.Projectiles.Factory;
using Entitas;

namespace Code.Gameplay.Attack.Systems
{
    public class CannonTowerAttackSystem : IExecuteSystem
    {
        private readonly GameContext _gameContext;
        private readonly IProjectileFactory _projectileFactory;

        private readonly IGroup<GameEntity> _cannonTowers;

        private readonly List<GameEntity> _buffer = new(64);

        public CannonTowerAttackSystem(GameContext game, IProjectileFactory projectileFactory)
        {
            _gameContext = game;
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
                GameEntity target = _gameContext.GetEntityWithId(cannonTower.TargetId);

                _projectileFactory.Create(ProjectileType.Parabolic, cannonTower.AttackSpawnPoint.position)
                    .AddTargetId(target.Id);
                
                cannonTower.PutOnCooldown();
            }
        }
    }
}