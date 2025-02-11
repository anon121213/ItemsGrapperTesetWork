using _Scripts.Data.AssetLoader;
using _Scripts.Data.DataProvider;
using Cysharp.Threading.Tasks;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace _Scripts.Gameplay.Items.Factory
{
  public class ItemsFactory : IItemsFactory
  {
    private readonly IStaticDataProvider _staticDataProvider;
    private readonly IAssetProvider _assetProvider;
    private readonly IObjectResolver _resolver;

    public ItemsFactory(IStaticDataProvider staticDataProvider,
      IAssetProvider assetProvider,
      IObjectResolver resolver)
    {
      _staticDataProvider = staticDataProvider;
      _assetProvider = assetProvider;
      _resolver = resolver;
    }

    public async UniTask Warmup()
    {
      foreach (var item in _staticDataProvider.ItemsSettings.Items) 
        await _assetProvider.LoadAssetAsync(item);
    }

    public async UniTask<Item> CreateItem(int itemIndex, Vector3 spawnPoint)
    {
      Item prefab = await _assetProvider.LoadAssetAsync<Item>(_staticDataProvider.ItemsSettings.Items[itemIndex]);
      var item = _resolver.Instantiate(prefab, spawnPoint, Quaternion.identity);
      return item;
    }
  }
}