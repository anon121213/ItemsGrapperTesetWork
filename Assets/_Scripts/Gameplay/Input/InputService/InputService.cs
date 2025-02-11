using System;
using _Scripts.Gameplay.Input.PcInput;
using UnityEngine;

namespace _Scripts.Gameplay.Input.InputService
{
  public class InputService : IInputService
  {
    private PlayerInput _input;
    private GameInput _gameInput;

    public event Action GrapAction;

    public Vector3 MoveAxis =>
      _input.GetMoveDirection();

    public float LookXAxis =>
      _input.GetLookVector().x;

    public float LookYAxis =>
      _input.GetLookVector().y;

    public float ScrollValue =>
      _input.GetScrollValue();

    public void Initialize()
    {
      _gameInput = new GameInput();
      _input = new PCInput(_gameInput);

      _input.Grap += Grap;
      _gameInput.Enable();
    }

    private void Grap() =>
      GrapAction?.Invoke();

    public void Dispose()
    {
      _input.Grap -= Grap;
      _gameInput.Dispose();
    }
  }
}