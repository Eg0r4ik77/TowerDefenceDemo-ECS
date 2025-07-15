using Gameplay.Movement.Systems;
using Infrastructure.Systems;

namespace Gameplay.Movement
{
    public class RigidbodyMovementFeature : Feature
    {
        public RigidbodyMovementFeature(ISystemFactory systemFactory)
        {
            Add(systemFactory.Create<UpdateRigidbodyPositionSystem>());
        }
    }
}