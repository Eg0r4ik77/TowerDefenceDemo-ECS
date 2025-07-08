using System;
using Gameplay.Monster;
using UnityEngine;

namespace Code.Gameplay.Enemies
{
    public class EnemyFactory : MonoBehaviour, IEnemyFactory
    {
        private readonly GameContext _gameContext;
        public MonsterData MonsterData;
        public Transform SpawnPoint;
        public Transform TargetPoint;

        public EnemyFactory(GameContext gameContext)
        {
            _gameContext = gameContext;
        }
        
        public GameEntity CreateEnemy(EnemyType type, Vector3 position)
        {
            return type switch
            {
                EnemyType.Simple => CreateSimple(position),
                _ => throw new Exception($"Enemy with type {type} does not exist")
            };
        }

        private GameEntity CreateSimple(Vector2 at)
        {
             var obj = Instantiate(MonsterData.View, SpawnPoint.position, Quaternion.identity);
            
             var entity = _gameContext.CreateEntity()
                 .AddSpeed(MonsterData.Speed)
                 .AddReachDistance(MonsterData.ReachDistance)
                 .AddWorldPosition(SpawnPoint.position)
                 .AddTargetPosition(TargetPoint.position);
            
             entity.isEnemy = true;
             entity.isMoving = true;
            
             obj.SetEntity(entity);
            
            return entity;
        }
    }
}