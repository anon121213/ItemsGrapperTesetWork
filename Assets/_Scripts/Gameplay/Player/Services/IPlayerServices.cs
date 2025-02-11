namespace _Scripts.Gameplay.Player.Services
{
  public interface IPlayerServices
  {
    void AddService(IPlayerService playerService);
    void EnableServices();
    void DisableServices();
    public void Update();
    public void FixedUpdate();
  }
}