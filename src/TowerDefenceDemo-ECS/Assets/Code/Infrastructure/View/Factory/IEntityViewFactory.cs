namespace Code.Infrastructure.View.Factory
{
    public interface IEntityViewFactory
    {
        public EntityView CreateViewForEntity(GameEntity entity);
    }
}