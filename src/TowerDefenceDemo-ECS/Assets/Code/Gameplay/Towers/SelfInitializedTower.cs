using System;
using Code.Gameplay.Towers.Factory;
using Code.Infrastructure.View;
using UnityEngine;
using Zenject;

namespace Code.Gameplay.Towers
{
    public class SelfInitializedTower : MonoBehaviour
    {
        [SerializeField] private TowerType _type;
        
        private ITowerFactory _factory;

        [Inject]
        private void Construct(ITowerFactory factory)
        {
            _factory = factory;
        }
        
        private void Start()
        {
            EntityView view = GetComponent<EntityView>();
            GameEntity tower = _factory.Create(_type, transform.position);
            
            if(view != null) 
                tower.AddView(view);
        }
        
    }
}