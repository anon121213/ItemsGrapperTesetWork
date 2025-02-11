using _Scripts.Gameplay.Player.Services;
using UnityEngine;
using VContainer;

namespace _Scripts.Gameplay.Player
{
  public class Player : MonoBehaviour
  {
    private IPlayerServices _playerServices;

    [Inject]
    private void Inject(IPlayerServices playerServices)
    {
      _playerServices = playerServices;
    }

    private void Start()
    {
      _playerServices.EnableServices();
    }

    private void Update()
    {
      _playerServices.Update();
    }

    private void FixedUpdate()
    {
      _playerServices.FixedUpdate();
    }

    private void OnDestroy()
    {
      _playerServices.DisableServices();
    }
  }
}