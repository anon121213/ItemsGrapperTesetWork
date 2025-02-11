using Cysharp.Threading.Tasks;
using UnityEngine;

namespace _Scripts.Infrastructure.CameraProvider
{
  public class CameraProvider : ICameraProvider
  {
    public Camera MainCamera { get; private set; }

    public void SetMainCamera(Camera camera)
    {
      if (MainCamera != null)
        return;

      MainCamera = camera;
    }
  }
}