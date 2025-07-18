using Entitas;

namespace Gameplay.Movement.Systems
{
    public class DestroyAfterFinishMovementToTargetSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _entities;

        public DestroyAfterFinishMovementToTargetSystem(GameContext game)
        {
            _entities = game.GetGroup(GameMatcher.FinishedPath);
        }

        public void Execute()
        {
            foreach (GameEntity entity in _entities)
            {
                if (entity.isFinishedPath)
                {
                    entity.isDestroyed = true;
                }
            }
        }
    }
}