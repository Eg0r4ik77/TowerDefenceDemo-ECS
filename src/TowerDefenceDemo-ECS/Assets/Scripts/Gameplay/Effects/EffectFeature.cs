using Gameplay.Effects.Systems;
using Infrastructure.Systems;

namespace Gameplay.Effects
{
    public class EffectFeature : Feature
    {
        public EffectFeature(ISystemFactory systemFactory)
        {
            Add(systemFactory.Create<ProcessDamageSystem>());
        }
    }
}