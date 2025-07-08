using UnityEngine;

namespace Code.Infrastructure.View
{
    public class EntityBottomPoint : EntityViewComponent
    {
        [SerializeField] private Transform _bottomPoint;
        
        public override void Register()
        {
            Entity.AddBottomPoint(_bottomPoint);
        }

        public override void Unregister()
        {
            if (Entity.hasBottomPoint)
                Entity.RemoveBottomPoint();
        }
    }
}