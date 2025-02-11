using _Scripts.Data.AssetLoader;
using _Scripts.Data.DataProvider;
using _Scripts.Gameplay.Player.Mover;
using _Scripts.Gameplay.Player.Services.Services.Grapper;
using _Scripts.Infrastructure.CameraProvider;
using Cysharp.Threading.Tasks;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace _Scripts.Infrastructure.Factories.Player
{
  public class PlayerFactory : IPlayerFactory
  {
    private readonly IStaticDataProvider _staticDataProvider;
    private readonly IObjectResolver _resolver;
    private readonly IPlayerMover _playerMover;
    private readonly IGrapper _grapper;
    private readonly ICameraProvider _cameraProvider;
    private readonly IAssetProvider _assetProvider;

    public PlayerFactory(IAssetProvider assetProvider,
      IStaticDataProvider staticDataProvider,
      IObjectResolver resolver,
      IPlayerMover playerMover,
      IGrapper grapper,
      ICameraProvider cameraProvider)
    {
      _assetProvider = assetProvider;
      _staticDataProvider = staticDataProvider;
      _resolver = resolver;
      _playerMover = playerMover;
      _grapper = grapper;
      _cameraProvider = cameraProvider;
    }

    public async UniTask Warmup()
    {
      await _assetProvider.LoadAssetAsync(_staticDataProvider.PlayerSettings.Prefab);
    }

    public async UniTask<GameObject> CreatePlayer()
    {
      GameObject playerPrefab = await _assetProvider.LoadAssetAsync(_staticDataProvider.PlayerSettings.Prefab);

      GameObject player = _resolver.Instantiate(playerPrefab,
        _staticDataProvider.PlayerSettings.SpawnPoint, Quaternion.identity);

      CharacterController characterController = player.GetComponent<CharacterController>();

      InitializeGrapper(_cameraProvider.MainCamera);
      InitializePlayerMover(characterController, _cameraProvider.MainCamera);
      return player;
    }

    private void InitializeGrapper(Camera camera) =>
      _grapper.Initialize(camera);

    private void InitializePlayerMover(CharacterController characterController, Camera camera) =>
      _playerMover.Initialize(characterController, camera);
  }
}