using System;
using Code.Infrastructure.View;
using Gameplay.Monster;
using UnityEngine;
using UnityEngine.Serialization;
using Object = UnityEngine.Object;

namespace Code.Gameplay.Enemies
{
    public class EnemyFactory : MonoBehaviour
    {
        public MonsterData MonsterData;
        public Transform SpawnPoint;
        public Transform TargetPoint;
        
        public GameEntity CreateEnemy(EnemyType type, Vector3 position)
        {
            switch (type)
            {
                case EnemyType.Simple:
                    return CreateSimple(position);
            }

            throw new Exception($"Enemy with type {type} does not exist");
        }

        private GameEntity CreateSimple(Vector2 at)
        {
            var obj = Instantiate(MonsterData.View, SpawnPoint.position, Quaternion.identity);
            
            var entity = Contexts.sharedInstance.game.CreateEntity()
                .AddSpeed(MonsterData.Speed)
                .AddReachDistance(MonsterData.ReachDistance)
                .AddWorldPosition(SpawnPoint.position)
                .AddTargetPosition(TargetPoint.position);

            entity.isMoving = true;

            obj.SetEntity(entity);
            
            return entity;
        }
    }
}