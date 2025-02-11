using _Scripts.Data.DataProvider;
using _Scripts.Gameplay.Input.InputService;
using _Scripts.Gameplay.Player.Services.Services.Base;
using _Scripts.Infrastructure.CameraProvider;
using UnityEngine;

namespace _Scripts.Gameplay.Player.Services.Services.Camera
{
  public class CameraRotator : ICameraRotator, IUpdatable
  {
    private readonly IInputService _inputService;
    private readonly ICameraProvider _cameraProvider;
    private readonly float _mouseSpeed;

    private float _xRotation;
    private float _yRotation;

    private bool _isEnabled;

    public CameraRotator(IStaticDataProvider staticDataProvider,
      IInputService inputService,
      ICameraProvider cameraProvider)
    {
      _inputService = inputService;
      _cameraProvider = cameraProvider;
      _mouseSpeed = staticDataProvider.PlayerSettings.MouseSpeed;
    }

    public void Enable() =>
      _isEnabled = true;

    public void Disable() =>
      _isEnabled = false;

    public void Update()
    {
      if (!_isEnabled)
        return;

      float mouseX = _inputService.LookXAxis * _mouseSpeed * Time.deltaTime;
      float mouseY = _inputService.LookYAxis * _mouseSpeed * Time.deltaTime;

      _xRotation -= mouseY;
      _xRotation = Mathf.Clamp(_xRotation, -90f, 90f);

      _yRotation += mouseX;

      _cameraProvider.MainCamera.transform.localRotation = Quaternion.Euler(_xRotation, _yRotation, 0f);
    }
  }

  public interface ICameraRotator : IPlayerService
  {
  }
}