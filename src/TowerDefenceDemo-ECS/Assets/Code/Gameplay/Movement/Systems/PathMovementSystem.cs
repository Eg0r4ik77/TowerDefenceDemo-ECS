using Entitas;
using UnityEngine;

namespace Code.Gameplay.Movement.Systems
{
    public class PathMovementSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _movers;

        public PathMovementSystem(GameContext game)
        {
            _movers = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.Moving, GameMatcher.Path));
        }

        public void Execute()
        {
            foreach (GameEntity mover in _movers)
            {
                if (Vector3.Distance(mover.WorldPosition, mover.Path.GetCurrentPosition()) <= mover.ReachDistance)
                {
                    mover.isFinishedPath = !mover.Path.NextPosition();

                    if (!mover.isFinishedPath)
                    {
                        mover.ReplaceDirection((mover.Path.GetCurrentPosition() - mover.WorldPosition).normalized);
                    }
                }
            }
        }
    }
}