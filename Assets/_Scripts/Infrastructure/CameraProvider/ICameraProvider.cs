using UnityEngine;

namespace _Scripts.Infrastructure.CameraProvider
{
  public interface ICameraProvider
  {
    Camera MainCamera { get; }
    void SetMainCamera(UnityEngine.Camera camera);
  }
}