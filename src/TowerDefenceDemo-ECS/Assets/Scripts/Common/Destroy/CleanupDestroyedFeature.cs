using Common.Destroy.Systems;
using Infrastructure.Systems;

namespace Common.Destroy
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