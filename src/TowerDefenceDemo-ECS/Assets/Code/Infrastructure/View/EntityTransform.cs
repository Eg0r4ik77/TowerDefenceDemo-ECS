namespace Code.Infrastructure.View
{
    public class EntityTransform : EntityViewComponent
    {
        public override void Register()
        {
            Entity.AddTransform(transform);
        }

        public override void Unregister()
        {
            if (Entity.hasTransform)
                Entity.RemoveTransform();
        }
    }
}