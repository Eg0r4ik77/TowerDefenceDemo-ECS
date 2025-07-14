using Code.Gameplay.Movement;
using Code.Gameplay.Movement.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay
{
    public class RigidbodyMovementFeature : Feature
    {
        public RigidbodyMovementFeature(ISystemFactory systemFactory)
        {
            Add(systemFactory.Create<UpdateRigidbodyPositionSystem>());
        }
    }
}