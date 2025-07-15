using Code.Common;
using Code.Gameplay.Common.Time;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Movement.Systems
{
    public class ParabolicMovementSystem : IExecuteSystem
    {
        private readonly ITimeService _timeService;
        
        private readonly IGroup<GameEntity> _movers;

        public ParabolicMovementSystem(GameContext gameContext, ITimeService timeService)
        {
            _timeService = timeService;
            
            _movers = gameContext.GetGroup(GameMatcher.AllOf(
                GameMatcher.Moving,
                GameMatcher.ParabolicMovement,
                GameMatcher.Direction,
                GameMatcher.Speed));
        }

        public void Execute()
        {
            foreach (GameEntity mover in _movers)
            {
                Vector3 gravity = Vector3.up * GameplayConstants.GravityAcceleration * _timeService.DeltaTime;
                Vector3 newVelocity = mover.Direction * mover.Speed + gravity;

                mover.ReplaceSpeed(newVelocity.magnitude);
                mover.ReplaceDirection(newVelocity.normalized);
            }
        }
    }
}