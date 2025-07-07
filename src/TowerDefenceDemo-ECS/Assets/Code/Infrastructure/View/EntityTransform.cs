using Entitas;

namespace Code.Infrastructure.View
{
    public class EntityTransform : EntityBehaviourComponent
    {
        public override void RegisterComponents()
        {
            Entity.AddTransform(transform);
        }

        public override void UnregisterComponents()
        {
            if (Entity.hasTransform){}
                Entity.RemoveTransform();
        }
    }
}