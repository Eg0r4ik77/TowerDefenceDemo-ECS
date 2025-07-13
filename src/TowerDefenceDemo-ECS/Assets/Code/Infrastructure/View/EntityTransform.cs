using UnityEngine;

namespace Code.Infrastructure.View
{
    public class EntityTransform : EntityViewComponent
    {
        [SerializeField] private Transform _transform;
        
        public override void Register()
        {
            Entity.AddTransform(_transform ?? transform);
        }

        public override void Unregister()
        {
            if (Entity.hasTransform)
                Entity.RemoveTransform();
        }
    }
}