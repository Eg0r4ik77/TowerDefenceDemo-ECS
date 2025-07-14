using Code.Infrastructure.View;
using UnityEngine;

namespace Code.Gameplay.Towers
{
    public class EntityDeparturePoint : EntityViewComponent
    {
        [SerializeField] private Transform _departurePoint;
        
        public override void Register()
        {
            Entity.AddDeparturePoint(_departurePoint);
        }

        public override void Unregister()
        {
            if (Entity.hasDeparturePoint)
                Entity.RemoveDeparturePoint();
        }
    }
}