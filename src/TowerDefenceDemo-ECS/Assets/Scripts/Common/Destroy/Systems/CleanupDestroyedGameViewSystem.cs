using Entitas;
using Infrastructure.View.Pool;

namespace Common.Destroy.Systems
{
    public class CleanupDestroyedGameViewSystem : ICleanupSystem
    {
        private readonly IEntityViewPool _entityViewPool;
        
        private readonly IGroup<GameEntity> _entities;

        public CleanupDestroyedGameViewSystem(GameContext game, IEntityViewPool entityViewPool)
        {
            _entityViewPool = entityViewPool;

            _entities = game.GetGroup(GameMatcher.AllOf(
                GameMatcher.View,
                GameMatcher.Destroyed));
        }

        public void Cleanup()
        {
            foreach (GameEntity entity in _entities)
            {
                _entityViewPool.ReleaseView(entity);
                entity.View.ReleaseEntity();
            }
        }
    }
}