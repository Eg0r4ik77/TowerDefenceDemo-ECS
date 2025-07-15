using Gameplay.Lifetime.Systems;
using Infrastructure.Systems;

namespace Gameplay.Lifetime
{
    public class LifetimeFeature : Feature
    {
        public LifetimeFeature(ISystemFactory systemFactory)
        {
            Add(systemFactory.Create<MarkDeadSystem>());
        }
    }
}