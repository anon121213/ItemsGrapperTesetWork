using UnityEngine;
using UnityEngine.AddressableAssets;

namespace _Scripts.Data
{
  [CreateAssetMenu(fileName = "DefaultPlayerSettings", menuName = "Data/DefaultPlayerSettings")]
  public class PlayerSettings : ScriptableObject
  {
    [field: SerializeField] public AssetReferenceGameObject Prefab { get; private set; }
    [field: SerializeField] public float Speed { get; private set; }
    [field: SerializeField] public float Gravity { get; private set; }
    [field: SerializeField] public float MouseSpeed { get; private set; }
    [field: SerializeField] public Vector3 SpawnPoint { get; private set; }
  }
}