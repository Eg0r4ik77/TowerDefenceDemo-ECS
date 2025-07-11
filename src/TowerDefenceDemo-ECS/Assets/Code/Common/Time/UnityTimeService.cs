using Code.Gameplay.Common.Time;

namespace Code.Common.Time
{
  public class UnityTimeService : ITimeService
  { 
    public float DeltaTime => UnityEngine.Time.deltaTime;
  }
}