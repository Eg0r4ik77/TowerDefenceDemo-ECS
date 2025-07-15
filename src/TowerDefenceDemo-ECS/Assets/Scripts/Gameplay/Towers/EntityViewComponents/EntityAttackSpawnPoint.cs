using Infrastructure.View.EntityViewComponents;
using UnityEngine;

namespace Gameplay.Towers.EntityViewComponents
{
    public class EntityAttackSpawnPoint : EntityViewComponent
    {
        [SerializeField] private Transform _spawnPoint;
        
        public override void Register()
        {
            Entity.AddAttackSpawnPoint(_spawnPoint);
        }

        public override void Unregister()
        {
            if (Entity.hasAttackSpawnPoint)
                Entity.RemoveAttackSpawnPoint();
        }
    }
}