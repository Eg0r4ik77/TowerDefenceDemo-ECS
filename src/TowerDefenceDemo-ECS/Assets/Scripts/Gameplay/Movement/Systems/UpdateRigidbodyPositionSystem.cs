using Entitas;

namespace Gameplay.Movement.Systems
{
    public class UpdateRigidbodyPositionSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _movers;
        
        public UpdateRigidbodyPositionSystem(GameContext game)
        {
            _movers = game.GetGroup(GameMatcher.AllOf(
                GameMatcher.WorldPosition,
                GameMatcher.Rigidbody,
                GameMatcher.MovementByRigidbody));
        }
    
        public void Execute()
        {
            foreach (GameEntity mover in _movers)
            {
                mover.Rigidbody.MovePosition(mover.WorldPosition);
            }
        }
    }
}