using Entitas;
using UnityEngine;

namespace Code.Gameplay.Movement.Systems
{
    public class UpdatePositionWithBottomPoint : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _movers;
        
        public UpdatePositionWithBottomPoint(GameContext game)
        {
            _movers = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.WorldPosition,
                    GameMatcher.Transform,
                    GameMatcher.BottomPoint));
        }
    
        public void Execute()
        {
            foreach (GameEntity mover in _movers)
            {
                mover.Transform.position = mover.WorldPosition - Vector3.up * mover.BottomPoint.localPosition.y;
            }
        }
    }
}