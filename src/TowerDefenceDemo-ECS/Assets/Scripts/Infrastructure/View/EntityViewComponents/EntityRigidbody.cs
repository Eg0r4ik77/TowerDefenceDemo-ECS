using UnityEngine;

namespace Infrastructure.View.EntityViewComponents
{
    public class EntityRigidbody : EntityViewComponent
    {
        [SerializeField] private Rigidbody _rigidbody;
        
        public override void Register()
        {
            Entity.AddRigidbody(_rigidbody);
        }

        public override void Unregister()
        {
            if(Entity.hasRigidbody)
                Entity.RemoveRigidbody();
        }
    }
}