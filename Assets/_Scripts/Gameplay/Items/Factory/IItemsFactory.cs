using _Scripts.Infrastructure.Warmup;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace _Scripts.Gameplay.Items.Factory
{
  public interface IItemsFactory : IWarmupable
  {
    UniTask<Item> CreateItem(int itemIndex, Vector3 spawnPoint);
  }
}