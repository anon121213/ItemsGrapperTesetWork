using _Scripts.Data.AssetLoader;
using _Scripts.Data.DataProvider;
using _Scripts.Gameplay.Input.InputService;
using _Scripts.Infrastructure.CameraProvider;
using _Scripts.Infrastructure.Loader;
using _Scripts.Infrastructure.Warmup;
using _Scripts.Infrastructure.WinSystem;
using UnityEngine;
using VContainer;

namespace _Scripts.Infrastructure.Installers
{
  public class ServicesInstaller : MonoInstaller
  {
    [SerializeField] private AllData _allData;

    public override void Register(IContainerBuilder builder)
    {
      builder.Register<ISceneLoader, SceneLoader>(Lifetime.Singleton);
      builder.Register<IAssetProvider, AssetProvider>(Lifetime.Singleton);
      builder.Register<IStaticDataProvider, StaticDataProvider>(Lifetime.Singleton).WithParameter(_allData);
      builder.Register<IInputService, InputService>(Lifetime.Singleton);
      builder.Register<IWinService, WinService>(Lifetime.Singleton);
      builder.Register<ICameraProvider, CameraProvider.CameraProvider>(Lifetime.Singleton);
      builder.Register<IWarmupService, WarmupService>(Lifetime.Singleton);
    }
  }
}