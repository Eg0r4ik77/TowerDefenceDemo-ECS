using Gameplay.Enemies.Systems;
using Infrastructure.Systems;

namespace Gameplay.Enemies
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