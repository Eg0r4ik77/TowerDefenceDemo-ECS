using Entitas;
using UnityEngine;

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
                GameMatcher.ParabolicMovement));
        }

        public void Execute()
        {
            foreach (GameEntity mover in _movers)
            {
                //учитывать угол падения; вертикальная скорость должна меняться
                mover.ReplaceDirection(mover.Direction + mover.Transform.up * (-9.81f) * Time.deltaTime);
                // mover.Rigidbody.MovePosition(rigidbody.position + _velocity * Time.fixedDeltaTime);
            }
        }
    }
}