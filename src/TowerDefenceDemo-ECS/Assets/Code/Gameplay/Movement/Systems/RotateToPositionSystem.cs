using Code.Gameplay.Common.Time;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Movement.Systems
{
    public class RotateToPositionSystem : IExecuteSystem
    {
        private readonly ITimeService _timeService;
        
        private readonly IGroup<GameEntity> _entities;

        public RotateToPositionSystem(GameContext game, ITimeService timeService)
        {
            _timeService = timeService;
            
            _entities = game.GetGroup(GameMatcher.AllOf(
                GameMatcher.Rotation,
                GameMatcher.TargetRotationPosition,
                GameMatcher.RotationSpeed));
        }

        public void Execute()
        {
            foreach (GameEntity entity in _entities)
            {
                var direction = (entity.TargetRotationPosition - entity.Transform.position).normalized;
			     
                direction.y = 0;
        
                var rotation = Quaternion.LookRotation(direction);
                var degreesDelta = entity.RotationSpeed * _timeService.DeltaTime;
        
                entity.ReplaceRotation(Quaternion.RotateTowards(entity.Rotation, rotation, degreesDelta));
            }
        }
    }
}