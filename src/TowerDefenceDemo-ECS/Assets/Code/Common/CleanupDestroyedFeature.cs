using Code.Common.Systems;

namespace Code.Common
{
    public class CleanupDestroyedFeature : Feature
    {
        public CleanupDestroyedFeature(GameContext gameContext)
        {
            Add(new CleanupDestroyedGameViewSystem(gameContext));
            Add(new CleanupDestroyedSystem(gameContext));
        }
    }
}