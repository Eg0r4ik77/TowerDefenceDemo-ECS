using Code.Gameplay.Enemies.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Enemies
{
    public class EnemyFeature : Feature
    {
        public EnemyFeature(ISystemFactory systemFactory)
        {
            Add(systemFactory.Create<InitializeEnemySpawnTimerSystem>());
            Add(systemFactory.Create<SpawnEnemySystem>());
            Add(systemFactory.Create<EnemyDeathSystem>());
        }
    }
}