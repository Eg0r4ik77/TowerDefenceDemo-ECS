using Entitas;

namespace Code.Gameplay.Enemies.Systems
{
    public class InitializeEnemySpawnTimerSystem : IInitializeSystem
    {
        public void Initialize()
        {
            Contexts.sharedInstance.game.CreateEntity().AddEnemySpawnTimer(3);
        }
    }
}