using _Scripts.Infrastructure.Warmup;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace _Scripts.Infrastructure.Factories.Player
{
  public interface IPlayerFactory : IWarmupable
  {
    UniTask<GameObject> CreatePlayer();
  }
}