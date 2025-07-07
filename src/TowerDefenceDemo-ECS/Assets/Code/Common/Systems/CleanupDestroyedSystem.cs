using System.Collections.Generic;
using Entitas;

namespace Code.Common.Systems
{
    public class CleanupDestroyedSystem : ICleanupSystem
    {
        private readonly IGroup<GameEntity> _entities;
        private readonly List<GameEntity> _buffer = new (64);

        public CleanupDestroyedSystem(GameContext game) => 
            _entities = game.GetGroup(GameMatcher.AllOf(GameMatcher.Destroyed));

        public void Cleanup()
        {
            foreach (GameEntity entity in _entities.GetEntities(_buffer))
            {
                entity.Destroy();
            }
        }
    }
}