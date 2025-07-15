using System.Collections.Generic;
using Entitas;

namespace Gameplay.TargetDetection.Systems
{
    public class FollowTargetSystem : IExecuteSystem
    {
        private readonly GameContext _gameContext;
        private readonly IGroup<GameEntity> _detectors;
        
        private readonly List<GameEntity> _detectorsBuffer = new(64);
        
        public FollowTargetSystem(GameContext gameContext)
        {
            _gameContext = gameContext;

            _detectors = gameContext.GetGroup(GameMatcher.AllOf(
                GameMatcher.FollowingTarget,
                GameMatcher.TargetId));
        }

        public void Execute()
        {
            foreach (GameEntity detector in _detectors.GetEntities(_detectorsBuffer))
            {
                detector.isNeedForDetection = false;
            }
        }
    }
}