using Cysharp.Threading.Tasks;
using UnityEngine;

namespace _Scripts.Infrastructure.Factories.Cameras
{
  public interface ICameraFactory
  {
    UniTask CreateCamera();
  }
}