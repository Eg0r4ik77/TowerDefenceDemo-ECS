using UnityEngine;

namespace Code.Infrastructure.View
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