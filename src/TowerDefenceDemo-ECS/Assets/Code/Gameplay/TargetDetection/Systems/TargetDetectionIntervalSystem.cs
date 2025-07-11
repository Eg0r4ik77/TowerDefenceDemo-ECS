using Code.Gameplay.Common.Time;
using Entitas;

namespace Code.Gameplay.TargetDetection
{
    public class TargetDetectionIntervalSystem : IExecuteSystem
    {
        private readonly ITimeService _timeService;
        
        private readonly IGroup<GameEntity> _entities;

        public TargetDetectionIntervalSystem(GameContext game, ITimeService timeService)
        {
            _timeService = timeService;
            
            _entities = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.TargetDetectionInterval,
                    GameMatcher.TargetDetectionTimer));
        }

        public void Execute()
        {
            foreach (GameEntity entity in _entities)
            {
                if (entity.TargetDetectionTimer <= 0)
                {
                    entity.isReadyForDetection = true;
                    
                    if(entity.isNeedForDetection)
                        entity.ReplaceTargetDetectionTimer(entity.TargetDetectionInterval);
                }
                
                entity.ReplaceTargetDetectionTimer(entity.TargetDetectionTimer - _timeService.DeltaTime);
            }
        }
    }
}