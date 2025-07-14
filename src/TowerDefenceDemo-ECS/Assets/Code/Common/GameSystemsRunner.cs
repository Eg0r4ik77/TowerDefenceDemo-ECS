using Code.Gameplay;
using Code.Infrastructure.Systems;
using UnityEngine;
using Zenject;

namespace Code.Common
{
    public class GameSystemsRunner : MonoBehaviour
    {
        private ISystemFactory _systemFactory;
        
        private GameplayFeature _gameplayFeature;
        private RigidbodyMovementFeature _rigidbodyMovementFeature;
        
        [Inject]
        private void Construct(ISystemFactory systemFactory)
        {
            _systemFactory = systemFactory;
        }
        
        private void Start()
        {
            _gameplayFeature = _systemFactory.Create<GameplayFeature>();
            _gameplayFeature.Initialize();
            
            _rigidbodyMovementFeature = _systemFactory.Create<RigidbodyMovementFeature>();
            _rigidbodyMovementFeature.Initialize();
        }

        private void Update()
        {
            _gameplayFeature.Execute();
            _gameplayFeature.Cleanup();
        }

        private void FixedUpdate()
        {
            _rigidbodyMovementFeature.Execute();
            _rigidbodyMovementFeature.Cleanup();
        }

        private void OnDestroy()
        {
            _gameplayFeature.TearDown();
            _rigidbodyMovementFeature.TearDown();
        }
    }
}