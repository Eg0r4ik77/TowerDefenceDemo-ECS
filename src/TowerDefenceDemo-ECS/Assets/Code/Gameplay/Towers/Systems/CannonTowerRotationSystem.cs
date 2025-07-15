using Entitas;

namespace Code.Gameplay.Attack.Systems
{
    public class CannonTowerRotationSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _cannonTowers;

        public CannonTowerRotationSystem(GameContext gameContext)
        {
            _cannonTowers = gameContext.GetGroup(GameMatcher.CannonTower);
        }

        public void Execute()
        {
            foreach (GameEntity cannonTower in _cannonTowers)
            {
                if (cannonTower.hasPrediction)
                    cannonTower.ReplaceTargetRotationPosition(cannonTower.Prediction.Position);     
            }
        }
    }
}