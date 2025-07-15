using System.Collections.Generic;
using Entitas;
using Gameplay.Time;

namespace Common.Destroy.Systems
{
    public class SelfDestroyTimerSystem : IExecuteSystem
    {
        private readonly ITimeService _timeService;
        
        private readonly IGroup<GameEntity> _entities;
        private readonly List<GameEntity> _buffer = new (64);

        public SelfDestroyTimerSystem(GameContext game, ITimeService timeService)
        {
            _timeService = timeService;
            
            _entities = game.GetGroup(GameMatcher.SelfDestroyTimer);
        }
    
        public void Execute()
        {
            foreach (GameEntity entity in _entities.GetEntities(_buffer))
            {
                if (entity.SelfDestroyTimer > 0)
                    entity.ReplaceSelfDestroyTimer(entity.SelfDestroyTimer - _timeService.DeltaTime);
                else
                {
                    entity.RemoveSelfDestroyTimer();
                    entity.isDestroyed = true;
                }
            }
        }
    }
}