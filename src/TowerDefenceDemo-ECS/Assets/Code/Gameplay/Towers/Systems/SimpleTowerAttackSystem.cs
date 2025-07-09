using System.Collections.Generic;
using Code.Gameplay.Cooldowns;
using Code.Gameplay.Projectiles;
using Code.Gameplay.Projectiles.Factory;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Attack.Systems
{
    public class SimpleTowerAttackSystem : IExecuteSystem
    {
        private readonly GameContext _gameContext;
        private readonly IProjectileFactory _projectileFactory;

        private readonly IGroup<GameEntity> _simpleTowers;

        private readonly List<GameEntity> _buffer = new(64);

        public SimpleTowerAttackSystem(GameContext game, IProjectileFactory projectileFactory)
        {
            _gameContext = game;
            _projectileFactory = projectileFactory;
            
            _simpleTowers = game.GetGroup(GameMatcher.AllOf(
                GameMatcher.TargetId,
                GameMatcher.SimpleTower,
                GameMatcher.CooldownUp,
                GameMatcher.Transform));
        }

        public void Execute()
        {
            foreach (GameEntity simpleTower in _simpleTowers.GetEntities(_buffer))
            {
                GameEntity target = _gameContext.GetEntityWithId(simpleTower.TargetId);

                _projectileFactory.Create(ProjectileType.Guided, simpleTower.Transform.position + Vector3.up * 1.5f)
                    .AddTargetId(target.Id);
                
                simpleTower.PutOnCooldown();
            }
        }
    }
}