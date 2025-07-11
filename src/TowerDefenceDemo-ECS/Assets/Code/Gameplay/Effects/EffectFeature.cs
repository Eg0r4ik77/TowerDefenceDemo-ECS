using Code.Gameplay.Damage.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Damage
{
    public class EffectFeature : Feature
    {
        public EffectFeature(ISystemFactory systemFactory)
        {
            Add(systemFactory.Create<ProcessDamageSystem>());
        }
    }
}