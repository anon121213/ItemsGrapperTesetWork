using System;
using System.Collections.Generic;
using _Scripts.Data.AssetLoader;
using _Scripts.Data.DataProvider;
using _Scripts.Gameplay.Items.Container;
using _Scripts.Gameplay.Items.Factory;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _Scripts.Gameplay.Items.Spawner
{
  public class ItemsSpawner : IItemsSpawner
  {
    private readonly List<Vector3> _spawnPoints = new();
    private readonly Collider[] _results = new Collider[10];

    private readonly IStaticDataProvider _staticDataProvider;
    private readonly IItemsFactory _itemsFactory;
    private readonly IAssetProvider _assetProvider;
    private readonly IItemsContainer _itemsContainer;

    public ItemsSpawner(IStaticDataProvider staticDataProvider,
      IItemsFactory itemsFactory,
      IAssetProvider assetProvider,
      IItemsContainer itemsContainer)
    {
      _staticDataProvider = staticDataProvider;
      _itemsFactory = itemsFactory;
      _assetProvider = assetProvider;
      _itemsContainer = itemsContainer;
    }

    public async UniTask SpawnItems()
    {
      _spawnPoints.AddRange(_staticDataProvider.ItemsSettings.ItemsSpawnPoints);

      foreach (var spawnPoint in _spawnPoints)
      {
        int itemIndex = await GetItem(spawnPoint);

        if (itemIndex < 0)
          continue;

        Item item = await _itemsFactory.CreateItem(itemIndex, spawnPoint);

        _itemsContainer.AddItem(item);
      }
    }

    private async UniTask<int> GetItem(Vector3 spawnPoint)
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
          return assetIndex;
      }

      Debug.LogWarning("Failed to find a valid spawn point after checking all items.");
      return -1;
    }
  }
}