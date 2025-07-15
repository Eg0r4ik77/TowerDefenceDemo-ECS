using UnityEngine;

namespace Infrastructure.View.EntityViewComponents
{
    public class EntitySpawnPoint : EntityViewComponent
    {
        [SerializeField] private Transform _spawnPoint;
        
        public override void Register()
        {
            Entity.AddSpawnPoint(_spawnPoint);
        }

        public override void Unregister()
        {
            if (Entity.hasSpawnPoint)
                Entity.RemoveSpawnPoint();
        }
    }
}