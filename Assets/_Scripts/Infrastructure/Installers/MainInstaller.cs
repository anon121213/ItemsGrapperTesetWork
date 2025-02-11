using _Scripts.Data.AssetLoader;
using _Scripts.Data.DataProvider;
using _Scripts.Gameplay.Input;
using _Scripts.Gameplay.Input.InputService;
using _Scripts.Gameplay.Items.Container;
using _Scripts.Gameplay.Items.Spawner;
using _Scripts.Gameplay.Player.Mover;
using _Scripts.Gameplay.Player.Services;
using _Scripts.Gameplay.Player.Services.Services;
using _Scripts.Gameplay.Player.Services.Services.Base;
using _Scripts.Gameplay.Player.Services.Services.Camera;
using _Scripts.Gameplay.Player.Services.Services.Grapper;
using _Scripts.Infrastructure.Bootstrapper;
using _Scripts.Infrastructure.CameraProvider;
using _Scripts.Infrastructure.Factories;
using _Scripts.Infrastructure.Factories.Cameras;
using _Scripts.Infrastructure.Factories.Player;
using _Scripts.Infrastructure.Loader;
using _Scripts.Infrastructure.WinSystem;
using _Scripts.Infrastructure.WinSystem.UI;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace _Scripts.Infrastructure.Installers
{
  public class MainInstaller : LifetimeScope
  {
    [SerializeField] private AllData _allData;
    [SerializeField] private WinPresenter _winPresenter;

    protected override void Configure(IContainerBuilder builder)
    {
      builder.Register<ISceneLoader, SceneLoader>(Lifetime.Singleton);
      builder.Register<IAssetProvider, AssetProvider>(Lifetime.Singleton);
      builder.Register<IStaticDataProvider, StaticDataProvider>(Lifetime.Singleton).WithParameter(_allData);
      builder.Register<ICameraProvider, CameraProvider.CameraProvider>(Lifetime.Singleton);
      builder.Register<IInputService, InputService>(Lifetime.Singleton);
      builder.Register<IPlayerFactory, PlayerFactory>(Lifetime.Singleton);
      builder.Register<IItemsContainer, ItemsContainer>(Lifetime.Singleton);
      builder.Register<IItemsSpawner, ItemsSpawner>(Lifetime.Singleton);
      builder.Register<IWinService, WinService>(Lifetime.Singleton);
      builder.Register<IPlayerServices, PlayerServices>(Lifetime.Singleton);
      builder.Register<ICameraFactory, CameraFactory>(Lifetime.Singleton);
      builder.Register<IGrapper, Grapper>(Lifetime.Singleton).As<IUpdatable>();
      builder.Register<ICameraRotator, CameraRotator>(Lifetime.Singleton).As<IUpdatable>();
      builder.Register<IPlayerMover, PlayerMover>(Lifetime.Singleton).As<IFixedUpdatable>();
      builder.RegisterInstance(_winPresenter);

      builder.RegisterEntryPoint<MainBootstrapper>().AsSelf();
    }
  }
}