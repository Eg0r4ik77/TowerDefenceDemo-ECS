namespace Infrastructure.View.Pool
{
    public interface IEntityViewPool
    {
        public EntityView GetView(GameEntity entity);
        public void ReleaseView(GameEntity entity);
    }
}