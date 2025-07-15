namespace Gameplay.Effects.Factory
{
    public interface IEffectFactory
    {
        public GameEntity Create(EffectType type, float value, int targetId);
    }
}