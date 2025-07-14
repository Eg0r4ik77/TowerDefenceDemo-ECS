using Code.Gameplay.Attack.Systems;
using Code.Gameplay.Features.Cooldowns.Systems;
using Code.Gameplay.Projectiles.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Towers
{
    public class TowerFeature : Feature
    {
        public TowerFeature(ISystemFactory systemFactory)
        {
            Add(systemFactory.Create<CooldownSystem>());
            Add(systemFactory.Create<SimpleTowerAttackSystem>());
            Add(systemFactory.Create<CannonTowerRotationSystem>());
            Add(systemFactory.Create<CannonTowerAttackSystem>());
        }
    }
}