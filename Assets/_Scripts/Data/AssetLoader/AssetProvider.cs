using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace _Scripts.Data.AssetLoader
{
  public class AssetProvider : IAssetProvider
  {
    public async UniTask<GameObject> LoadAssetAsync(AssetReference path)
    {
      AsyncOperationHandle<GameObject> handle = Addressables.LoadAssetAsync<GameObject>(path);

      await handle.Task;

      if (handle.Status == AsyncOperationStatus.Succeeded)
        return handle.Result;

      Debug.LogError($"Не удалось загрузить префаб по пути: {path}");
      return null;
    }

    public async UniTask<TObject> LoadAssetAsync<TObject>(AssetReference path) where TObject : Component
    {
      AsyncOperationHandle<GameObject> handle = Addressables.LoadAssetAsync<GameObject>(path);

      await handle.Task;

      if (handle.Status == AsyncOperationStatus.Succeeded)
      {
        handle.Result.TryGetComponent(out TObject component);
        return component;
      }

      Debug.LogError($"Не удалось загрузить префаб по пути: {path}");
      return null;
    }
  }
}