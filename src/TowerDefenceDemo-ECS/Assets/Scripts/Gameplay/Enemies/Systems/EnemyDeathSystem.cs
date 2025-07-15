using Entitas;

namespace Gameplay.Enemies.Systems
{
    public class EnemyDeathSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _enemies;

        public EnemyDeathSystem(GameContext game)
        {
            _enemies = game.GetGroup(GameMatcher.AllOf(
                GameMatcher.Enemy,
                GameMatcher.Dead));
        }

        public void Execute()
        {
            foreach (GameEntity enemy in _enemies)
            {
                enemy.isDestroyed = true;
            }
        }
    }
}