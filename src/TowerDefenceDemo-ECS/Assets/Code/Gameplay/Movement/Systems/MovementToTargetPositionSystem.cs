using Entitas;
using UnityEngine;

namespace Code.Gameplay.Movement.Systems
{
    public class MovementToTargetPositionSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _movers;

        public MovementToTargetPositionSystem(GameContext game)
        {
            _movers = game.GetGroup(GameMatcher.AllOf(GameMatcher.Moving, GameMatcher.FinishPosition));
        }

        public void Execute()
        {
            foreach (GameEntity mover in _movers)
            {
                mover.ReplaceDirection((mover.FinishPosition - mover.WorldPosition).normalized);
                
                if (Vector3.Distance(mover.WorldPosition, mover.FinishPosition) <= mover.ReachDistance)
                {
                    mover.isFinishedPath = true;
                }
            }
        }
    }
}