using Entitas;
using Gameplay.Time;
using UnityEngine;

namespace Gameplay.Movement.Systems
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
                if (entity.hasRotationDelay)
                {
                    if (entity.RotationDelay <= 0)
                    {
                        entity.RemoveRotationDelay();
                    }
                    else
                    {
                        entity.ReplaceRotationDelay(entity.RotationDelay - _timeService.DeltaTime);
                        continue;
                    }
                }
                
                Rotate(entity);
            }
        }

        private void Rotate(GameEntity entity)
        {
            Vector3 direction = (entity.TargetRotationPosition - entity.Transform.position).normalized;
			     
            direction.y = 0;
        
            Quaternion rotation = Quaternion.LookRotation(direction);
            float degreesDelta = entity.RotationSpeed * _timeService.DeltaTime;
        
            entity.ReplaceRotation(Quaternion.RotateTowards(entity.Rotation, rotation, degreesDelta));
        }
    }
}