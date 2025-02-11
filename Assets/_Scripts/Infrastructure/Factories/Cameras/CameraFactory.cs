using _Scripts.Data.AssetLoader;
using _Scripts.Data.DataProvider;
using _Scripts.Infrastructure.CameraProvider;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace _Scripts.Infrastructure.Factories.Cameras
{
  public class CameraFactory : ICameraFactory
  {
    private readonly ICameraProvider _cameraProvider;
    private readonly IStaticDataProvider _staticDataProvider;
    private readonly IAssetProvider _assetProvider;

    public CameraFactory(ICameraProvider cameraProvider,
      IStaticDataProvider staticDataProvider,
      IAssetProvider assetProvider)
    {
      _cameraProvider = cameraProvider;
      _staticDataProvider = staticDataProvider;
      _assetProvider = assetProvider;
    }

    public async UniTask CreateCamera()
    {
      Camera prefab = await _assetProvider.LoadAssetAsync<Camera>(_staticDataProvider.CameraSetting.Prefab);
      var camera = Object.Instantiate(prefab);
      _cameraProvider.SetMainCamera(camera);
    }
  }
}