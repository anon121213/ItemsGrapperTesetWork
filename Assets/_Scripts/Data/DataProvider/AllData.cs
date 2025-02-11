using UnityEngine;

namespace _Scripts.Data.DataProvider
{
  [CreateAssetMenu(fileName = "AllData", menuName = "Data/AllData")]
  public class AllData : ScriptableObject
  {
    [field: SerializeField] public PlayerSettings playerSettings { get; private set; }
    [field: SerializeField] public CameraSetting CameraSetting { get; private set; }
    [field: SerializeField] public ItemsSettings itemsSettings { get; private set; }
  }
}