using Entitas;

namespace Code.Gameplay.Movement.Systems
{
    public class ParabolicMovementSystem : IExecuteSystem
    {
        private readonly GameContext _gameContext;

        private readonly IGroup<GameEntity> _movers;

        public ParabolicMovementSystem(GameContext gameContext)
        {
            _gameContext = gameContext;

            _movers = gameContext.GetGroup(GameMatcher.AllOf(
                GameMatcher.Moving,
                GameMatcher.TargetId,
                GameMatcher.MovementToTransform));
        }

        public void Execute()
        {
            foreach (GameEntity mover in _movers)
            {

            }
        }
    }
}