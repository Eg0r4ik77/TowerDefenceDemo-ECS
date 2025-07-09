using Code.Common;
using Code.Gameplay.Enemies;
using Code.Gameplay.Movement;
using Code.Gameplay.TargetDetection;
using Code.Infrastructure.Systems;

namespace Code.Gameplay
{
    public class GameplayFeature : Feature
    {
        public GameplayFeature(ISystemFactory systemFactory)
        {
            Add(systemFactory.Create<MovementFeature>());
            Add(systemFactory.Create<EnemyFeature>());
            Add(systemFactory.Create<TargetDetectionFeature>());
            Add(systemFactory.Create<CleanupDestroyedFeature>());
        }
    }
}