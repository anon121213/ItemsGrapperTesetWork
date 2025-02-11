using _Scripts.Gameplay.Input.InputService;
using _Scripts.Gameplay.Items.Spawner;
using _Scripts.Gameplay.Player.Services;
using _Scripts.Gameplay.Player.Services.Services.Camera;
using _Scripts.Infrastructure.CameraProvider;
using _Scripts.Infrastructure.Factories.Cameras;
using _Scripts.Infrastructure.Factories.Player;
using _Scripts.Infrastructure.Loader;
using _Scripts.Infrastructure.WinSystem;
using UnityEngine;
using VContainer.Unity;

namespace _Scripts.Infrastructure.Bootstrapper
{
  public class MainBootstrapper : IInitializable
  {
    private const int FRAMERATE = 240;

    private readonly ISceneLoader _sceneLoader;
    private readonly IInputService _inputService;
    private readonly IPlayerFactory _playerFactory;
    private readonly IItemsSpawner _itemSpawner;
    private readonly IWinService _winService;
    private readonly ICameraFactory _cameraFactory;
    private readonly ICameraProvider _cameraProvider;
    private readonly ICameraRotator _cameraRotator;
    private readonly IPlayerServices _playerServices;

    public MainBootstrapper(ISceneLoader sceneLoader,
      IPlayerFactory playerFactory,
      IInputService inputService,
      IItemsSpawner itemsSpawner,
      IWinService winService,
      ICameraFactory cameraFactory,
      ICameraProvider cameraProvider,
      ICameraRotator cameraRotator,
      IPlayerServices playerServices)
    {
      _sceneLoader = sceneLoader;
      _playerFactory = playerFactory;
      _inputService = inputService;
      _itemSpawner = itemsSpawner;
      _winService = winService;
      _cameraFactory = cameraFactory;
      _cameraProvider = cameraProvider;
      _cameraRotator = cameraRotator;
      _playerServices = playerServices;
    }

    public async void Initialize()
    {
      Application.targetFrameRate = FRAMERATE;
      Cursor.lockState = CursorLockMode.Locked;
      Cursor.visible = false;

      _inputService.Initialize();
      await _sceneLoader.Load(SceneNamesConstants.GameScene);
      await _cameraFactory.CreateCamera();

      _playerServices.AddService(_cameraRotator);
      var player = await _playerFactory.CreatePlayer();

      CameraFollow follower = _cameraProvider.MainCamera.GetComponent<CameraFollow>();
      follower.Initialize(player.transform, new Vector3(0, 0.8f, 0));


      await _itemSpawner.SpawnItems();
      _winService.Initialize();
    }
  }
}