using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace Code.Common.Destroy.Systems
{
    public class SelfDestroyTimerSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _entities;
        private readonly List<GameEntity> _buffer = new (64);

        public SelfDestroyTimerSystem(GameContext game)
        {
            _entities = game.GetGroup(GameMatcher.SelfDestructTimer);
        }
    
        public void Execute()
        {
            foreach (GameEntity entity in _entities.GetEntities(_buffer))
            {
                if (entity.SelfDestructTimer > 0)
                    entity.ReplaceSelfDestructTimer(entity.SelfDestructTimer - Time.deltaTime);
                else
                {
                    entity.RemoveSelfDestructTimer();
                    entity.isDestroyed = true;
                }
            }
        }
    }
}