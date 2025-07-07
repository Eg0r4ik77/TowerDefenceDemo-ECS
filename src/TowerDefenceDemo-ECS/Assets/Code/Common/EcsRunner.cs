using Code.Gameplay.Movement;
using UnityEngine;

namespace Code.Common
{
    public class EcsRunner : MonoBehaviour
    {
        private MovementFeature _movementFeature;
        private CleanupDestroyedFeature _cleanupDestroyedFeature;
        
        private void Start()
        {
            var context = Contexts.sharedInstance.game;
            
            _movementFeature = new MovementFeature(context);
            _movementFeature.Initialize();
            
            _cleanupDestroyedFeature = new CleanupDestroyedFeature(context);
            _cleanupDestroyedFeature.Initialize();
        }

        private void Update()
        {
            _movementFeature.Execute();
            _movementFeature.Cleanup();
            
            _cleanupDestroyedFeature.Execute();
            _cleanupDestroyedFeature.Cleanup();
        }

        private void OnDestroy()
        {
            _movementFeature.TearDown();
            _cleanupDestroyedFeature.TearDown();
        }
    }
}