using Gameplay.Cooldowns.Systems;
using Gameplay.Towers.Systems;
using Infrastructure.Systems;

namespace Gameplay.Towers
{
    public class TowerFeature : Feature
    {
        public TowerFeature(ISystemFactory systemFactory)
        {
            Add(systemFactory.Create<CooldownSystem>());
            Add(systemFactory.Create<SimpleTowerAttackSystem>());
            Add(systemFactory.Create<CalculateCannonTowerPredictionSystem>());
            Add(systemFactory.Create<CannonTowerRotationSystem>());
            Add(systemFactory.Create<CannonTowerAttackSystem>());
        }
    }
}