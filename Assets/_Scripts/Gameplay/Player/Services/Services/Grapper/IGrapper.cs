using _Scripts.Gameplay.Player.Services.Services.Base;

namespace _Scripts.Gameplay.Player.Services.Services.Grapper
{
  public interface IGrapper : IUpdatable
  {
    void Initialize(UnityEngine.Camera camera);
  }
}