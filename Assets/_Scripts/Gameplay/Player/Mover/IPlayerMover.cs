using UnityEngine;

namespace _Scripts.Gameplay.Player.Mover
{
  public interface IPlayerMover
  {
    void Initialize(CharacterController characterController,
      UnityEngine.Camera camera);
  }
}