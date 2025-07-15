namespace Code.Infrastructure.View.Factory
{
    public interface IEntityViewPool
    {
        public EntityView GetView(GameEntity entity);
        public void ReleaseView(GameEntity entity);
    }
}