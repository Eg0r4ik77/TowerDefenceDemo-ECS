using Gameplay.TargetDetection.Systems;
using Infrastructure.Systems;

namespace Gameplay.TargetDetection
{
    public class TargetDetectionFeature : Feature
    {
        public TargetDetectionFeature(ISystemFactory systemFactory)
        {
            Add(systemFactory.Create<TargetDetectionIntervalSystem>());
            Add(systemFactory.Create<ClosestTargetDetectionSystem>());
            Add(systemFactory.Create<RemoveTargetsNotInRangeSystem>());
            Add(systemFactory.Create<FollowTargetSystem>());
        }
    }
}