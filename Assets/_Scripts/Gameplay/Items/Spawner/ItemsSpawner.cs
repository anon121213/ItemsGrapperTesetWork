using System;
using System.Collections.Generic;
using _Scripts.Data.AssetLoader;
using _Scripts.Data.DataProvider;
using _Scripts.Gameplay.Items.Container;
using Cysharp.Threading.Tasks;
using UnityEngine;
using VContainer;
using VContainer.Unity;
using Random = UnityEngine.Random;

namespace _Scripts.Gameplay.Items.Spawner
{
  public class ItemsSpawner : IItemsSpawner
  {
    private readonly List<Vector3> _spawnPoints = new();
    private readonly Collider[] _results = new Collider[10];

    private readonly IStaticDataProvider _staticDataProvider;
    private readonly IAssetProvider _assetProvider;
    private readonly IItemsContainer _itemsContainer;
    private readonly IObjectResolver _resolver;

    public ItemsSpawner(IStaticDataProvider staticDataProvider,
      IAssetProvider assetProvider,
      IItemsContainer itemsContainer,
      IObjectResolver resolver)
    {
      _staticDataProvider = staticDataProvider;
      _assetProvider = assetProvider;
      _itemsContainer = itemsContainer;
      _resolver = resolver;
    }

    public async UniTask SpawnItems()
    {
      _spawnPoints.AddRange(_staticDataProvider.ItemsSettings.ItemsSpawnPoints);

      foreach (var spawnPoint in _spawnPoints)
      {
        Item item = await GetItem(spawnPoint);

        if (item == null)
          continue;

        item = _resolver.Instantiate(item, spawnPoint, Quaternion.identity);

        _itemsContainer.AddItem(item);
      }
    }

    private async UniTask<Item> GetItem(Vector3 spawnPoint)
    {
      List<int> triedIndices = new List<int>();

      while (triedIndices.Count < _staticDataProvider.ItemsSettings.Items.Count)
      {
        int assetIndex = Random.Range(0, _staticDataProvider.ItemsSettings.Items.Count);

        if (triedIndices.Contains(assetIndex))
          continue;

        triedIndices.Add(assetIndex);

        GameObject item = await _assetProvider.LoadAssetAsync(_staticDataProvider.ItemsSettings.Items[assetIndex]);

        BoxCollider prefabCollider = item.GetComponent<BoxCollider>();
        Vector3 size = prefabCollider.size;

        Array.Clear(_results, 0, _results.Length);
        Physics.OverlapBoxNonAlloc(spawnPoint, size / 2, _results);

        if (_results.Length == 0 || _results[0] == null)
          return item.GetComponent<Item>();
      }

      Debug.LogWarning("Failed to find a valid spawn point after checking all items.");
      return null;
    }
  }
}