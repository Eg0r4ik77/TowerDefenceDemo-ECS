using Infrastructure.Systems;
using Infrastructure.View.Systems;

namespace Infrastructure.View
{
    public class BindViewFeature : Feature
    {
        public BindViewFeature(ISystemFactory systems)
        {
            Add(systems.Create<BindEntityViewSystem>());
        }
    }
}