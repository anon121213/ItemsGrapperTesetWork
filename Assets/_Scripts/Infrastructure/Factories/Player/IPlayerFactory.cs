using Cysharp.Threading.Tasks;
using UnityEngine;

namespace _Scripts.Infrastructure.Factories.Player
{
  public interface IPlayerFactory
  {
    UniTask<GameObject> CreatePlayer();
  }
}