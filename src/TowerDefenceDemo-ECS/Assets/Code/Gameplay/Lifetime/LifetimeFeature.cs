using Code.Infrastructure.Systems;

namespace Code.Gameplay.Lifetime
{
    public class LifetimeFeature : Feature
    {
        public LifetimeFeature(ISystemFactory systemFactory)
        {
            Add(systemFactory.Create<MarkDeadSystem>());
        }
    }
}