using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace _Scripts.Data.AssetLoader
{
  public interface IAssetProvider
  {
    UniTask<GameObject> LoadAssetAsync(AssetReference path);
    UniTask<TObject> LoadAssetAsync<TObject>(AssetReference path) where TObject : Component;
  }
}