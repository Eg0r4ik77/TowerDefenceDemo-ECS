using System.Collections.Generic;
using Code.Common;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.TargetDetection.Systems
{
    public class ClosestTargetDetectionSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _detectors;
        private readonly IGroup<GameEntity> _targets;

        private readonly List<GameEntity> _detectorsBuffer = new(64);

        public ClosestTargetDetectionSystem(GameContext game)
        {
            _detectors = game.GetGroup(GameMatcher.AllOf(
                GameMatcher.WorldPosition,
                GameMatcher.NeedForDetection,
                GameMatcher.ReadyForDetection,
                GameMatcher.TargetDetectionDistance,
                GameMatcher.TargetDetectionLayerMask));

            _targets = game.GetGroup(GameMatcher.AllOf(
                GameMatcher.Layer,
                GameMatcher.WorldPosition));
        }

        public void Execute()
        {
            foreach (GameEntity detector in _detectors.GetEntities(_detectorsBuffer))
            {
                float minDistance = float.MaxValue;
                GameEntity closestTarget = null;
                
                foreach (GameEntity target in _targets)
                {
                    float distance = Vector3.Distance(detector.WorldPosition, target.WorldPosition);
                    
                    if ( target.Layer.Matches(detector.TargetDetectionLayerMask) 
                         && distance <= detector.TargetDetectionDistance 
                         && distance < minDistance)
                    {
                        minDistance = distance;
                        closestTarget = target;
                    }
                }

                if (closestTarget != null)
                {
                    Debug.Log(closestTarget.Id);
                    detector.ReplaceTargetId(closestTarget.Id);
                }

                detector.isReadyForDetection = false;
            }
        }
    }
}