using Code.Gameplay.Enemies;
using Code.Gameplay.Movement;
using UnityEngine;

namespace Code.Common
{
    public class EcsRunner : MonoBehaviour
    {
        private MovementFeature _movementFeature;
        private CleanupDestroyedFeature _cleanupDestroyedFeature;
        private EnemyFeature _enemyFeature;
        
        public TestMonster _enemyPrefab;
        public Transform[] _routePoints;

        private void Start()
        {
            var context = Contexts.sharedInstance.game;
            
            _movementFeature = new MovementFeature(context);
            _movementFeature.Initialize();
            
            _cleanupDestroyedFeature = new CleanupDestroyedFeature(context);
            _cleanupDestroyedFeature.Initialize();
            
            _enemyFeature = new EnemyFeature(context, _enemyPrefab, _routePoints);
            _enemyFeature.Initialize();
        }

        private void Update()
        {
            _movementFeature.Execute();
            _movementFeature.Cleanup();
            
            _cleanupDestroyedFeature.Execute();
            _cleanupDestroyedFeature.Cleanup();
            
            _enemyFeature.Execute();
            _enemyFeature.Cleanup();
        }

        private void OnDestroy()
        {
            _movementFeature.TearDown();
            _cleanupDestroyedFeature.TearDown();
            _enemyFeature.TearDown();
        }
    }
}