using Code.Infrastructure.View;
using UnityEngine;

namespace Code.Gameplay.Towers
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