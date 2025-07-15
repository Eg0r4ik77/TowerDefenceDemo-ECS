using Entitas;

namespace Gameplay.Enemies.Systems
{
    public class InitializeEnemySpawnTimerSystem : IInitializeSystem
    {
        private readonly GameContext _gameContext;
        
        public InitializeEnemySpawnTimerSystem(GameContext gameContext)
        {
            _gameContext = gameContext;
        }
        
        public void Initialize()
        {
            _gameContext.CreateEntity()
                .AddEnemySpawnTimer(0);
        }
    }
}