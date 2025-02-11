namespace _Scripts.Data.DataProvider
{
  public class StaticDataProvider : IStaticDataProvider
  {
    public StaticDataProvider(AllData allData)
    {
      PlayerSettings = allData.playerSettings;
      ItemsSettings = allData.itemsSettings;
      CameraSetting = allData.CameraSetting;
    }

    public PlayerSettings PlayerSettings { get; }
    public ItemsSettings ItemsSettings { get; }
    public CameraSetting CameraSetting { get; }
  }
}