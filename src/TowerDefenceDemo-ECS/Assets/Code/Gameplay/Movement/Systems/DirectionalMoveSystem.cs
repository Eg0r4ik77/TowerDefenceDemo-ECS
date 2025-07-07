using Entitas;
using UnityEngine;

namespace Code.Gameplay.Movement.Systems
{
    public class DirectionalMoveSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _movers;

        public DirectionalMoveSystem(GameContext game)
        {
            _movers = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Moving,
                    GameMatcher.WorldPosition, 
                    GameMatcher.Direction, 
                    GameMatcher.Speed));
        }

        public void Execute()
        {
            foreach (GameEntity mover in _movers)
            {
                mover.ReplaceWorldPosition(mover.WorldPosition + mover.Direction * mover.Speed * Time.deltaTime);
            }
        }
    }
}