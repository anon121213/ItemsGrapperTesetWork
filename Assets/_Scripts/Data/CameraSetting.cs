using UnityEngine;
using UnityEngine.AddressableAssets;

namespace _Scripts.Data
{
  [CreateAssetMenu(menuName = "Data/Camera/CameraSetting", fileName = "CameraSetting")]
  public class CameraSetting : ScriptableObject
  {
    [field: SerializeField] public AssetReferenceGameObject Prefab { get; private set; }
  }
}