using Entitas;

namespace Code.Gameplay.Movement.Systems
{
    public class DestroyAfterFinishPathSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _entities;

        public DestroyAfterFinishPathSystem(GameContext game)
        {
            _entities = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.FinishedPath));
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