namespace Infrastructure.View.EntityViewComponents
{
    public class EntityRotation : EntityViewComponent
    {
        public override void Register()
        {
            Entity.AddRotation(transform.rotation);
        }

        public override void Unregister()
        {
            if (Entity.hasRotation)
                Entity.RemoveRotation();
        }
    }
}