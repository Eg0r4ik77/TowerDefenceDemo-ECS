using Code.Common;
using Code.Gameplay.Enemies;
using Code.Gameplay.Movement;
using Code.Gameplay.TargetDetection;
using Code.Gameplay.Towers;
using Code.Infrastructure.Systems;
using Code.Infrastructure.View;

namespace Code.Gameplay
{
    public class GameplayFeature : Feature
    {
        public GameplayFeature(ISystemFactory systemFactory)
        {
            Add(systemFactory.Create<BindViewFeature>());
            Add(systemFactory.Create<MovementFeature>());
            Add(systemFactory.Create<EnemyFeature>());
            Add(systemFactory.Create<TargetDetectionFeature>());
            Add(systemFactory.Create<TowerFeature>());
            Add(systemFactory.Create<CleanupDestroyedFeature>());
        }
    }
}