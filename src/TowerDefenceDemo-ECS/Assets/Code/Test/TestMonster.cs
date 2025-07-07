using Code.Gameplay.Movement;
using Gameplay.Monster;
using UnityEngine;

namespace Code.Common
{
    public class TestMonster : MonoBehaviour
    {
        public MonsterData MonsterData;
        
        public void Init(Transform[] routePoints)
        {
            var entity = Contexts.sharedInstance.game.CreateEntity()
                .AddWorldPosition(routePoints[0].position)
                .AddTransform(transform)
                .AddView(gameObject)
                .AddSpeed(MonsterData.Speed)
                .AddReachDistance(MonsterData.ReachDistance)
                .AddPath(new Path(routePoints));

            entity.isMoving = true;
        }
    }
}