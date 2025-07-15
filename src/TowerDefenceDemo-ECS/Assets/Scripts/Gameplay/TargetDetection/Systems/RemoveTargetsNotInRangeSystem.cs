using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace Gameplay.TargetDetection.Systems
{
    public class RemoveTargetsNotInRangeSystem : IExecuteSystem
    {
        private readonly GameContext _gameContext;
        private readonly IGroup<GameEntity> _detectors;
        
        private readonly List<GameEntity> _detectorsBuffer = new(64);
        
        public RemoveTargetsNotInRangeSystem(GameContext gameContext)
        {
            _gameContext = gameContext;

            _detectors = gameContext.GetGroup(GameMatcher.AllOf(
                GameMatcher.FollowingTarget,
                GameMatcher.TargetId,
                GameMatcher.WorldPosition,
                GameMatcher.TargetDetectionDistance));
        }

        public void Execute()
        {
            foreach (GameEntity detector in _detectors.GetEntities(_detectorsBuffer))
            {
                GameEntity target = _gameContext.GetEntityWithId(detector.TargetId);
                
                if (Vector3.Distance(detector.WorldPosition, target.WorldPosition) >
                    detector.TargetDetectionDistance)
                {
                    detector.RemoveTargetId();
                    detector.isNeedForDetection = true;
                }
            }
        }
    }
}