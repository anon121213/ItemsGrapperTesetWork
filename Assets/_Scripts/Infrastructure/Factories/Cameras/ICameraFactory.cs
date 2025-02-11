using _Scripts.Infrastructure.Warmup;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace _Scripts.Infrastructure.Factories.Cameras
{
  public interface ICameraFactory : IWarmupable
  {
    UniTask CreateCamera();
  }
}