using System.Collections.Generic;
using Code.Infrastructure.View.Factory;
using Entitas;

namespace Code.Infrastructure.View.Systems
{
    public class BindEntityViewSystem : IExecuteSystem
    {
        private readonly IEntityViewPool _entityViewPool;
        
        private readonly IGroup<GameEntity> _entities;
        
        private readonly List<GameEntity> _buffer = new(32);

        public BindEntityViewSystem(IEntityViewPool entityViewPool, GameContext game)
        {
            _entityViewPool = entityViewPool;

            _entities = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.EntityViewPoolType,
                    GameMatcher.ViewPrefab)
                .NoneOf(GameMatcher.View));
        }

        public void Execute()
        {
            foreach (GameEntity entity in _entities.GetEntities(_buffer))
            {
                _entityViewPool.GetView(entity);
            }
        }
    }
}