using UnityEngine;

namespace Code.Gameplay.Towers.Factory
{
    public interface ITowerFactory
    {
        public GameEntity Create(TowerType type, Vector3 position);
    }
}