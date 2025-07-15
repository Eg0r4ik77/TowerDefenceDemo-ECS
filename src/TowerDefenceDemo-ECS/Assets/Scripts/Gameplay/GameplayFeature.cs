using Common.Destroy;
using Gameplay.Effects;
using Gameplay.Enemies;
using Gameplay.Lifetime;
using Gameplay.Movement;
using Gameplay.TargetDetection;
using Gameplay.Towers;
using Infrastructure.Systems;
using Infrastructure.View;

namespace Gameplay
{
    public class GameplayFeature : Feature
    {
        public GameplayFeature(ISystemFactory systemFactory)
        {
            Add(systemFactory.Create<BindViewFeature>());
            Add(systemFactory.Create<EnemyFeature>());
            Add(systemFactory.Create<TargetDetectionFeature>());
            Add(systemFactory.Create<TowerFeature>());
            Add(systemFactory.Create<MovementFeature>());
            Add(systemFactory.Create<EffectFeature>());
            Add(systemFactory.Create<LifetimeFeature>());
            Add(systemFactory.Create<CleanupDestroyedFeature>());
        }
    }
}