using Infrastructure.View.EntityViewComponents;
using UnityEngine;

namespace Gameplay.Towers.EntityViewComponents
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