using System.Collections.Generic;
using _Scripts.Gameplay.Player.Services.Services.Base;

namespace _Scripts.Gameplay.Player.Services
{
  public class PlayerServices : IPlayerServices
  {
    private readonly List<IUpdatable> _updatableServices = new();
    private readonly List<IFixedUpdatable> _fixedUpdatableServices = new();
    private readonly List<IPlayerService> _playerServices = new();

    private bool _isStarted;

    public PlayerServices(IEnumerable<IUpdatable> updatables,
      IEnumerable<IFixedUpdatable> fixedUpdatables)
    {
      foreach (var service in updatables)
        _updatableServices.Add(service);

      foreach (var service in fixedUpdatables)
        _fixedUpdatableServices.Add(service);
    }

    public void AddService(IPlayerService playerService)
    {
      if (_playerServices.Contains(playerService))
        return;

      _playerServices.Add(playerService);
    }

    public void EnableServices()
    {
      foreach (var service in _playerServices)
        service.Enable();

      _isStarted = true;
    }

    public void DisableServices()
    {
      foreach (var service in _playerServices)
        service.Disable();

      _isStarted = false;
    }

    public void Update()
    {
      if (!_isStarted)
        return;

      foreach (var service in _updatableServices)
        service.Update();
    }

    public void FixedUpdate()
    {
      if (!_isStarted)
        return;

      foreach (var service in _fixedUpdatableServices)
        service.FixedUpdate();
    }
  }

  public interface IPlayerService
  {
    void Enable();
    void Disable();
  }
}