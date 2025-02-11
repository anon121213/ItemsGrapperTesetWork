namespace _Scripts.Data.DataProvider
{
  public interface IStaticDataProvider
  {
    PlayerSettings PlayerSettings { get; }
    ItemsSettings ItemsSettings { get; }
    CameraSetting CameraSetting { get; }
  }
}