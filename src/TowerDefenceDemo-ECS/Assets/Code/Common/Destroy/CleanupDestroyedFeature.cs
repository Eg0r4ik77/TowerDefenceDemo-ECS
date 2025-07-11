using Code.Common.Destroy.Systems;
using Code.Common.Systems;
using Code.Infrastructure.Systems;

namespace Code.Common
{
    public class CleanupDestroyedFeature : Feature
    {
        public CleanupDestroyedFeature(ISystemFactory systemFactory)
        {
            Add(systemFactory.Create<SelfDestroyTimerSystem>());
            Add(systemFactory.Create<CleanupDestroyedGameViewSystem>());
            Add(systemFactory.Create<CleanupDestroyedSystem>());
        }
    }
}