using Code.Gameplay.Common.Time;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Movement.Systems
{
    public class DirectionalMoveSystem : IExecuteSystem
    {
        private readonly ITimeService _timeService;
        
        private readonly IGroup<GameEntity> _movers;

        public DirectionalMoveSystem(GameContext game, ITimeService timeService)
        {
            _timeService = timeService;
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
                mover.ReplaceWorldPosition(mover.WorldPosition + mover.Direction * mover.Speed * _timeService.DeltaTime);
            }
        }
    }
}