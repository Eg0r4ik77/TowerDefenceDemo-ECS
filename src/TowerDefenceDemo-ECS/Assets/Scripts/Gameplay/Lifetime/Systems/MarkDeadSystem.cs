using System.Collections.Generic;
using Entitas;

namespace Gameplay.Lifetime.Systems
{
    public class MarkDeadSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _entities;
    
        private readonly List<GameEntity> _buffer = new(128);

        public MarkDeadSystem(GameContext game)
        {
            _entities = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Health,
                    GameMatcher.MaxHealth)
                .NoneOf(GameMatcher.Dead));
        }

        public void Execute()
        {
            foreach (GameEntity entity in _entities.GetEntities(_buffer))
            {
                if (entity.Health <= 0)
                {
                    entity.isDead = true;
                }
            }
        }
    }
}