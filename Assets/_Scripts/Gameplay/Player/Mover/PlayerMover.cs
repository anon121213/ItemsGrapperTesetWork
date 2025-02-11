using _Scripts.Data.DataProvider;
using _Scripts.Gameplay.Input.InputService;
using _Scripts.Gameplay.Player.Services.Services.Base;
using UnityEngine;

namespace _Scripts.Gameplay.Player.Mover
{
  public class PlayerMover : IPlayerMover, IFixedUpdatable
  {
    private readonly IInputService _inputService;
    private readonly IStaticDataProvider _staticDataProvider;

    private CharacterController _characterController;
    private Camera _camera;

    private float _speed;
    private float _gravity;
    private float _verticalVelocity;

    public PlayerMover(IInputService inputService,
      IStaticDataProvider staticDataProvider)
    {
      _inputService = inputService;
      _staticDataProvider = staticDataProvider;
    }

    public void Initialize(CharacterController characterController, Camera camera)
    {
      _characterController = characterController;
      _speed = _staticDataProvider.PlayerSettings.Speed;
      _gravity = _staticDataProvider.PlayerSettings.Gravity;
      _camera = camera;
    }

    public void FixedUpdate()
    {
      if (_characterController.isGrounded)
        _verticalVelocity = 0f;
      else
        ApplyGravity();

      Vector3 moveVector = GetMoveVector();
      moveVector.y = _verticalVelocity;
      _characterController.Move(moveVector * Time.fixedDeltaTime);
    }

    private Vector3 GetMoveVector()
    {
      Vector3 move = _inputService.MoveAxis;
      Vector3 moveDirection = _camera.transform.forward * move.z + _camera.transform.right * move.x;

      moveDirection.y = 0f;
      moveDirection.Normalize();

      Vector3 velocity = moveDirection * _speed;
      return velocity;
    }

    private void ApplyGravity() =>
      _verticalVelocity -= _gravity * Time.fixedDeltaTime;
  }
}