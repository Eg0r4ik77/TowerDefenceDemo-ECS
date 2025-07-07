using Code.Gameplay.Movement;
using Gameplay.Monster;
using UnityEngine;

namespace Code.Common
{
    public class TestMonster : MonoBehaviour
    {
        public MonsterData MonsterData;
        public Transform[] _routePoints;
        
        private void Start()
        {
            var entity = Contexts.sharedInstance.game.CreateEntity()
                .AddWorldPosition(_routePoints[0].position)
                .AddTransform(transform)
                .AddView(gameObject)
                .AddSpeed(MonsterData.Speed)
                .AddReachDistance(MonsterData.ReachDistance)
                .AddPath(new Path(_routePoints));

            entity.isMoving = true;
        }
    }
}