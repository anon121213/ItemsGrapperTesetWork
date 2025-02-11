using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace _Scripts.Data
{
  [CreateAssetMenu(fileName = "Items", menuName = "Data/Items")]
  public class ItemsSettings : ScriptableObject
  {
    [field: SerializeField] public List<AssetReferenceGameObject> Items { get; private set; } = new();
    [field: SerializeField] public List<Vector3> ItemsSpawnPoints { get; private set; } = new();
  }
}